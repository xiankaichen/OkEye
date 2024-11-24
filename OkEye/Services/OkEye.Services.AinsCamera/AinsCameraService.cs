﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using gen3d;
using OkEye.Services.Interfaces;
using OkEye.Services.AinsCamera;
using OpenCvSharp;
using CameraInfoModel = OkEye.Services.Interfaces.CameraInfoModel;
using OkEye.Core;

namespace OkEye.Services
{
    /// <summary>
    /// 相机服务
    /// </summary>
    public class AinsCameraService : ICameraService
    {
        private Camera3DManager camera3DManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AinsCameraService()
        {
            camera3DManager = Camera3DManager.Instance;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="frame"></param>  帧数据
        /// <returns></returns>
        public OkEyeCode Capture(ref OkFrameData frame)
        {
            FrameData framedata = new FrameData();
            camera3DManager.Capture(ref framedata);
            //framedata = framedata;

            // 获取图像数据，转成Mat格式

            // 获取图像的数据流
            int width = camera3DManager.currCamInfo.camParam.textureWidth;
            int height = camera3DManager.currCamInfo.camParam.textureHeight;
            int pixelbyte = camera3DManager.currCamInfo.camParam.pixelBytes;

            int irwidth = camera3DManager.currCamInfo.camParam.irWidth;
            int irheight = camera3DManager.currCamInfo.camParam.irHeight;

            uint texturesize = framedata.textureSize;
            if (framedata.textureSize == 0)
            {
                // 图像数据无效
                return OkEyeCode.CameraFrameDataEmpty;

            }
            unsafe
            {
                Util util = new Util();
                Mat texturemat = util.textureByte2Mat(framedata.texture, camera3DManager.currCamInfo.camParam);
                frame.image = texturemat;
                Mat matpic = new Mat(camera3DManager.currCamInfo.camParam.irHeight,
                    camera3DManager.currCamInfo.camParam.irWidth,MatType.CV_32FC1);

                IntPtr mat_p = matpic.Ptr(0);
                float* bp = (float*)mat_p;

                for (int j = 0; j < irwidth * irheight; ++j)
                {
                    bp[j] = (float)framedata.depthmap[j];
                }

                //matpic.ImWrite("depth.png");
                Cv2.ConvertScaleAbs(matpic, matpic, 1);
                Cv2.ApplyColorMap(matpic, matpic, ColormapTypes.Jet);
                //matpic.ImWrite("depth_color.png");
                frame.depth = matpic;

                // 点云数据赋值
                Mat outPointMat = new Mat(irheight,irwidth,MatType.CV_32FC3, new Scalar(0));
                CameraParam cameraParam = camera3DManager.currCamInfo.camParam;
               GetPointsByRGB(ref framedata, ref cameraParam, ref outPointMat);
               frame.cloud = outPointMat;
               frame.cloudSize = (int)framedata.point3DSize;
            }
            return OkEyeCode.Ok;
        }


        // 将点云转换到RGB大小，坐标系为左相机的坐标系,参考samples中的CalibrationParams
        // Convert the point cloud to RGB size, with the coordinate system of the left camera, referring to CalibrationParams in samples
        public unsafe OkEyeCode GetPointsByRGB(ref FrameData frameData, ref CameraParam camParam, ref Mat outPoints)
        {
            var point3D = frameData.point3D;
            var pointUV = frameData.pointUV;
            int width = camParam.irWidth;
            int height = camParam.irHeight;
            int textureWidth = camParam.textureWidth;
            int textureHeight = camParam.textureHeight;

            if (point3D == null || pointUV == null)
            {
                return OkEyeCode.Failed;
            }

            Mat pointMat = new Mat(textureHeight, textureWidth, MatType.CV_32FC3, new Scalar(0));
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    int idx = r * width + c;

                    int x = (int)Math.Round((1 - pointUV[idx * 2 + 1]) * textureHeight);
                    int y = (int)Math.Round(pointUV[idx * 2 + 0] * textureWidth);
                    if (x < 0 || x >= textureHeight || y < 0 || y >= textureWidth)
                        continue;

                    Vec3f pixel = pointMat.At<Vec3f>(x, y);
                    pixel[0] = point3D[3 * idx];
                    pixel[1] = point3D[3 * idx + 1];
                    pixel[2] = point3D[3 * idx + 2];
                    pointMat.Set<Vec3f>(x, y, pixel);
                }
            }

            outPoints = pointMat;
            return OkEyeCode.Ok;
        }

        /// <summary>
        /// 图像byte转Mat
        /// </summary>
        /// <param name="rgb"></param>
        /// <param name="camparam"></param>
        /// <returns></returns>
        unsafe public Mat textureByte2Mat(byte* rgb, CameraParam camparam)
        {
            int length = camparam.textureWidth * camparam.textureHeight * 3;
            int width = camparam.textureWidth;
            int height = camparam.textureHeight;

            Scalar s = new Scalar(0, 0, 0);
            Mat matpic = new Mat(height, width, MatType.CV_8UC3, s);

            IntPtr mat_p = matpic.Ptr(0);
            byte* bp = (byte*)mat_p;

            for (int j = 0; j < height * width * 3; ++j)
            {
                bp[j] = (byte)rgb[j];
            }

            return matpic;
        }

        /// <summary>
        /// 设置相机IP
        /// </summary>
        /// <param name="oldip"></param>
        /// <param name="newip"></param>
        /// <returns></returns>
        public OkEyeCode SetCameraIP(string oldip, string newip)
        {
            camera3DManager.SetCameraIP(oldip, newip);
            return OkEyeCode.Ok;
        }

        /// <summary>
        /// 连接相机
        /// </summary>
        /// <param name="cameraInfo"></param>
        /// <returns></returns>
        public OkEyeCode ConnectCamera(CameraInfoModel cameraInfo)
        {
            OkEyeCode flag =  camera3DManager.ConnectCamera(cameraInfo.CameraIP);
            if (flag == OkEyeCode.Ok)
            {
                cameraInfo.Status = "已连接";
                return OkEyeCode.Ok;
            }
            else
            {
                cameraInfo.Status = "连接失败";
                return OkEyeCode.CameraConnectFailed;
            }

        }

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        public CameraInfoModel GetCameraInfo()
        {
            return camera3DManager.cameraInfoModel;
        }

        public OkEyeCode SetCameraParam(CameraInfoModel param)
        {
            float value = param.Exposure;
            StringVector paramGroupNames = new StringVector();
            camera3DManager.cam3d.cam.GetParamGroups(camera3DManager.currCamInfo, paramGroupNames);
            if (0 == camera3DManager.cam3d.cam.SetValue(camera3DManager.currCamInfo, "Exposure", value))
            {

                int ret = camera3DManager.cam3d.cam.ApplyParamGroup(camera3DManager.currCamInfo, "HighQualityConfig");
                if (ret != CameraPro.AC_OK)
                {
                    return OkEyeCode.Failed;
                }
            }
            else
                return OkEyeCode.Failed;
            return OkEyeCode.Ok;
        }

        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="cameraInfo"></param>   相机信息
        /// <returns></returns>
        public OkEyeCode DisconnectCamera(CameraInfoModel cameraInfo)
        {
            if (0 != camera3DManager.DisconnectCamera())
            {
                return OkEyeCode.CameraDisConnectFailed;
            }
            return OkEyeCode.Ok;
        }

        /// <summary>
        /// 发现设备列表
        /// </summary>
        /// <returns></returns>
        public List<CameraInfoModel> DiscoveryDeviceList()
        {
            List<CameraInfoModel> list = new List<CameraInfoModel>();
            CameraInfoVector cameraInfoVector = camera3DManager.DiscoverCameras();

            // 转化为List<CameraInfoModel>
            for (int i = 0; i < cameraInfoVector.Count; i++)
            {
                CameraInfoModel cameraInfoModel = new CameraInfoModel();
                cameraInfoModel.Band = "AinsCamera";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                cameraInfoModel.Pic = path + "data\\ains3dcam.png";
                cameraInfoModel.Name = cameraInfoVector[i].cameraName;
                cameraInfoModel.Serial = cameraInfoVector[i].serialNum;
                cameraInfoModel.CameraIP = cameraInfoVector[i].cameraIP;
                cameraInfoModel.UserIP = cameraInfoVector[i].userIP;
                cameraInfoModel.MacAdress = cameraInfoVector[i].macAddr;
                cameraInfoModel.irHeight = cameraInfoVector[i].camParam.irHeight;
                cameraInfoModel.irWidth = cameraInfoVector[i].camParam.irWidth;
                cameraInfoModel.textureWidth = cameraInfoVector[i].camParam.textureWidth;
                cameraInfoModel.textureHeight = cameraInfoVector[i].camParam.textureHeight;
                cameraInfoModel.irPerNum = cameraInfoVector[i].camParam.irPerNum;
                cameraInfoModel.Model =  cameraInfoVector[i].cameraModel;
                cameraInfoModel.Status = "未连接";
                cameraInfoModel.Gain = 0;
                cameraInfoModel.Exposure = 0;
                list.Add(cameraInfoModel);
            }
            return list;
        }

        public OkEyeCode SaveFrame(string path)
        {
            return camera3DManager.SaveFrame(path);
        }
    }
}

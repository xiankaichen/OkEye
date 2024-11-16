using System;
using System.Collections.Generic;
using System.Text;
using gen3d;
using OkEye.Services.Interfaces;
using OkEye.Services.ZkrhCamera;
using OpenCvSharp;
using CameraInfoModel = OkEye.Services.Interfaces.CameraInfoModel;

namespace OkEye.Services
{
    public class CameraService : ICameraService
    {
        private Camera3DManager camera3DManager;

        public CameraService()
        {
            camera3DManager = Camera3DManager.Instance;
        }

        public int Capture(ref OkFrameData frame)
        {
            FrameData framedata = new FrameData();
            camera3DManager.CapturePointCloud(ref framedata);
            //framedata = framedata;

            // 获取图像数据，转成Mat格式

            // 获取图像的数据流
            int width = camera3DManager.currCamInfo.camParam.textureWidth;
            int height = camera3DManager.currCamInfo.camParam.textureHeight;
            int pixelbyte = camera3DManager.currCamInfo.camParam.pixelBytes;

            int irwidth = camera3DManager.currCamInfo.camParam.irWidth;
            int irheight = camera3DManager.currCamInfo.camParam.irHeight;

            uint texturesize = framedata.textureSize;

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
            }
            return 0;
        }


        // 将点云转换到RGB大小，坐标系为左相机的坐标系,参考samples中的CalibrationParams
        // Convert the point cloud to RGB size, with the coordinate system of the left camera, referring to CalibrationParams in samples
        public unsafe int GetPointsByRGB(ref FrameData frameData, ref CameraParam camParam, ref Mat outPoints)
        {
            var point3D = frameData.point3D;
            var pointUV = frameData.pointUV;
            int width = camParam.irWidth;
            int height = camParam.irHeight;
            int textureWidth = camParam.textureWidth;
            int textureHeight = camParam.textureHeight;

            if (point3D == null || pointUV == null)
            {
                return -1;
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
            return 0;
        }



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

        public int SetCameraIP(string oldip, string newip)
        {
            camera3DManager.SetCameraIP(oldip, newip);
            return 0;
        }

        public int ConnectCamera(CameraInfoModel cameraInfo)
        {
            int flag =  camera3DManager.ConnectCamera(cameraInfo.CameraIP);
            if (flag == 0)
            {
                cameraInfo.Status = "已连接";
                return 0;
            }
            else
            {
                cameraInfo.Status = "连接失败";
                return -1;
            }

        }

        public CameraInfoModel GetCameraInfo()
        {
            return camera3DManager.cameraInfoModel;
        }

        public int DisconnectCamera(CameraInfoModel cameraInfo)
        {
            if (0 != camera3DManager.DisconnectCamera())
            {
                return -1;
            }
            return 0;
        }

        public List<CameraInfoModel> DiscoveryDeviceList()
        {
            List<CameraInfoModel> list = new List<CameraInfoModel>();
            CameraInfoVector cameraInfoVector = camera3DManager.DiscoverCameras();

            // 转化为List<CameraInfoModel>
            for (int i = 0; i < cameraInfoVector.Count; i++)
            {
                CameraInfoModel cameraInfoModel = new CameraInfoModel();
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
                cameraInfoModel.CameMode = cameraInfoVector[i].cameraModel;
                cameraInfoModel.Status = "未连接";
                list.Add(cameraInfoModel);
            }
            return list;
        }

        public int Capture(ref FrameData frame)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gen3d;
using OkEye.Core;
using OkEye.Services.Interfaces;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace OkEye.Services.AinsCamera
{
    public class Camera3DManager
    {
        // CameraManager is a singleton class
        private static Camera3DManager? instance;
        // List of cameras
        public  Gen3DCamera? cam3d;
        private FrameData? _frameData;
        public CameraInfo? currCamInfo;
        public CameraInfoVector? camInfoVector;

        public CameraInfoModel? cameraInfoModel;

        public Camera3DManager()
        {
            cam3d = new Gen3DCamera();
            camInfoVector = new CameraInfoVector();
            cameraInfoModel = new CameraInfoModel();
            currCamInfo = new CameraInfo();
        }

        // 单例模式，保证只有一个CameraManager实例
        public static Camera3DManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera3DManager();
                }
                return instance;
            }
        }

        // discover cameras
        public CameraInfoVector DiscoverCameras()
        {
            CameraInfoVector cameraInfos = new CameraInfoVector();
            try
            {
                if (cam3d == null)
                {
                    cam3d = new Gen3DCamera();
                }

                int ret = cam3d.cam.DiscoverCameras(cam3d.camInfoVector, 1000);
                if (cam3d.camInfoVector.Count() < 0 || CameraPro.AC_OK != ret)
                {
                    //CameraPro.DestoryCamera(cam3d.cam);
                    return cameraInfos;
                }
                else
                {
                    cameraInfos = cam3d.camInfoVector;
                }
                return cameraInfos;
            }
            catch (Exception ex)
            {
                return cameraInfos;
            }
        }

        public OkEyeCode SetCameraIP(string oldip, string newip)
        {
            try
            {
                if (cam3d == null)
                {
                    cam3d = new Gen3DCamera();
                }
                // 发现相机列表
                CameraInfoVector cameraInfos = DiscoverCameras();
                if (cameraInfos.Count() <= 0)
                {
                    return OkEyeCode.Failed;
                }

                // 查找对应ip的相机信息
                CameraInfo cameraInfo = new CameraInfo();
                for (int i = 0; i < cameraInfos.Count(); i++)
                {
                    if (cameraInfos[i].cameraIP == oldip)
                    {
                        cameraInfo = cameraInfos[i];
                        break;
                    }
                }
                if (cameraInfo.cameraIP != oldip)
                {
                    // 没有查找到对应ip的相机
                    return OkEyeCode.Failed;
                }

                cam3d.cam.SetCameraIP(cameraInfo, newip);

            }
            catch (Exception e)
            {
                    Console.WriteLine(e);
                    throw;
            }
            return OkEyeCode.Ok;
        }

        public OkEyeCode ConnectCamera(string ip)
        {
            try
            {
                if (cam3d == null)
                {
                    cam3d = new Gen3DCamera();
                }

                // 发现相机列表
                CameraInfoVector cameraInfos = DiscoverCameras();
                if (cameraInfos.Count() <= 0)
                {
                    cameraInfoModel.Status = "无相机";
                    return OkEyeCode.Failed;
                }

                // 查找对应ip的相机信息
                CameraInfo cameraInfo = new CameraInfo();
                for (int i = 0; i < cameraInfos.Count(); i++)
                {
                    if (cameraInfos[i].cameraIP == ip)
                    {
                        cameraInfo = cameraInfos[i];
                        break;
                    }
                }
                if(cameraInfo.cameraIP != ip)
                {
                    // 没有查找到对应ip的相机
                    cameraInfoModel.Status = "未连接";
                    return OkEyeCode.Failed;
                }
                if (cam3d.cam.Open(cameraInfo) != CameraPro.AC_OK)
                {
                    cameraInfoModel.Status = "未连接";
                    return OkEyeCode.Failed;
                }
                currCamInfo = cameraInfo;

                UpdateCameraInfoModel(); 
                return OkEyeCode.Ok;
            }
            catch (Exception ex)
            {
                return OkEyeCode.Failed;
            }
        }

        public OkEyeCode DisconnectCamera()
        {
            try
            {
                if (cam3d == null)
                {
                    return OkEyeCode.Failed;
                }
                
                cam3d.cam.Close(currCamInfo);
                CameraPro.DestoryCamera(cam3d.cam);
                cam3d = null;
                cameraInfoModel.Status = "未连接";
                return OkEyeCode.Ok;
            }
            catch (Exception ex)
            {
                return OkEyeCode.Failed;
            }
        }

        // Capture point cloud
        public OkEyeCode Capture(ref FrameData frameData)
        {
            try
            {
                if (cam3d == null)
                {
                    return OkEyeCode.Failed;
                }
                if(currCamInfo == null)
                {
                    return OkEyeCode.Failed;
                }
                CameraParam cameraParam = currCamInfo.camParam;
                Util tools = new Util();

                SetOutputSettings(ref currCamInfo);
                int ret = cam3d.cam.Capture(currCamInfo, frameData);
                if (ret != CameraPro.AC_OK)
                {
                    Console.ReadLine();
                    return OkEyeCode.Failed;
                }
                _frameData = (FrameData)frameData.Clone();
                return OkEyeCode.Ok;
            }
            catch (Exception ex)
            {
                return OkEyeCode.Failed;
            }
        }

        public OkEyeCode UpdateCameraInfoModel()
        {
            // 更新相机信息
            try
            {
                if (this.cam3d == null)
                {
                    return OkEyeCode.Failed;
                }

                if (currCamInfo == null)
                {
                    return OkEyeCode.Failed;
                }
                if (cameraInfoModel == null)
                {
                    return OkEyeCode.Failed;
                }
                cameraInfoModel.Band = "AinsCamera";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                cameraInfoModel.Pic = path + "data\\ains3dcam.png";
                cameraInfoModel.Status = "已连接";
                cameraInfoModel.CameraIP = currCamInfo.cameraIP;
                cameraInfoModel.UserIP = currCamInfo.userIP;
                cameraInfoModel.Serial = currCamInfo.serialNum;
                cameraInfoModel.MacAdress = currCamInfo.macAddr;
                cameraInfoModel.Name = currCamInfo.cameraName;
                // 获取曝光值
                float exposure = 0;
                if (cam3d.cam.GetValue(currCamInfo, "Exposure", ref exposure) == 0)
                {
                    cameraInfoModel.Exposure = exposure;
                }
                else
                {
                    cameraInfoModel.Exposure = 0;
                }
                // 设置增益
                float gain = 0;
                if (cam3d.cam.GetValue(currCamInfo, "Gain", ref gain) == 0)
                {
                    cameraInfoModel.Gain = gain;
                }
                else
                {
                    cameraInfoModel.Gain = 0;
                }

                cameraInfoModel.Model =  currCamInfo.cameraModel; 
                //cameraInfoModel.ScanMode = currCamInfo.moduleID
                cameraInfoModel.textureHeight = currCamInfo.camParam.textureHeight;
                cameraInfoModel.textureWidth = currCamInfo.camParam.textureWidth;
                cameraInfoModel.irHeight = currCamInfo.camParam.irHeight;
                cameraInfoModel.irWidth = currCamInfo.camParam.irWidth;
                cameraInfoModel.irPerNum = currCamInfo.camParam.irPerNum;

            }
            catch (Exception ex)
            {
                return OkEyeCode.Failed;
            }
            
            return OkEyeCode.Ok;
        }

        public void SetOutputSettings(ref CameraInfo cameraInfo)
        {
            if (cameraInfo.camParam.reconstructionType != Util.BINOCULAR_RECONSTRUCTION)
            {
                cameraInfo.outputSettings.sendDepthmap = true;
                cameraInfo.outputSettings.sendNormals = true;
                cameraInfo.outputSettings.sendPoint3D = true;
                cameraInfo.outputSettings.sendPointColor = false;
                cameraInfo.outputSettings.sendPointUV = true;
                cameraInfo.outputSettings.sendTexture = false;
                cameraInfo.outputSettings.sendTriangleIndices = true;
                cameraInfo.outputSettings.sendRemapTexture = true;
            }
            else
            {
                cameraInfo.outputSettings.sendDepthmap = true;
                cameraInfo.outputSettings.sendNormals = true;
                cameraInfo.outputSettings.sendPoint3D = true;
                cameraInfo.outputSettings.sendPointColor = true;
                cameraInfo.outputSettings.sendPointUV = true;
                cameraInfo.outputSettings.sendTexture = true;
                cameraInfo.outputSettings.sendTriangleIndices = true;
                cameraInfo.outputSettings.sendRemapTexture = true;
            }
        }

        public OkEyeCode SaveFrame(string path)
        {
            if (_frameData == null)
            {
                return OkEyeCode.FrameSaveError;
            }
            // 判断图像是否为空
            if (_frameData.textureSize <= 0 || _frameData.depthmapSize <= 0 || currCamInfo is null)
            {
                return OkEyeCode.FrameSaveError;
            }

            // 判断文件夹是否存在
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            unsafe
            {
                Util util = new Util();
                // 保存图像
                util.save_rgb(_frameData.texture, currCamInfo.camParam, path);
                // 保存深度图
                float[] depthmap = new float[_frameData.depthmapSize];
                for (int i = 0; i < _frameData.depthmapSize; i++)
                {
                    depthmap[i] = _frameData.depthmap[i];
                }
                util.save_deepmap(depthmap, currCamInfo.camParam, path);
                // 保存点云为tiff文件
                util.save_point2tiff(ref _frameData, currCamInfo.camParam, path);
                // 保存点云为ply文件
                util.save_point2ply(ref _frameData, path);
            }

            return 0;
        }


    }

}

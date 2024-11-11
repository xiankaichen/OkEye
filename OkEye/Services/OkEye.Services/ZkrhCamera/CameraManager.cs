using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gen3d;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace OK3DViewer
{
    // CameraInfoModel is a class that stores the camera information, and is used to display the camera information in the property grid
    // CameraInfoModel is Model class
    public class CameraInfoModel 
    {
        [Category("1设备参数"), PropertyOrder(11)]
        [DisplayName("名称"), ReadOnly(true)]
        public string Name { get; set; }

        [Category("1设备参数"), PropertyOrder(12)]
        [DisplayName("IP地址"), ReadOnly(true)]
        public string IP { get; set; }

        // 相机序号
        [Category("1设备参数"), PropertyOrder(13)]
        [DisplayName("相机序号"), ReadOnly(true)]
        public string Serial { get; set; }

        [Category("1设备参数"), PropertyOrder(14)]
        [DisplayName("MAC地址"), ReadOnly(true)]
        public string MacAdress { get; set; }

        // 设置曝光
        [Category("1设备参数"), PropertyOrder(15)]
        [DisplayName("曝光(ms)")]
        public string Exposure { get; set; }

        // 增益
        [Category("1设备参数"), PropertyOrder(16)]
        [DisplayName("增益")]
        public string Gain { get; set; }

        // 拍照模式，两种：高精度，快速，默认高精度，下拉列表
        [Category("1设备参数"), PropertyOrder(17)]
        [DisplayName("拍照模式")]
        public CameraMode CameMode { get; set; }

        // 图像宽度
        [Category("2图像参数"), PropertyOrder(11)]
        [DisplayName("图像宽度"), ReadOnly(true)]
        public int textureWidth { get; set; }

        // 图像高度
        [Category("2图像参数"), PropertyOrder(12)]
        [DisplayName("图像高度"), ReadOnly(true)]
        public int textureHeight { get; set; }

        // ir宽度
        [Category("2图像参数"), PropertyOrder(13)]
        [DisplayName("IR宽度"), ReadOnly(true)]
        public int irWidth { get; set; }

        // ir高度
        [Category("2图像参数"), PropertyOrder(14)]
        [DisplayName("IR高度"), ReadOnly(true)]
        public int irHeight { get; set; }

        // irPerNum
        [Category("2图像参数"), PropertyOrder(15)]
        [DisplayName("IRPerNum"), ReadOnly(true)]
        public int irPerNum { get; set; }

    }

    // 相机模式
    public enum CameraMode
    {
        高精度,
        快速
    }


    public class Camera3DManager
    {
        // CameraManager is a singleton class
        private static Camera3DManager? instance;
        // List of cameras
        private  Gen3DCamera? cam3d;
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

        public int SetCameraIP(string oldip, string newip)
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
                    return 0;
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
                    return 0;
                }

                cam3d.cam.SetCameraIP(cameraInfo, newip);

            }
            catch (Exception e)
            {
                    Console.WriteLine(e);
                    throw;
            }
            return 0;
        }

        public int ConnectCamera(string ip)
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
                    return 0;
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
                    return 0;
                }
                if (cam3d.cam.Open(cameraInfo) != CameraPro.AC_OK)
                {
                    return 0;
                }
                currCamInfo = cameraInfo;

                UpdateCameraInfoModel(); 
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DisconnectCamera()
        {
            try
            {
                if (cam3d == null)
                {
                    return 0;
                }
                CameraPro.DestoryCamera(cam3d.cam);
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Capture point cloud
        public int CapturePointCloud(ref FrameData frameData)
        {
            try
            {
                if (cam3d == null)
                {
                    return 0;
                }
                if(currCamInfo == null)
                {
                    return 0;
                }
                CameraParam cameraParam = currCamInfo.camParam;
                Util tools = new Util();

                SetOutputSettings(ref currCamInfo);
                int ret = cam3d.cam.Capture(currCamInfo, frameData);
                if (ret != CameraPro.AC_OK)
                {
                    Console.ReadLine();
                    return -1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateCameraInfoModel()
        {
            // 更新相机信息
            try
            {
                if (this.cam3d == null)
                {
                    return 0;
                }

                if (currCamInfo == null)
                {
                    return 0;
                }
                if (cameraInfoModel == null)
                {
                    return 0;
                }
                cameraInfoModel.IP = currCamInfo.cameraIP;
                cameraInfoModel.Serial = currCamInfo.serialNum;
                cameraInfoModel.MacAdress = currCamInfo.macAddr;
                cameraInfoModel.Name = "XK3DCamera9007";
                // 获取曝光值
                float exposure = 0;
                if (cam3d.cam.GetValue(currCamInfo, "Exposure", ref exposure) == 0)
                {
                    cameraInfoModel.Exposure = exposure.ToString();
                }
                else
                {
                    cameraInfoModel.Exposure = "0";
                }
                // 设置增益
                float gain = 0;
                if (cam3d.cam.GetValue(currCamInfo, "Gain", ref gain) == 0)
                {
                    cameraInfoModel.Gain = gain.ToString();
                }
                else
                {
                    cameraInfoModel.Gain = "0";
                }
                cameraInfoModel.textureHeight = currCamInfo.camParam.textureHeight;
                cameraInfoModel.textureWidth = currCamInfo.camParam.textureWidth;
                cameraInfoModel.irHeight = currCamInfo.camParam.irHeight;
                cameraInfoModel.irWidth = currCamInfo.camParam.irWidth;

            }
            catch (Exception ex)
            {
                return 0;
            }

            


            return 0;
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


    }

}

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

            uint texturesize = framedata.textureSize;

            unsafe
            {
                Util util = new Util();
                Mat texturemat = util.textureByte2Mat(framedata.texture, camera3DManager.currCamInfo.camParam);
                frame.image = texturemat;
            }
           

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

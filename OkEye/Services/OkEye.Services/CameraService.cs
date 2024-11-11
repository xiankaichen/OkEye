using System;
using System.Collections.Generic;
using System.Text;
using OK3DViewer;
using OkEye.Services.Interfaces;
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

        public int Capture()
        {
            return 0;
        }

        public int SetCameraIP(string oldip, string newip)
        {
            camera3DManager.SetCameraIP(oldip, newip);
            return 0;
        }

        public int ConnectCamera(CameraInfoModel cameraInfo)
        {
            return 0;
        }

        public int DisconnectCamera(CameraInfoModel cameraInfo)
        {
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
    }
}

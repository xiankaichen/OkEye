using System;
using System.Collections.Generic;
using System.Text;

namespace OkEye.Services.Interfaces
{
    public interface ICameraService
    {
        List<CameraInfoModel> DiscoveryDeviceList();

        int ConnectCamera(CameraInfoModel cameraInfo);

        int DisconnectCamera(CameraInfoModel cameraInfo);

        int SetCameraIP(string oldip, string newip);
        int Capture();
    }
}

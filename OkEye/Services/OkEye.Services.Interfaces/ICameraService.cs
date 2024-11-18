using System;
using System.Collections.Generic;
using System.Text;

namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// 相机服务接口
    /// </summary>
    public interface ICameraService
    {
        /// <summary>
        /// 发现设备列表
        /// </summary>
        /// <returns></returns>
        List<CameraInfoModel> DiscoveryDeviceList();

        /// <summary>
        /// 连接相机
        /// </summary>
        /// <param name="cameraInfo"></param>   相机信息
        /// <returns></returns>
        int ConnectCamera(CameraInfoModel cameraInfo);

        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="cameraInfo"></param> 相机信息
        /// <returns></returns>
        int DisconnectCamera(CameraInfoModel cameraInfo);
        
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        int Capture(ref OkFrameData frame);

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        CameraInfoModel GetCameraInfo();

        /// <summary>
        /// 设置相机IP
        /// </summary>
        /// <param name="oldip"></param>
        /// <param name="newip"></param>
        /// <returns></returns>
        int SetCameraIP(string oldip, string newip);

    }
}

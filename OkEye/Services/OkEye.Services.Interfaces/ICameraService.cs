using OkEye.Core;
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
        OkEyeCode ConnectCamera(CameraInfoModel cameraInfo);

        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="cameraInfo"></param> 相机信息
        /// <returns></returns>
        OkEyeCode DisconnectCamera(CameraInfoModel cameraInfo);

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        OkEyeCode Capture(ref OkFrameData frame);

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        CameraInfoModel GetCameraInfo();

        /// <summary>
        /// 设置相机参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        OkEyeCode SetCameraParam(CameraInfoModel  param);

        /// <summary>
        /// 保存帧
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        OkEyeCode SaveFrame(string path);

        /// <summary>
        /// 设置相机IP
        /// </summary>
        /// <param name="oldip"></param>
        /// <param name="newip"></param>
        /// <returns></returns>
        OkEyeCode SetCameraIP(string oldip, string newip);

    }
}

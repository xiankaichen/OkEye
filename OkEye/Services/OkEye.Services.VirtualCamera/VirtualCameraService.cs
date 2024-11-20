using System;
using System.Collections.Generic;
using System.Text;
using OkEye.Services.Interfaces;
using OpenCvSharp;
using CameraInfoModel = OkEye.Services.Interfaces.CameraInfoModel;

namespace OkEye.Services.VirtualCamera
{
    /// <summary>
    /// 相机服务
    /// </summary>
    public class VirtualCameraService : ICameraService
    {

        VirtualCamera camera3DManager = new VirtualCamera();
        /// <summary>
        /// 构造函数
        /// </summary>
        public VirtualCameraService()
        {

        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="frame"></param>  帧数据
        /// <returns></returns>
        public int Capture(ref OkFrameData frame)
        {
            if (0 != camera3DManager.Capture(ref frame))
                return -1;
            return 0;
        }


        /// <summary>
        /// 设置相机IP
        /// </summary>
        /// <param name="oldip"></param>
        /// <param name="newip"></param>
        /// <returns></returns>
        public int SetCameraIP(string oldip, string newip)
        {
            return camera3DManager.SetCameraIP(oldip, newip);
        }

        /// <summary>
        /// 连接相机
        /// </summary>
        /// <param name="cameraInfo"></param>
        /// <returns></returns>
        public int ConnectCamera(CameraInfoModel cameraInfo)
        {
            int flag =  camera3DManager.ConnectCamera(cameraInfo);
            if (flag == 0)
                return 0;
            else
                return -1;
        }

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        public CameraInfoModel GetCameraInfo()
        {
            return camera3DManager.GetCameraInfo();
        }

        public int SetCameraParam(CameraInfoModel param)
        {
            return SetCameraParam(param);
        }

        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="cameraInfo"></param>   相机信息
        /// <returns></returns>
        public int DisconnectCamera(CameraInfoModel cameraInfo)
        {
            // 断开相机
            int flag = camera3DManager.DisconnectCamera(cameraInfo);
            if (flag == 0)
                return 0;
            else
                return -1;
            return 0;
        }

        /// <summary>
        /// 发现设备列表
        /// </summary>
        /// <returns></returns>
        public List<CameraInfoModel> DiscoveryDeviceList()
        {
            List<CameraInfoModel> list  = camera3DManager.DiscoveryDeviceList();
            return list;
        }
    }
}

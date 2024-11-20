using System;
using System.Collections.Generic;
using System.Text;
using OkEye.Services.Interfaces;
using OpenCvSharp;

namespace OkEye.Services.VirtualCamera
{
    public class VirtualCamera
    {
        private CameraInfoModel camerainfo;
        private OkFrameData framedata;
        private List<CameraInfoModel> camerainfolist;
        public VirtualCamera()
        {
            camerainfo = new CameraInfoModel();
            camerainfolist.Add(camerainfo);

            framedata = new OkFrameData();
            camerainfolist = new List<CameraInfoModel>();
        }

        public List<CameraInfoModel> DiscoveryDeviceList()
        {
            if (camerainfolist.Count == 0)
            {
                camerainfolist.Add(new CameraInfoModel());
            }
            return camerainfolist;
        }

        public int ConnectCamera(ref CameraInfoModel camerainfo)
        {
            // TODO: Connect to camera
            // 判断列表中是否有相机
            foreach (var camera in DiscoveryDeviceList())
            {
                if (camera.CameraIP == camerainfo.CameraIP)
                {
                    camerainfo = camera;
                    camerainfo.Status = "已连接";
                    break;
                }
            }
            if(camerainfo.Status == "未连接")
            {
                return -1;
            }
            return 0;
        }

        public int DisconnectCamera(CameraInfoModel camerainfo) {
            foreach (var camera in DiscoveryDeviceList())
            {
                if (camera.CameraIP == camerainfo.CameraIP)
                {
                    camerainfo = camera;
                    camerainfo.Status = "未连接";
                    break;
                }
            }
            if (camerainfo.Status == "已连接")
            {
                return -1;
            }
            return 0;
        }
        public int Capture(ref OkFrameData framedata)
        {
            // 如果相机未连接，返回-1
            if (camerainfo.Status == "未连接")
            {
                return -1;
            }

            framedata.image = Cv2.ImRead("data/image.bmp");
            framedata.depth = Cv2.ImRead("data/depth.bmp");
            framedata.cloud = Cv2.ImRead("data/cloud.tif");
            framedata.cloudSize = 10000;
            return 0;
        }

        public int SetCameraIP(string oldip, string newip)
        {
            // 从camerainfolist中找到对应的相机，并修改
            foreach (var camera in camerainfolist)
            {
                if (camera.CameraIP == oldip)
                {
                    camera.CameraIP = newip;
                    break;
                }
            }
            return 0;
        }

        public CameraInfoModel GetCameraInfo()
        {
            // 如果相机未连接，返回空
            if (camerainfo.Status == "未连接")
            {
                return null;
            }
            return camerainfo;
        }

        public int SetCameraParam(CameraInfoModel param)
        {
            if(camerainfo.Status == "未连接")
            {
                return -1;
            }
            camerainfo = param;
            return 0;
        }


    }
}

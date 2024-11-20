using System;
using System.Collections.Generic;
using System.Text;
using BitMiracle.LibTiff.Classic;
using OkEye.Services.Interfaces;
using OpenCvSharp;

namespace OkEye.Services.VirtualCamera
{
    public class VirtualCamera
    {
        private CameraInfoModel camerainfo;                     // 相机信息
        private OkFrameData framedata;                              // 帧数据
        private List<CameraInfoModel> camerainfolist;       // 相机列表

        /// <summary>
        /// 构造函数
        /// </summary>
        public VirtualCamera()
        {
            camerainfo = new CameraInfoModel(model: "CS-虚拟相机", irHeight: 1024, irWidth: 1280,
                textureHeight: 2280, textureWidth: 3000);
            camerainfolist = new List<CameraInfoModel>();
            camerainfolist.Add(camerainfo);

            framedata = new OkFrameData();
        }

        /// <summary>
        /// 发现设备列表
        /// </summary>
        /// <returns></returns>
        public List<CameraInfoModel> DiscoveryDeviceList()
        {
            if (camerainfolist.Count == 0)
            {
                camerainfolist.Add(new CameraInfoModel());
            }
            return camerainfolist;
        }

        /// <summary>
        /// 连接相机
        /// </summary>
        /// <param name="incamerainfo"></param>   相机信息
        /// <returns></returns>
        public int ConnectCamera(CameraInfoModel incamerainfo)
        {
            // CameraIP和UserIP的子网段如果不相同，那么返回
            string[] cameraip = incamerainfo.CameraIP.Split('.');
            string[] userip = incamerainfo.UserIP.Split('.');
            if (cameraip[0] != userip[0] || cameraip[1] != userip[1] || cameraip[2] != userip[2])
            {
                return -1;
            }

            // 判断列表中是否有相机
            foreach (var camera in DiscoveryDeviceList())
            {
                if (camera.CameraIP == incamerainfo.CameraIP)
                {
                    camerainfo = camera;
                    camerainfo.Status = "已连接";
                    break;
                }
            }
            if (camerainfo.Status == "未连接")
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        ///  发现设备列表
        /// </summary>
        /// <param name="incamerainfo"></param> 相机信息
        /// <returns></returns>
        public int DisconnectCamera(CameraInfoModel incamerainfo)
        {
            foreach (var camera in DiscoveryDeviceList())
            {
                if (camera.CameraIP == incamerainfo.CameraIP)
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

        /// <summary>
        /// 捕获图像
        /// </summary>
        /// <param name="framedata"></param>    帧数据
        /// <returns></returns>
        public int Capture(ref OkFrameData framedata)
        {
            // 如果相机未连接，返回-1
            if (camerainfo.Status == "未连接")
            {
                return -1;
            }

            // 获取当前exe所在路径
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            framedata.image = Cv2.ImRead("data/image.bmp");
            framedata.depth = Cv2.ImRead("data/depth.bmp");
            framedata.cloud = readTiff2Mat("data/cloud.tiff");
            framedata.cloudSize = 10000;
            return 0;
        }

        /// <summary>
        /// 读取tiff文件
        /// </summary>
        /// <param name="path"></param> 文件路径
        /// <returns></returns>
        private Mat readTiff2Mat(string path)
        {
            Mat image = new Mat();
            // 使用libtiff 读取tif文件
            using (Tiff tif = Tiff.Open(path, "r"))
            {
                if (tif == null)
                {
                    return null;
                }

                int height = tif.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                int width = tif.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                int samplesPerPixel = tif.GetField(TiffTag.SAMPLESPERPIXEL)[0].ToInt();
                int bitsPerSample = tif.GetField(TiffTag.BITSPERSAMPLE)[0].ToInt();
                int photo = tif.GetField(TiffTag.PHOTOMETRIC)[0].ToInt();
                int stride = width * samplesPerPixel * 4;
                byte[] scanline = new byte[stride];
                image = new Mat(height, width, MatType.CV_32FC3);
                // 将点云存入Mat
                for (int i = 0; i < height; i++)
                {
                    tif.ReadScanline(scanline, i);
                    float[] floatArr = new float[scanline.Length / 4];
                    Buffer.BlockCopy(scanline, 0, floatArr, 0, scanline.Length);
                    for (int j = 0; j < width; j++)
                    {
                        Vec3f pixel = new Vec3f();
                        pixel[0] = floatArr[3 * j];
                        pixel[1] = floatArr[j * 3 + 1];
                        pixel[2] = floatArr[j * 3 + 2];
                        image.Set<Vec3f>(i, j, pixel);
                    }
                }
            }
            return image;
        }

        /// <summary>
        /// 设置相机IP
        /// </summary>
        /// <param name="oldip"></param>
        /// <param name="newip"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        public CameraInfoModel GetCameraInfo()
        {
            // 如果相机未连接，返回空
            return camerainfo;
        }

        /// <summary>
        /// 设置相机参数
        /// </summary>
        /// <param name="param"></param>    相机参数
        /// <returns></returns>
        public int SetCameraParam(CameraInfoModel param)
        {
            if (camerainfo.Status == "未连接")
            {
                return -1;
            }
            camerainfo = param;
            return 0;
        }
    }
}

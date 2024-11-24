using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using BitMiracle.LibTiff.Classic;
using OkEye.Core;
using OkEye.Services.Interfaces;
using OpenCvSharp;

namespace OkEye.Services.VirtualCamera
{
    public class VirtualCamera
    {
        private CameraInfoModel camerainfo;                     // 相机信息
        private OkFrameData _frameData;                              // 帧数据
        public OkFrameData FrameData { get { return _frameData; } }
        private List<CameraInfoModel> camerainfolist;       // 相机列表

        /// <summary>
        /// 构造函数
        /// </summary>
        public VirtualCamera()
        {
            // 程序所在目
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string picpath = path + "data\\virtual3dcam.png";
            camerainfo = new CameraInfoModel(band:"VirtualCamera", pic: picpath, model: "CS-虚拟相机", irHeight: 1024, irWidth: 1280,
                textureHeight: 2280, textureWidth: 3000);
            camerainfolist = new List<CameraInfoModel>();
            camerainfolist.Add(camerainfo);

            _frameData = new OkFrameData();
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
        public OkEyeCode ConnectCamera(CameraInfoModel incamerainfo)
        {
            // CameraIP和UserIP的子网段如果不相同，那么返回
            string[] cameraip = incamerainfo.CameraIP.Split('.');
            string[] userip = incamerainfo.UserIP.Split('.');
            if (cameraip[0] != userip[0] || cameraip[1] != userip[1] || cameraip[2] != userip[2])
            {
                return OkEyeCode.Failed;
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
                return OkEyeCode.Failed;
            }
            return OkEyeCode.Ok;
        }

        /// <summary>
        ///  发现设备列表
        /// </summary>
        /// <param name="incamerainfo"></param> 相机信息
        /// <returns></returns>
        public OkEyeCode DisconnectCamera(CameraInfoModel incamerainfo)
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
                return OkEyeCode.Failed;
            }
            return OkEyeCode.Ok;
        }

        /// <summary>
        /// 捕获图像
        /// </summary>
        /// <param name="framedata"></param>    帧数据
        /// <returns></returns>
        public OkEyeCode Capture(ref OkFrameData framedata)
        {
            // 如果相机未连接，返回-1
            if (camerainfo.Status == "未连接")
            {
                return OkEyeCode.Failed;
            }

            // 获取当前exe所在路径
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            _frameData.image = Cv2.ImRead("data/image.bmp");
            _frameData.depth = Cv2.ImRead("data/depth.bmp");
            _frameData.cloud = readTiff2Mat("data/cloud.tiff");
            _frameData.cloudSize = 10000;

            framedata = _frameData;
            return OkEyeCode.Ok;
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
        public OkEyeCode SetCameraIP(string oldip, string newip)
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
            return OkEyeCode.Ok;
        }

        public OkEyeCode SaveFrame(string path)
        {
            // 判断图像是否为空
            if (_frameData.image.Empty() || _frameData.depth.Empty() || _frameData.cloud.Empty())
            {
                return OkEyeCode.Failed;
            }
            // 创建目录path
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            // 保存图像
            Cv2.ImWrite(path + "image.bmp", _frameData.image);
            // 保存深度图
            Cv2.ImWrite(path + "depth.bmp", _frameData.depth);

            // 保存点云Mat 为tiff文件
            using (Tiff tif = Tiff.Open(path + "cloud.tiff", "w"))
            {
                if (tif == null)
                {
                    return OkEyeCode.Failed;
                }

                tif.SetField(TiffTag.IMAGEWIDTH, _frameData.cloud.Cols);
                tif.SetField(TiffTag.IMAGELENGTH, _frameData.cloud.Rows);
                tif.SetField(TiffTag.BITSPERSAMPLE, 32);
                tif.SetField(TiffTag.COMPRESSION, Compression.NONE);
                tif.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                tif.SetField(TiffTag.ORIENTATION, BitMiracle.LibTiff.Classic.Orientation.TOPLEFT);
                tif.SetField(TiffTag.SAMPLESPERPIXEL, 3);
                tif.SetField(TiffTag.ROWSPERSTRIP, 1);
                tif.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                tif.SetField(TiffTag.XRESOLUTION, 300);
                tif.SetField(TiffTag.YRESOLUTION, 300);
                tif.SetField(TiffTag.SAMPLEFORMAT, SampleFormat.IEEEFP);
                tif.SetField(TiffTag.RESOLUTIONUNIT, 2);

                byte[] scanline = new byte[_frameData.cloud.Cols * 3 * 4];
                byte[] imagedata = new byte[_frameData.cloud.Rows * _frameData.cloud.Cols * 3 * 4];
                // 将Mat转为byte数组
                for (int i = 0; i < _frameData.cloud.Rows; i++)
                {
                    for (int j = 0; j < _frameData.cloud.Cols; j++)
                    {
                        Vec3f point = _frameData.cloud.At<Vec3f>(i, j);
                        Buffer.BlockCopy(BitConverter.GetBytes(point[0]), 0, imagedata, (i * _frameData.cloud.Cols + j) * 3 * 4, 4);
                        Buffer.BlockCopy(BitConverter.GetBytes(point[1]), 0, imagedata, (i * _frameData.cloud.Cols + j) * 3 * 4 + 4, 4);
                        Buffer.BlockCopy(BitConverter.GetBytes(point[2]), 0, imagedata, (i * _frameData.cloud.Cols + j) * 3 * 4 + 8, 4);
                    }
                }

                for (int i = 0; i < _frameData.cloud.Rows; i++)
                {
                    Buffer.BlockCopy(imagedata, i * _frameData.cloud.Cols * 3 * 4, scanline, 0,
                        _frameData.cloud.Cols * 3 * 4);
                    tif.WriteScanline(scanline, i);
                }

                tif.FlushData();
                tif.Close();
                GC.Collect();
            }

            // Mat 存为ply格式
            string plypath = path + "cloud.ply";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(plypath))
            {
                file.WriteLine("ply");
                file.WriteLine("format ascii 1.0");
                file.WriteLine("element vertex " + _frameData.cloud.Rows * _frameData.cloud.Cols);
                file.WriteLine("property float x");
                file.WriteLine("property float y");
                file.WriteLine("property float z");
                file.WriteLine("end_header");
                for (int i = 0; i < _frameData.cloud.Rows; i++)
                {
                    for (int j = 0; j < _frameData.cloud.Cols; j++)
                    {
                        Vec3f point = _frameData.cloud.At<Vec3f>(i, j);
                        file.WriteLine(point[0] + " " + point[1] + " " + point[2]);
                    }
                }
            }
            return OkEyeCode.Ok;
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
        public OkEyeCode SetCameraParam(CameraInfoModel param)
        {
            if (camerainfo.Status == "未连接")
            {
                return OkEyeCode.Failed;
            }
            camerainfo = param;
            return OkEyeCode.Ok;
        }
    }
}

using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using OpenCvSharp;

namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// 帧数据
    /// </summary>
    public class OkFrameData
    {
        public Mat image;   // 图像数据
        public Mat depth;   // 深度数据
        public Mat cloud;   // 点云数据
        public int cloudSize;   // 点云数据大小

        public OkFrameData()
        {
            image = new Mat(2280,3000,MatType.CV_8UC3,255);
            depth = new Mat(1024,1280,MatType.CV_32FC1,0);
            cloud = new Mat(1024,1280,MatType.CV_32FC3,0);
            cloudSize = 0;
        }
    }
}
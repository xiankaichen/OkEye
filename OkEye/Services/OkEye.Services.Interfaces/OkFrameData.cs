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

    }
}
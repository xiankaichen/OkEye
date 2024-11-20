using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using OpenCvSharp;

namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// ֡����
    /// </summary>
    public class OkFrameData
    {
        public Mat image;   // ͼ������
        public Mat depth;   // �������
        public Mat cloud;   // ��������
        public int cloudSize;   // �������ݴ�С

        public OkFrameData()
        {
            image = new Mat(2280,3000,MatType.CV_8UC3,255);
            depth = new Mat(1024,1280,MatType.CV_32FC1,0);
            cloud = new Mat(1024,1280,MatType.CV_32FC3,0);
            cloudSize = 0;
        }
    }
}
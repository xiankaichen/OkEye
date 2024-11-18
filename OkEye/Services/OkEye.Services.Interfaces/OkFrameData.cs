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

    }
}
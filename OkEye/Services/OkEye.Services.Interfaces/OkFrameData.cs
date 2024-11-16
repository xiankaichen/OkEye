using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using OpenCvSharp;

namespace OkEye.Services.Interfaces
{
    public class OkFrameData
    {
        public Mat image;
        public Mat depth;
        public Mat cloud;
        public int cloudSize;

    }
}
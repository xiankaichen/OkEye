using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using BitMiracle.LibTiff.Classic;
using System.Threading;

namespace gen3d
{
    public class Util
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        public const int BINOCULAR_RECONSTRUCTION    = 0;  // 双目重建
        public const int MONO_BINOCULAR_FUSION       = 1;  // 单双目融合
        public const int MONOCULAR_RECONSTRUCTION    = 2;  // 纯单目重建

        public Util() {
        }

        //FrameData深拷贝
        public void deep_copy_frameData(ref FrameData destFrameData, FrameData sourceFrameData)
        {
            destFrameData = (FrameData)sourceFrameData.Clone();
        }

        ~Util() { }

        // 将点云转换到RGB大小，坐标系为左相机的坐标系,参考samples中的CalibrationParams
        // Convert the point cloud to RGB size, with the coordinate system of the left camera, referring to CalibrationParams in samples
        public unsafe int GetPointsByRGB(ref FrameData frameData, ref CameraParam camParam, ref Mat outPoints)
        {
            var point3D = frameData.point3D;
            var pointUV = frameData.pointUV;
            int width = camParam.irWidth;
            int height = camParam.irHeight;
            int textureWidth = camParam.textureWidth;
            int textureHeight = camParam.textureHeight;

            if (point3D == null || pointUV == null)
            {
                return -1;
            }

            Mat pointMat = new Mat(textureHeight, textureWidth, MatType.CV_32FC3, new Scalar(0));
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    int idx = r * width + c;

                    int x = (int)Math.Round((1 - pointUV[idx * 2 + 1]) * textureHeight);
                    int y = (int)Math.Round(pointUV[idx * 2 + 0] * textureWidth);
                    if (x < 0 || x >= textureHeight || y < 0 || y >= textureWidth)
                        continue;

                    Vec3f pixel = pointMat.At<Vec3f>(x, y);
                    pixel[0] = point3D[3 * idx];
                    pixel[1] = point3D[3 * idx + 1];
                    pixel[2] = point3D[3 * idx + 2];
                    pointMat.Set<Vec3f>(x, y, pixel);
                }
            }

            outPoints = pointMat;
            return 0;
        }

        // 将点云和深度数据转换到RGB坐标系下,参考samples中的CalibrationParams
        // Convert point cloud and depth data to RGB coordinate system.Please refer to CalibrationParams in samples.
        public unsafe int GetPointsByRGBWithTransformation(ref FrameData frameData, ref CameraParam camParam, ref DoubleVector cameraExtrinsic, ref Mat outPoints, ref Mat outDepth)
        {
            var point3D = frameData.point3D;
            var pointUV = frameData.pointUV;
            int width = camParam.irWidth;
            int height = camParam.irHeight;
            int textureWidth = camParam.textureWidth;
            int textureHeight = camParam.textureHeight;

            if (point3D == null || pointUV == null)
            {
                return -1;
            }

            Mat pointCloudTransformMatrix = new Mat(4, 4, MatType.CV_64FC1, new Scalar(0));
            for (int i = 0; i < pointCloudTransformMatrix.Rows; i++)
            {
                for (int j = 0; j < pointCloudTransformMatrix.Cols; j++)
                {
                    pointCloudTransformMatrix.Set<double>(i, j, cameraExtrinsic[i * pointCloudTransformMatrix.Cols + j]);
                }
            }
            Mat tempPoint = new Mat(4, 1, MatType.CV_64FC1, new Scalar(1));
            Mat tempResult = new Mat(4, 1, MatType.CV_64FC1, new Scalar(0));

            Mat pointMat = new Mat(textureHeight, textureWidth, MatType.CV_32FC3, new Scalar(0));
            Mat pointDepth = new Mat(textureHeight, textureWidth, MatType.CV_32FC1, new Scalar(0));

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    int idx = r * width + c;

                    int x = (int)Math.Round((1 - pointUV[idx * 2 + 1]) * textureHeight);
                    int y = (int)Math.Round(pointUV[idx * 2 + 0] * textureWidth);
                    if (x < 0 || x >= textureHeight || y < 0 || y >= textureWidth)
                        continue;
                    tempPoint.Set<double>(0, 0, (double)point3D[3 * idx]);
                    tempPoint.Set<double>(1, 0, (double)point3D[3 * idx + 1]);
                    tempPoint.Set<double>(2, 0, (double)point3D[3 * idx + 2]);
                    tempPoint.Set<double>(3, 0, 1);

                    tempResult = pointCloudTransformMatrix * tempPoint;
                    Vec3f pixel = pointMat.At<Vec3f>(x, y);
                    pixel[0] = (float)tempResult.At<double>(0, 0);
                    pixel[1] = (float)tempResult.At<double>(1, 0);
                    pixel[2] = (float)tempResult.At<double>(2, 0);
                    pointMat.Set<Vec3f>(x, y, pixel);

                    pointDepth.Set<float>(x, y, (float)tempResult.At<double>(2, 0));
                }
            }

            outPoints = pointMat;
            outDepth = pointDepth;
            return 0;
        }

        public int save_deepmap(float[] deepmap, CameraParam camparam, string rootPath)
        {
            int width;
            int height;
            if (camparam.depthType == 1)
            {
                width = camparam.textureWidth;
                height = camparam.textureHeight;
            }
            else
            {
                width = camparam.irWidth;
                height = camparam.irHeight;
            }

            Scalar s = new Scalar(0, 0, 0);
            Mat deepmat = new Mat(height, width, MatType.CV_8UC1, s);

            float max = -555555, min = 555555;
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (deepmap[i * width + j] != 0)
                    {
                        if (max < deepmap[i * width + j])
                        {
                            max = deepmap[i * width + j];
                        }
                        if (min > deepmap[i * width + j])
                        {
                            min = deepmap[i * width + j];
                        }
                    }
                }
            }

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (deepmap[i * width + j] == 0)
                    {
                        deepmat.Set<byte>(i, j, (byte)255);
                    }
                    else
                    {
                        byte value = (byte)((deepmap[i * width + j] - min) * 255 / (max - min));
                        deepmat.Set<byte>(i, j, value);
                    }
                }
            }

            string name = rootPath + "\\depth.bmp";
            string name_gray = rootPath + "\\gray_depth.bmp";

            Mat color = new Mat();

            Cv2.ApplyColorMap(deepmat, color, ColormapTypes.Rainbow);
            Cv2.ImWrite(name, color);
            Cv2.ImWrite(name_gray, deepmat);

            return 0;
        }

        unsafe public int save_deepmap2tiff(float* framedeepmap, CameraParam camparam, string rootPath)
        {
            int width;
            int height;
            if (camparam.depthType == 1)
            {
                width = camparam.textureWidth;
                height = camparam.textureHeight;
            }
            else
            {
                width = camparam.irWidth;
                height = camparam.irHeight;
            }
            float[] deepmap = new float[width * height];
            Marshal.Copy((IntPtr)framedeepmap, deepmap, 0, width * height);
            string tiffPath = rootPath + "/depth_t.tiff";
            using (Tiff tif = Tiff.Open(tiffPath, "w"))
            {
                if (tif == null)
                {
                    Console.WriteLine("tiff file {0} create failure", tiffPath);
                    return -1;
                }

                tif.SetField(TiffTag.IMAGEWIDTH, width);
                tif.SetField(TiffTag.IMAGELENGTH, height);
                tif.SetField(TiffTag.BITSPERSAMPLE, 32);
                tif.SetField(TiffTag.COMPRESSION, Compression.NONE);
                tif.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                tif.SetField(TiffTag.ORIENTATION, BitMiracle.LibTiff.Classic.Orientation.TOPLEFT);
                tif.SetField(TiffTag.ROWSPERSTRIP, 1);
                tif.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                tif.SetField(TiffTag.XRESOLUTION, 300);
                tif.SetField(TiffTag.YRESOLUTION, 300);
                //tif.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                tif.SetField(TiffTag.SAMPLEFORMAT, SampleFormat.IEEEFP);
                tif.SetField(TiffTag.RESOLUTIONUNIT, 2);

                byte[] bs = deepmap.SelectMany(x => BitConverter.GetBytes(x)).ToArray();
                int bufsize = width * 1 * 32 / 8;
                int len = 0;
                byte[] buf = new byte[bufsize];
                for (int s = 0; s < height; s++)
                {
                    Buffer.BlockCopy(bs, len, buf, 0, bufsize);
                    len += bufsize;
                    tif.WriteRawStrip(s, buf, bufsize);
                    Array.Clear(buf, 0, bufsize);
                }

                tif.FlushData();
                tif.Close();
            }

            return 0;
        }

        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            int size = bytes.Length;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return buffer;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        unsafe public int save_rgb(byte* rgb, CameraParam camparam, string rootPath)
        {
            int length = camparam.textureWidth * camparam.textureHeight * 3;
            int width = camparam.textureWidth;
            int height = camparam.textureHeight;
            string savePath = rootPath + "\\image.bmp";

            Scalar s = new Scalar(0, 0, 0);
            Mat matpic = new Mat(height, width, MatType.CV_8UC3, s);

            IntPtr mat_p = matpic.Ptr(0);
            byte* bp = (byte*)mat_p;

            for (int j = 0; j < height * width * 3; ++j)
            {
                bp[j] = (byte)rgb[j];
            }

            Cv2.ImWrite(savePath, matpic);

            return 0;
        }

        unsafe public Mat textureByte2Mat(byte* rgb, CameraParam camparam)
        {
            int length = camparam.textureWidth * camparam.textureHeight * 3;
            int width = camparam.textureWidth;
            int height = camparam.textureHeight;

            Scalar s = new Scalar(0, 0, 0);
            Mat matpic = new Mat(height, width, MatType.CV_8UC3, s);

            IntPtr mat_p = matpic.Ptr(0);
            byte* bp = (byte*)mat_p;

            for (int j = 0; j < height * width * 3; ++j)
            {
                bp[j] = (byte)rgb[j];
            }

            return matpic;
        }

        unsafe public int save_rgb_align_depth(byte* rgb, ref FrameData frameData, CameraParam camparam, string rootPath)
        {
            int ir_width = camparam.irWidth;
            int ir_height = camparam.irHeight;
            int rgb_width = camparam.textureWidth;
            int rgb_height = camparam.textureHeight;

            Scalar s = new Scalar(0, 0, 0);
            Mat align = new Mat(ir_height, ir_width, MatType.CV_8UC3, s);

            IntPtr mat_p = align.Ptr(0);
            byte* bp = (byte*)mat_p;
            for (int i = 0; i < ir_height; i++)
            {
                for (int j = 0; j < ir_width; j++)
                {
                    int ir_index = ir_width * i + j;
                    float rgb_u = frameData.pointUV[2 * ir_index + 0];
                    float rgb_v = frameData.pointUV[2 * ir_index + 1];
                    int rgb_index = (int)(rgb_u * rgb_width + (1 - rgb_v) * rgb_height * rgb_width);//x,y坐标与u,v坐标沿x轴对称

                    if (rgb_index >= rgb_height * rgb_width)
                    {
                        continue;
                    }

                    bp[3 * ir_index + 0] = rgb[3 * rgb_index + 0];
                    bp[3 * ir_index + 1] = rgb[3 * rgb_index + 1];
                    bp[3 * ir_index + 2] = rgb[3 * rgb_index + 2];
                }
            }

            string savepath = rootPath + "/align.bmp";
            Cv2.ImWrite(savepath, align);
            return 0;
        }

        unsafe public int save_ir(byte* ir, CameraParam camparam, string rootPath, bool isRemapTexture)
        {
            byte* tmp = ir;
            int width = camparam.irWidth;
            int height = camparam.irHeight;
            int perCount = camparam.irPerNum;
            int pixelBytes = camparam.pixelBytes;
            int lrMultiple = camparam.reconstructionType == MONOCULAR_RECONSTRUCTION ? 1 : 2;

            char[] img_name = new char[50];
            for (int i = 0; i < perCount * lrMultiple; ++i)
            {
                Array.Clear(img_name, 0, img_name.Length);
                string imgLeftName = string.Format(pixelBytes == 1 ? "/L{0:d}.bmp" : "/L{0:d}.tiff", i + 1);
                string imgRightName = string.Format(pixelBytes == 1 ? "/R{0:d}.bmp" : "/R{0:d}.tiff", i - perCount + 1);
                if (isRemapTexture)
                {
                    perCount = 2;
                    imgLeftName = string.Format(pixelBytes == 1 ? "/remap_L{0:d}.bmp" : "/remap_L{0:d}.tiff", i + 1);
                    imgRightName = string.Format(pixelBytes == 1 ? "/remap_R{0:d}.bmp" : "/remap_R{0:d}.tiff", i - perCount + 1);
                }
                string savePath = rootPath + imgLeftName;
                if (lrMultiple == 2)
                {
                    if (i > perCount - 1)
                    {
                        savePath = rootPath + imgRightName;
                    }
                }
                Scalar s = new Scalar(0, 0, 0);
                Mat matpic = new Mat(height, width, pixelBytes == 1 ? (MatType)MatType.CV_8UC1 : (MatType)MatType.CV_16U, s);
                byte* bp = (byte*)matpic.Ptr(0);
                CopyMemory((IntPtr)bp, (IntPtr)tmp, (uint)(height * width * pixelBytes));
                tmp += height * width * pixelBytes;
                Cv2.ImWrite(savePath, matpic);
            }

            return 0;
        }

        public int create_outdir(ref string rootPath)
        {
            string exePath = ".";
            string firstDir = exePath + "/3DRecon";
            isOutDirExist(firstDir);
            string secondDir = firstDir + "/" + get_current_date();
            isOutDirExist(secondDir);

            string thirdDir = secondDir + "/" + get_time_of_day();
            isOutDirExist(thirdDir);

            string cameraPath = thirdDir;

            isOutDirExist(cameraPath);
            rootPath = cameraPath;
            return 0;
        }

        public bool isOutDirExist(String fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            return true;
        }

        private String get_current_date()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        private String get_time_of_day()
        {
            return DateTime.Now.ToString("HH-mm-ss");
        }

        unsafe public int save_point2wrl(ref FrameData output, string rootPath)
        {
            string wrlPath = rootPath + "/t.wrl";

            // 如果文件不存在
            if (!File.Exists(wrlPath))
            {
                using (FileStream fs = File.Create(wrlPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            StreamWriter fw = new StreamWriter(wrlPath, false, utf8WithoutBom);

            fw.WriteLine("#VRML V2.0 utf8");
            fw.WriteLine("#SCU");
            fw.WriteLine("Viewpoint");
            fw.WriteLine("{\n}\nDEF Flames Shape\n{\n appearance Appearance ");
            fw.WriteLine("{\n texture  ImageTexture {  url  ");
            fw.WriteLine("\"t.bmp\" } \n } \n geometry IndexedFaceSet ");
            fw.WriteLine("{ \n solid FALSE \n ccw TRUE \n coord Coordinate \n { \n point \n [ ");

            // 保存所有3d点的坐标
            for (int i = 0; i < output.pointCount; ++i)
            {
                fw.WriteLine(string.Format("{0:f6} {1:f6} {2:f6},", output.point3D[i * 3 + 0], output.point3D[i * 3 + 1], output.point3D[i * 3 + 2]));
            }

            fw.WriteLine("]\n } \n texCoord TextureCoordinate ");
            fw.WriteLine("{ \n point \n [ ");

            //// 保存左纹理上的所有投影点 
            for (int i = 0; i < output.pointCount; ++i)
            {
                fw.WriteLine(string.Format("{0:f6} {1:f6}, ", output.pointUV[i * 2 + 0], output.pointUV[i * 2 + 1]));
            }

            fw.WriteLine("]\n } \n coordIndex \n [");

            // 保存三维三角形面片三个顶点的索引
            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                fw.WriteLine(string.Format("{0:d}, {1:d} ,{2:d} -1, ", output.triangleIndices[i * 3 + 0], output.triangleIndices[i * 3 + 1], output.triangleIndices[i * 3 + 2]));
            }

            fw.WriteLine("]\n texCoordIndex \n [ ");

            // 保存三维三角形面片三个顶点的索引
            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                fw.WriteLine(string.Format("{0:d}, {1:d} ,{2:d} -1,", output.triangleIndices[i * 3 + 0], output.triangleIndices[i * 3 + 1], output.triangleIndices[i * 3 + 2]));
            }

            fw.WriteLine(" ]\n } \n } ");

            fw.Flush();
            fw.Close();
            return 0;
        }

        unsafe public int save_point2pcd(ref FrameData output, string rootPath)
        {
            string pcdPath = rootPath + "/t.pcd";

            if (!File.Exists(pcdPath))
            {
                using (FileStream fs = File.Create(pcdPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            StreamWriter fw = new StreamWriter(pcdPath, false, utf8WithoutBom);

            fw.WriteLine("# .PCD v0.7 - Point Cloud Data file format");
            fw.WriteLine("VERSION 0.7");
            fw.WriteLine("FIELDS x y z");
            fw.WriteLine("SIZE 4 4 4");
            fw.WriteLine("TYPE F F F");
            fw.WriteLine("COUNT 1 1 1");
            fw.WriteLine(string.Format("WIDTH {0:d}", output.pointCount));
            fw.WriteLine("HEIGHT 1");
            fw.WriteLine("VIEWPOINT 0 0 0 1 0 0 0");
            fw.WriteLine(string.Format("POINTS {0:d}", output.pointCount));
            fw.WriteLine("DATA ascii");

            // 保存所有3d点的坐标
            for (int i = 0; i < output.pointCount; ++i)
            {
                fw.WriteLine(string.Format("{0:f6} {1:f6} {2:f6}", output.point3D[i * 3 + 0], output.point3D[i * 3 + 1], output.point3D[i * 3 + 2]));
            }

            fw.Flush();
            fw.Close();
            return 0;
        }

        unsafe public int save_point2pcd_b(ref FrameData output, string rootPath)
        {
            string pcdPath = rootPath + "/pcd_b.pcd";
            FileStream fs = null;

            if (!File.Exists(pcdPath))
            {
                fs = File.Create(pcdPath);
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            BinaryWriter fw = new BinaryWriter(fs, utf8WithoutBom);

            fw.Write(Encoding.UTF8.GetBytes("# .PCD v0.7 - Point Cloud Data file format\n"));
            fw.Write(Encoding.UTF8.GetBytes("VERSION 0.7\n"));
            fw.Write(Encoding.UTF8.GetBytes("FIELDS x y z\n"));
            fw.Write(Encoding.UTF8.GetBytes("SIZE 4 4 4\n"));
            fw.Write(Encoding.UTF8.GetBytes("TYPE F F F\n"));
            fw.Write(Encoding.UTF8.GetBytes("COUNT 1 1 1\n"));
            fw.Write(Encoding.UTF8.GetBytes(string.Format("WIDTH {0:d}\n", output.pointCount)));
            fw.Write(Encoding.UTF8.GetBytes("HEIGHT 1\n"));
            fw.Write(Encoding.UTF8.GetBytes("VIEWPOINT 0 0 0 1 0 0 0\n"));
            fw.Write(Encoding.UTF8.GetBytes(string.Format("POINTS {0:d}\n", output.pointCount)));
            fw.Write(Encoding.UTF8.GetBytes("DATA binary\n"));

            // 保存所有3d点的坐标
            for (int i = 0; i < output.pointCount; ++i)
            {
                fw.Write(output.point3D[i * 3 + 0]);
                fw.Write(output.point3D[i * 3 + 1]);
                fw.Write(output.point3D[i * 3 + 2]);
            }

            fw.Flush();
            fw.Close();

            fs.Close();
            fs.Dispose();
            return 0;
        }

        unsafe public int save_point2obj(ref FrameData output, string rootPath)
        {
            string objPath = rootPath + "/t.obj";
            string mtlPath = rootPath + "/t.mtl";

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            if (!File.Exists(mtlPath))
            {
                using (FileStream fs = File.Create(mtlPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            StreamWriter fw_filem = new StreamWriter(mtlPath, false, utf8WithoutBom);

            fw_filem.WriteLine("newmtl vtktexture");
            fw_filem.WriteLine("map_Kd t.bmp");

            fw_filem.Flush();
            fw_filem.Close();

            if (!File.Exists(objPath))
            {
                using (FileStream fs = File.Create(objPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            StreamWriter fw = new StreamWriter(objPath, false, utf8WithoutBom);

            fw.WriteLine("mtllib t.mtl");
            fw.WriteLine("usemtl vtktexture");


            for (int i = 0; i < output.point3DSize; i = i + 3)
            {
                fw.WriteLine(string.Format("v {0:f6} {1:f6} {2:f6}", output.point3D[i + 0], output.point3D[i + 1], output.point3D[i + 2]));
            }


            for (int i = 0; i < output.pointUVSize; i = i + 2)
            {
                fw.WriteLine(string.Format("vt {0:f6} {1:f6}", output.pointUV[i + 0], output.pointUV[i + 1]));
            }

            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                fw.WriteLine(string.Format("f {0:d}/{1:d} {2:d}/{3:d} {4:d}/{5:d}", output.triangleIndices[i * 3 + 0] + 1, output.triangleIndices[i * 3 + 0] + 1, output.triangleIndices[i * 3 + 1] + 1, output.triangleIndices[i * 3 + 1] + 1, output.triangleIndices[i * 3 + 2] + 1, output.triangleIndices[i * 3 + 2] + 1));
            }

            fw.Flush();
            fw.Close();
            return 0;
        }

        unsafe public int save_point2ply(ref FrameData output, string rootPath)
        {
            string pcdPath = rootPath + "\\cloud.ply";

            if (!File.Exists(pcdPath))
            {
                using (FileStream fs = File.Create(pcdPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            StreamWriter fw = new StreamWriter(pcdPath, false, utf8WithoutBom);

            fw.WriteLine("ply");
            fw.WriteLine("format ascii 1.0");
            fw.WriteLine(string.Format("element vertex {0:d}", output.pointCount));
            fw.WriteLine("property float x");
            fw.WriteLine("property float y");
            fw.WriteLine("property float z");
            fw.WriteLine(string.Format("element face {0:d}", output.triangleIndicesSize));
            fw.WriteLine("property list uchar int vertex_indices");
            fw.WriteLine("end_header");

            // 保存所有3d点的坐标
            for (int i = 0; i < output.pointCount; ++i)
            {
                fw.WriteLine(string.Format("{0:f6} {1:f6} {2:f6}", output.point3D[i * 3 + 0], output.point3D[i * 3 + 1], output.point3D[i * 3 + 2]));
            }

            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                fw.WriteLine(string.Format("3 {0:d} {1:d} {2:d}", output.triangleIndices[i * 3 + 0], output.triangleIndices[i * 3 + 1], output.triangleIndices[i * 3 + 2]));
            }

            fw.Flush();
            fw.Close();
            return 0;
        }

        unsafe public int save_point2ply_b(ref FrameData output, string rootPath)
        {
            string plyPath = rootPath + "\\ply_b.ply";
            FileStream fs = null;

            if (!File.Exists(plyPath))
            {
                fs = File.Create(plyPath);
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            BinaryWriter fw = new BinaryWriter(fs, utf8WithoutBom);

            fw.Write(Encoding.UTF8.GetBytes("ply\n"));
            fw.Write(Encoding.UTF8.GetBytes("format binary_little_endian 1.0\n"));
            fw.Write(Encoding.UTF8.GetBytes(string.Format("element vertex {0:d}\n", output.pointCount)));
            fw.Write(Encoding.UTF8.GetBytes("property float x\n"));
            fw.Write(Encoding.UTF8.GetBytes("property float y\n"));
            fw.Write(Encoding.UTF8.GetBytes("property float z\n"));
            fw.Write(Encoding.UTF8.GetBytes(string.Format("element face {0:d}\n", output.triangleIndicesSize)));
            fw.Write(Encoding.UTF8.GetBytes("property list uchar int vertex_indices\n"));
            fw.Write(Encoding.UTF8.GetBytes("end_header\n"));

            // 保存所有3d点的坐标
            for (int i = 0; i < output.pointCount; ++i)
            {
                float x = output.point3D[i * 3 + 0];
                float y = output.point3D[i * 3 + 1];
                float z = output.point3D[i * 3 + 2];

                fw.Write(x);
                fw.Write(y);
                fw.Write(z);

            }

            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                int t1 = output.triangleIndices[i * 3 + 0];
                int t2 = output.triangleIndices[i * 3 + 1];
                int t3 = output.triangleIndices[i * 3 + 2];
                fw.Write((byte)3);
                fw.Write(t1);
                fw.Write(t2);
                fw.Write(t3);
            }

            fw.Flush();
            fw.Close();

            fs.Close();
            fs.Dispose();
            return 0;
        }

        unsafe public int save_point2ply_normal_color(ref FrameData output, string rootPath)
        {
            string plyPath = rootPath + "/normal.ply";
            if (!File.Exists(plyPath))
            {
                using (FileStream fs = File.Create(plyPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            StreamWriter fw = new StreamWriter(plyPath, false, utf8WithoutBom);

            fw.WriteLine("ply");
            fw.WriteLine("format ascii 1.0");
            fw.WriteLine(string.Format("element vertex {0:d}", output.point3DSize / 3));
            fw.WriteLine("property float x");
            fw.WriteLine("property float y");
            fw.WriteLine("property float z");
            fw.WriteLine("property float nx");
            fw.WriteLine("property float ny");
            fw.WriteLine("property float nz");
            fw.WriteLine("property uchar red");
            fw.WriteLine("property uchar green");
            fw.WriteLine("property uchar blue");
            fw.WriteLine(string.Format("element face {0:d}", 0));
            fw.WriteLine("property list uchar int vertex_indices");
            fw.WriteLine("end_header");

            var pointNum = output.point3DSize / 3;            
            if (output.pointColor != null) {
                for (int i = 0 ; i < pointNum; i++) {
                    float x = output.point3D[i * 3 + 0];
                    float y = output.point3D[i * 3 + 1];
                    float z = output.point3D[i * 3 + 2];
                    float nx = output.normals[i * 3 + 0];
                    float ny = output.normals[i * 3 + 1];
                    float nz = output.normals[i * 3 + 2];
                    byte red = (byte)output.pointColor[i * 3 + 2];
                    byte green = (byte)output.pointColor[i * 3 + 1];
                    byte blue = (byte)output.pointColor[i * 3 + 0];

                    fw.WriteLine(string.Format("{0:f6} {1:f6} {2:f6} {3:f6} {4:f6} {5:f6} {6:d} {7:d} {8:d}"
                        , x, y, z, nx, ny, nz, red, green, blue));
                }
            } else {
                for (int i = 0; i < pointNum; i++)  {
                    float x = output.point3D[i * 3 + 0];
                    float y = output.point3D[i * 3 + 1];
                    float z = output.point3D[i * 3 + 2];
                    float nx = output.normals[i * 3 + 0];
                    float ny = output.normals[i * 3 + 1];
                    float nz = output.normals[i * 3 + 2];
                    byte red = 128;
                    byte green = 128;
                    byte blue = 128;

                    fw.WriteLine(string.Format("{0:f6} {1:f6} {2:f6} {3:f6} {4:f6} {5:f6} {6:d} {7:d} {8:d}"
                        , x, y, z, nx, ny, nz, red, green, blue));
                }
            }

            fw.Flush();
            fw.Close();

            return 0;
        }

        unsafe public int calc_normal(FrameData cloud, float[] vertice, float[] normal, int count)
        {
            int index1 = cloud.triangleIndices[count * 3 + 0];
            int index2 = cloud.triangleIndices[count * 3 + 1];
            int index3 = cloud.triangleIndices[count * 3 + 2];
            vertice[0] = cloud.point3D[3 * index1 + 0];
            vertice[1] = cloud.point3D[3 * index1 + 1];
            vertice[2] = cloud.point3D[3 * index1 + 2];
            vertice[3] = cloud.point3D[3 * index2 + 0];
            vertice[4] = cloud.point3D[3 * index2 + 1];
            vertice[5] = cloud.point3D[3 * index2 + 2];
            vertice[6] = cloud.point3D[3 * index3 + 0];
            vertice[7] = cloud.point3D[3 * index3 + 1];
            vertice[8] = cloud.point3D[3 * index3 + 2];
            float detx1 = vertice[3] - vertice[0];
            float dety1 = vertice[4] - vertice[1];
            float detz1 = vertice[5] - vertice[2];
            float detx2 = vertice[6] - vertice[3];
            float dety2 = vertice[7] - vertice[4];
            float detz2 = vertice[8] - vertice[5];
            float nx = dety1 * detz2 - dety2 * detz1;
            float ny = detx1 * detz2 - detx2 * detz1;
            float nz = detx1 * dety2 - detx2 * dety1;

            float len = (float)(Math.Sqrt((double)(nx * nx + ny * ny + nz * nz)));
            nx = nx / len;
            ny = ny / len;
            nz = nz / len;
            normal[0] = nx;
            normal[1] = ny;
            normal[2] = nz;

            return 0;
        }

        public int save_point2stl(ref FrameData output, string rootPath)
        {
            string stlPath = rootPath + "/t.stl";

            if (!File.Exists(stlPath))
            {
                using (FileStream fs = File.Create(stlPath))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            StreamWriter fw = new StreamWriter(stlPath, false, utf8WithoutBom);

            fw.WriteLine("solid STL");

            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                float[] vertices = new float[9];
                float[] normal = new float[3];
                calc_normal(output, vertices, normal, i);
                fw.WriteLine(string.Format("facet normal {0:f6} {1:f6} {2:f6}", normal[0], normal[1], normal[2]));
                fw.WriteLine("outer loop");
                fw.WriteLine(string.Format("vertex {0:f6} {1:f6} {2:f6}", vertices[0], vertices[1], vertices[2]));
                fw.WriteLine(string.Format("vertex {0:f6} {1:f6} {2:f6}", vertices[3], vertices[4], vertices[5]));
                fw.WriteLine(string.Format("vertex {0:f6} {1:f6} {2:f6}", vertices[6], vertices[7], vertices[8]));

                fw.WriteLine("endloop");
                fw.WriteLine("endfacet");
            }

            fw.WriteLine("endsolid STL");

            fw.Flush();
            fw.Close();
            return 0;
        }

        public int save_point2stl_b(ref FrameData output, string rootPath)
        {
            string stlPath = rootPath + "/t.stl";
            FileStream fs = null;

            if (!File.Exists(stlPath))
            {
                fs = File.Create(stlPath);
            }

            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            BinaryWriter fw = new BinaryWriter(fs, utf8WithoutBom);

            byte[] src = new byte[4];

            fw.Write(Encoding.UTF8.GetBytes("solid STL"));
            for (int i = 0; i < 71; i++)
            {
                fw.Write(Encoding.UTF8.GetBytes("0"));
            }

            int Count = (int)output.triangleIndicesSize;
            //fw.Write(Encoding.UTF8.GetBytes(string.Format("{0:d}", Count)));
            fw.Write(Count);

            for (int i = 0; i < output.triangleIndicesSize; ++i)
            {
                float[] vertices = new float[9];
                float[] normal = new float[3];
                calc_normal(output, vertices, normal, i);

                fw.Write(normal[0]);
                fw.Write(normal[1]);
                fw.Write(normal[2]);

                fw.Write(vertices[0]);
                fw.Write(vertices[1]);
                fw.Write(vertices[2]);
                fw.Write(vertices[3]);
                fw.Write(vertices[4]);
                fw.Write(vertices[5]);
                fw.Write(vertices[6]);
                fw.Write(vertices[7]);
                fw.Write(vertices[8]);

                fw.Write(Encoding.UTF8.GetBytes("wl"));
            }

            fw.Flush();
            fw.Close();
            fs.Close();
            fs.Dispose();

            return 0;
        }

        unsafe public int save_point2tiff(ref FrameData output, CameraParam camparam, string rootPath)
        {
            int width = camparam.irWidth;
            int height = camparam.irHeight;
            string tiffPath = rootPath + "\\point_t.tiff";

            using (Tiff tif = Tiff.Open(tiffPath, "w"))
            {
                if (tif == null)
                {
                    Console.WriteLine("tiff file {0} create failure", tiffPath);
                    return -1;
                }

                tif.SetField(TiffTag.IMAGEWIDTH, width);
                tif.SetField(TiffTag.IMAGELENGTH, height);
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

                float[] points = new float[(int)output.pointCount * 3];
                Marshal.Copy((IntPtr)output.point3D, points, 0, (int)output.pointCount * 3);
                byte[] bs = points.SelectMany(x => BitConverter.GetBytes(x)).ToArray();
                int bufsize = width * 3 * 32 / 8;
                int len = 0;
                byte[] buf = new byte[bufsize];
                for (int s = 0; s < height; s++)
                {
                    Buffer.BlockCopy(bs, len, buf, 0, bufsize);
                    len += bufsize;
                    tif.WriteRawStrip(s, buf, bufsize);
                    Array.Clear(buf, 0, bufsize);
                }

                tif.FlushData();
                tif.Close();
            }

            return 0;
        }
    }
}

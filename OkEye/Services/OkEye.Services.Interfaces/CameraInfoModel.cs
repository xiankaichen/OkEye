using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// 相机信息，包括相机硬件信息和相机拍照参数信息
    /// </summary>
    public class CameraInfoModel
    {
        [Category("1设备参数"), PropertyOrder(9)]
        [DisplayName("品牌"), ReadOnly(true)]
        [Browsable(true)]
        public string Band { get; set; }

        [Category("1设备参数"), PropertyOrder(10)]
        [DisplayName("示意图"), ReadOnly(true)]
        [Browsable(true)]
        public string Pic { get; set; }

        [Category("1设备参数"), PropertyOrder(11)]
        [DisplayName("状态"), ReadOnly(true)]
        [Browsable(true)]
        public string Status { get; set; }

        [Category("1设备参数"), PropertyOrder(11)]
        [DisplayName("名称"), ReadOnly(true)]
        [Browsable(true)]
        public string Name { get; set; }

        [Category("1设备参数"), PropertyOrder(12)]
        [DisplayName("相机IP"), ReadOnly(true)]
        [Browsable(true)]
        public string CameraIP { get; set; }

        [Category("1设备参数"), PropertyOrder(12)]
        [DisplayName("用户IP"), ReadOnly(true)]
        [Browsable(true)]
        public string UserIP { get; set; }

        // 相机序号
        [Category("1设备参数"), PropertyOrder(13)]
        [DisplayName("相机序号"), ReadOnly(true)]
        [Browsable(true)]
        public string Serial { get; set; }

        [Category("1设备参数"), PropertyOrder(14)]
        [DisplayName("MAC地址"), ReadOnly(true)]
        [Browsable(true)]
        public string MacAdress { get; set; }

        [Category("1设备参数"), PropertyOrder(17)]
        [DisplayName("相机类型"), ReadOnly(true)]
        [Browsable(true)]
        public string Model { get; set; }

        // 拍照模式，两种：高精度，快速，默认高精度，下拉列表
        [Category("2相机参数"), PropertyOrder(17)]
        [DisplayName("扫描类型")]
        [Browsable(true)]
        public ScanMode ScanMode { get; set; }

        // 设置曝光
        [Category("2相机参数"), PropertyOrder(15)]
        [DisplayName("曝光(ms)")]
        [Browsable(true)]
        public float Exposure { get; set; }

        // 增益
        [Category("2相机参数"), PropertyOrder(16)]
        [DisplayName("增益")]
        [Browsable(true)]
        public float Gain { get; set; }

        // 图像宽度
        [Category("2相机参数"), PropertyOrder(11)]
        [DisplayName("图像宽度"), ReadOnly(true)]
        [Browsable(true)]
        public int textureWidth { get; set; }

        // 图像高度
        [Category("2相机参数"), PropertyOrder(12)]
        [DisplayName("图像高度"), ReadOnly(true)]
        [Browsable(true)]
        public int textureHeight { get; set; }

        // ir宽度
        [Category("2相机参数"), PropertyOrder(13)]
        [DisplayName("IR宽度"), ReadOnly(true)]
        [Browsable(true)]
        public int irWidth { get; set; }

        // ir高度
        [Category("2相机参数"), PropertyOrder(14)]
        [DisplayName("IR高度"), ReadOnly(true)]
        [Browsable(true)]
        public int irHeight { get; set; }

        // irPerNum
        [Category("2相机参数"), PropertyOrder(15)]
        [DisplayName("IR像素位"), ReadOnly(true)]
        [Browsable(true)]
        public int irPerNum { get; set; }

        // 带默认参数的构造函数
        public CameraInfoModel(
            string band = "VirtualCamera",
            string pic = null,
            string status="未连接", 
            string name = "CS6100", 
            string cameraIP="192.168.11.23", 
            string userIP = "192.168.11.100", 
            string serial= "CS213422445NX", 
            string macAdress = "02:22:e2:w1:11:34", 
            string model="CS", 
            ScanMode scanMode = ScanMode.HightQuality,
            float exposure = 10, 
            float gain = 2, 
            int textureWidth = 3000, 
            int textureHeight = 3000,
            int irWidth = 3000, 
            int irHeight = 2000, 
            int irPerNum = 3000)
        {
            Band = band;
            Pic = pic;
            Status = status;
            Name = name;
            CameraIP = cameraIP;
            UserIP = userIP;
            Serial = serial;
            MacAdress = macAdress;
            Model = model;
            ScanMode = scanMode;
            Exposure = exposure;
            Gain = gain;
            this.textureWidth = textureWidth;
            this.textureHeight = textureHeight;
            this.irWidth = irWidth;
            this.irHeight = irHeight;
            this.irPerNum = irPerNum;
        }


        //public CameraInfoModel()
        //{
        //    Status = "未连接";
        //    Name = "";
        //    CameraIP = "";
        //    UserIP = "";
        //    Serial = "";
        //    MacAdress = "";
        //    Model = "";
        //    ScanMode = ScanMode.HightQuality;
        //    Exposure = 0;
        //    Gain = 0;
        //    textureWidth = 0;
        //    textureHeight = 0;
        //    irWidth = 0;
        //    irHeight = 0;
        //    irPerNum = 0;


        //}

    }

    /// <summary>
    /// 相机拍摄模式
    /// </summary>
    public enum ScanMode
    {
        // 高精度和快速模式
        Speed,
        Quality,
        Balance,
        HightQuality,
    }


    /// <summary>
    /// 实体属性处理
    /// </summary>
    public class PropertyHandle
    {
        #region 反射控制只读、可见属性
        //SetPropertyVisibility(obj,   "名称 ",   true); 
        //obj指的就是你的SelectObject，   “名称”是你SelectObject的一个属性 
        //当然，调用这两个方法后，重新SelectObject一下，就可以了。
        /// <summary>
        /// 通过反射控制属性是否只读
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="readOnly"></param>
        public static void SetPropertyReadOnly(object obj, string propertyName, bool readOnly)
        {
            Type type = typeof(ReadOnlyAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("isReadOnly", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            fld.SetValue(attrs[type], readOnly);
        }

        /// <summary>
        /// 通过反射控制属性是否可见
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="visible"></param>
        public static void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("Browsable", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(attrs[type], visible);
        }
        #endregion
    }
}
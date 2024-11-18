using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace OkEye.Services.Interfaces
{
    /// <summary>
    /// 相机信息
    /// </summary>
    public class CameraInfoModel
    {
        [Category("1设备参数"), PropertyOrder(11)]
        [DisplayName("状态"), ReadOnly(true)]
        public string Status { get; set; }

        [Category("1设备参数"), PropertyOrder(11)]
        [DisplayName("名称"), ReadOnly(true)]
        public string Name { get; set; }

        [Category("1设备参数"), PropertyOrder(12)]
        [DisplayName("相机IP"), ReadOnly(true)]
        public string CameraIP { get; set; }

        [Category("1设备参数"), PropertyOrder(12)]
        [DisplayName("用户IP"), ReadOnly(true)]
        public string UserIP { get; set; }

        // 相机序号
        [Category("1设备参数"), PropertyOrder(13)]
        [DisplayName("相机序号"), ReadOnly(true)]
        public string Serial { get; set; }

        [Category("1设备参数"), PropertyOrder(14)]
        [DisplayName("MAC地址"), ReadOnly(true)]
        public string MacAdress { get; set; }

        // 设置曝光
        [Category("1设备参数"), PropertyOrder(15)]
        [DisplayName("曝光(ms)")]
        public string Exposure { get; set; }

        // 增益
        [Category("1设备参数"), PropertyOrder(16)]
        [DisplayName("增益")]
        public string Gain { get; set; }

        // 拍照模式，两种：高精度，快速，默认高精度，下拉列表
        [Category("1设备参数"), PropertyOrder(17)]
        [DisplayName("拍照模式")]
        public string CameMode { get; set; }

        // 图像宽度
        [Category("2图像参数"), PropertyOrder(11)]
        [DisplayName("图像宽度"), ReadOnly(true)]
        public int textureWidth { get; set; }

        // 图像高度
        [Category("2图像参数"), PropertyOrder(12)]
        [DisplayName("图像高度"), ReadOnly(true)]
        public int textureHeight { get; set; }

        // ir宽度
        [Category("2图像参数"), PropertyOrder(13)]
        [DisplayName("IR宽度"), ReadOnly(true)]
        public int irWidth { get; set; }

        // ir高度
        [Category("2图像参数"), PropertyOrder(14)]
        [DisplayName("IR高度"), ReadOnly(true)]
        public int irHeight { get; set; }

        // irPerNum
        [Category("2图像参数"), PropertyOrder(15)]
        [DisplayName("IR像素位"), ReadOnly(true)]
        public int irPerNum { get; set; }

    }

    /// <summary>
    /// 相机拍摄模式
    /// </summary>
    public class CameraMode
    {
        // 高精度和快速模式
        public string HightAccuracy;
        public string HightSpeed;

    }
}
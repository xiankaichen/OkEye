using System;
using Microsoft.Extensions.Logging;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Regions;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using OkEye.Modules.ModuleCamera.Events;
using OpenCvSharp;
using Prism.Events;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using OpenCvSharp.Extensions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public  class DepthCanvasViewMode : RegionViewModelBase
    {
        private ImageSource depthFrame;
        public ImageSource DepthFrame
        {
            get { return depthFrame; }
            set { SetProperty(ref depthFrame, value); }
        }

        ICameraService _cameraService;
        ILogger _logger;
        private IEventAggregator _depthAggregator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager"></param>    区域管理器
        /// <param name="cameraService"></param>      相机服务
        /// <param name="logger"></param>                   日志服务
        /// <param name="depthAggregator"></param>  深度事件聚合器
        public DepthCanvasViewMode(IRegionManager regionManager, ICameraService cameraService, 
            ILogger<ImageCanvasViewMode> logger, IEventAggregator depthAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;             // 注入相机服务
            _logger = logger;                                       // 注入日志服务
            _depthAggregator = depthAggregator;    // 注入深度事件聚合器
            _depthAggregator.GetEvent<DepthPubSubEvent>().Subscribe(UpdateDepthAsync);  // 订阅更新深度事件

            DepthFrame = null;

            _logger.LogInformation("初始化深度画布视图");
        }

        /// <summary>
        /// 更新深度图像
        /// </summary>
        /// <param name="image"></param>
        public async void UpdateDepthAsync(Mat image)
        {
            ImageSource imageSource = null;
            await Task.Run(() =>
            {
                Bitmap bmp = image.ToBitmap();
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    imageSource = BitmapToImageSource(bmp);
                }));
            });

            DepthFrame = imageSource;
        }

        /// <summary>
        /// Bitmap转ImageSource
        /// </summary>
        /// <param name="bitmap"></param>   位图
        /// <returns></returns>
        public ImageSource BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            try
            {
                IntPtr intPtr = bitmap.GetHbitmap();
                ImageSource imageSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero,
                    Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                return imageSource;
            }
            catch (Exception ex)
            {
                _logger.LogDebug("转换图片失败，BitMap to ImageSource");
            }
            return null;
        }

        /// <summary>
        /// 导航到页面的事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}

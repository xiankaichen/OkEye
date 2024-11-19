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
    /// <summary>
    /// 图像画布视图模型
    /// </summary>
    public class ViewImageViewModel : RegionViewModelBase
    {
        ICameraService _cameraService;               // 相机服务
        ILogger _logger;                                        // 日志服务
        IEventAggregator _imageAggregator;      // 图像事件聚合器

        /// <summary>
        /// 图像数据
        /// </summary>
        private ImageSource _imageFrame;    
        public ImageSource ImageFrame
        {
            get { return _imageFrame; }
            set { SetProperty(ref _imageFrame, value); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="cameraService"></param>
        /// <param name="logger"></param>
        /// <param name="imageAggregator"></param>
        public ViewImageViewModel(IRegionManager regionManager, ICameraService cameraService, 
            ILogger<ViewImageViewModel> logger, IEventAggregator imageAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;             // 注入相机服务
            _logger = logger;                                      // 注入日志服务
            _imageAggregator = imageAggregator;  // 注入图像事件聚合器
            _imageAggregator.GetEvent<ImagePubSubEvent>().Subscribe(UpdateImageAsync);  // 订阅更新图像事件

            ImageFrame = null;  // 初始化图像画布视图，图像数据为空

            _logger.LogInformation("初始化图像画布视图");
        }

        /// <summary>
        /// 更新图像数据
        /// </summary>
        /// <param name="image"></param>    图像数据
        public async void UpdateImageAsync(Mat image)
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
            ImageFrame = imageSource;
        }

        /// <summary>
        /// Bitmap转换为ImageSource
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public ImageSource BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            try
            {
                IntPtr intPtr = bitmap.GetHbitmap();
                ImageSource imageSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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

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


        public DepthCanvasViewMode(IRegionManager regionManager, ICameraService cameraService, 
            ILogger<ImageCanvasViewMode> logger, IEventAggregator depthAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;
            _logger = logger;
            _depthAggregator = depthAggregator;
            _depthAggregator.GetEvent<DepthPubSubEvent>().Subscribe(UpdateDepthAsync);

            DepthFrame = null;
        }

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


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}

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
    public  class ImageCanvasViewMode : RegionViewModelBase
    {
        private ImageSource _imageFrame;
        public ImageSource ImageFrame
        {
            get { return _imageFrame; }
            set { SetProperty(ref _imageFrame, value); }
        }

        ICameraService _cameraService;
        ILogger _logger;
        private IEventAggregator _imageAggregator;


        public ImageCanvasViewMode(IRegionManager regionManager, ICameraService cameraService, 
            ILogger<ImageCanvasViewMode> logger, IEventAggregator imageAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;
            _logger = logger;
            _imageAggregator = imageAggregator;
            _imageAggregator.GetEvent<ImagePubSubEvent>().Subscribe(UpdateImageAsync);

            ImageFrame = null;
            //ImageFrame = LoadBitmap("background.png");
        }

        public async void UpdateImageAsync(Mat image)
        {
            ImageSource imageSource = null;
            await Task.Run(() =>
                {
                    image.ImWrite("textrue.png");
                    Bitmap bmp = image.ToBitmap();
                    bmp.Save("texture.bmp");
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        imageSource = BitmapToImageSource(bmp);
                    }));
                    
                });

            ImageFrame = imageSource;
        }
        //public BitmapFrame LoadBitmap(string fileName)
        //{

        //    Stream pngStream = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        //    PngBitmapDecoder pngDecoder = new PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
        //    BitmapFrame pngFrame = pngDecoder.Frames[0];

        //    return pngFrame;
        //}


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

    ////将Bitmap对象转换成bitmapImage对象
    //public BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
    //{
    //    MemoryStream stream = new MemoryStream();
    //    bitmap.Save(stream, ImageFormat.Bmp);
    //    BitmapImage image = new BitmapImage();
    //    image.BeginInit();
    //    image.StreamSource = stream;
    //    image.EndInit();
    //    return image;
    //}

    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something

            //RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
        }
    }
}

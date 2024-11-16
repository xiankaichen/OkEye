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
using Kitware.VTK;
using OpenCvSharp.Extensions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewCloudViewMode : RegionViewModelBase
    {
        private Mat _cloud;
        public Mat Cloud
        {
            get { return _cloud; }
            set { SetProperty(ref _cloud, value); }
        }

        ICameraService _cameraService;
        ILogger _logger;
        private IEventAggregator _cloudAggregator;


        public ViewCloudViewMode(IRegionManager regionManager, ICameraService cameraService,
            ILogger<ImageCanvasViewMode> logger, IEventAggregator cloudAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;
            _logger = logger;
            _cloudAggregator = cloudAggregator;
            _cloudAggregator.GetEvent<CloudPubSubEvent>().Subscribe(UpdateCloudAsync);

            _cloud = null;
        }

        public async void UpdateCloudAsync(Mat cloud)
        {
            
            await Task.Run(() =>
            {
                Cloud = cloud;
                
            });

            //DepthFrame = imageSource;
        }

        


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}

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
    /// <summary>
    /// 点云显示的视图模型
    /// </summary>
    public class ViewCloudViewModel : RegionViewModelBase
    {
        ILogger _logger;                            // 日志服务
        private IEventAggregator _cloudAggregator;  // 点云事件聚合器

        /// <summary>
        /// 点云数据
        /// </summary>
        private Mat _cloud;
        public Mat Cloud
        {
            get { return _cloud; }
            set { SetProperty(ref _cloud, value); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager"></param>    区域管理器
        /// <param name="logger"></param>                   日志服务
        /// <param name="cloudAggregator"></param>  点云事件聚合器
        public ViewCloudViewModel(IRegionManager regionManager, 
            ILogger<ViewImageViewModel> logger, IEventAggregator cloudAggregator) :
            base(regionManager)
        {
            _logger = logger;                                   // 注入日志服务
            _cloudAggregator = cloudAggregator; // 注入点云事件聚合器

            _cloudAggregator.GetEvent<CloudPubSubEvent>().Subscribe(UpdateCloudAsync);  // 订阅更新点云事件

            _cloud = null;
        }

        /// <summary>
        /// 更新点云数据，异步处理
        /// </summary>
        /// <param name="cloud"></param>
        public async void UpdateCloudAsync(Mat cloud)
        {
            if(cloud == null)
            {
                _logger.LogWarning("点云数据为空");
                return;
            }

            if (cloud.Empty())
            {
                _logger.LogWarning("点云数据为空");
                return;
            }
            await Task.Run(() =>
            {
                Cloud = cloud;
            });
        }

        /// <summary>
        /// 页面导航到此页面时，触发事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}

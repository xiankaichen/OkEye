using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Diagnostics;
using System.Threading;
using System;
using System.Collections.Generic;
using OpenCvSharp;
using Prism.Events;
using OkEye.Modules.ModuleCamera.Events;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewCameraViewModel : RegionViewModelBase
    {
        private ICameraService _cameraService;
        private IEventAggregator _imageAggregator;



        private Logger<ViewCameraViewModel> _logger;    // 日志记录器

        private CameraInfoModel cameraInfo;
        public CameraInfoModel CameraInfo
        {
            get { return cameraInfo; }
            set { SetProperty(ref cameraInfo, value); }
        }

        public DelegateCommand DisconnectCameraCommand { get; private set; }
        public DelegateCommand SnapOnceCommand { get; private set; }

        // 数据显示切换命令
        public DelegateCommand ShowCloudCommand { get; private set; }
        public DelegateCommand ShowDepthCommand { get; private set; }
        public DelegateCommand ShowImageCommand { get; private set; }

        public ViewCameraViewModel(IRegionManager regionManager, ICameraService cameraService,
            Logger<ViewCameraViewModel> logger, IEventAggregator imageAggregator) :
            base(regionManager)
        {
            _cameraService = cameraService;
            _logger = logger;
            _logger.LogInformation("初始化相机模块");


            _imageAggregator = imageAggregator;
            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            DisconnectCameraCommand = new DelegateCommand(OnDisconnectCameraCommand );
            SnapOnceCommand = new DelegateCommand(OnSnapOnceCommand);
            ShowCloudCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
            });
            ShowDepthCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewDepth");
            });
            ShowImageCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewImage");
            });

            CameraInfo = _cameraService.GetCameraInfo();

            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewDepth");
            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewImage");
        }

        private void OnSnapOnceCommand()
        {
            // 启动线程连接相机
            Thread connectCameraThr = new Thread(() => StartSnapOnce());
            connectCameraThr.Start();
        }

        private void StartSnapOnce()
        {
            if (_cameraService == null)
            {
                _logger.LogError("相机服务模块未初始化！");
                return;
            }

            // 获取相机状态
            CameraInfoModel camm = _cameraService.GetCameraInfo();
            if (camm.Status != "已连接")
            {
                _logger.LogInformation("相机未连接");
                return;
            }

            OkFrameData frameData = new OkFrameData();
            if (0 == _cameraService.Capture(ref frameData))
            {

                _imageAggregator.GetEvent<ImagePubSubEvent>().Publish(frameData.image);
                _imageAggregator.GetEvent<DepthPubSubEvent>().Publish(frameData.depth);
                _imageAggregator.GetEvent<CloudPubSubEvent>().Publish(frameData.cloud);
                _logger.LogInformation("拍照成功！");
            }
            else
            {
                _logger.LogWarning("拍照失败！");
            }
        }

        private void OnDisconnectCameraCommand()
        {
            // 启动线程连接相机
            Thread connectCameraThr = new Thread(() => StartDisconnectCamera());
            connectCameraThr.Start();
        }

        private void StartDisconnectCamera()
        {
           
            if (_cameraService == null)
            {
                _logger.LogError("相机服务模块未初始化！");
                return;
            }

            // 获取相机状态
            CameraInfoModel camm = _cameraService.GetCameraInfo();
            if (camm.Status != "已连接")
            {
                return;
            }
            if (0 == _cameraService.DisconnectCamera(camm))
            {
                _logger.LogInformation("关闭相机成功！");

                // 更新界面
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewDevice");
                }));
            }
            else
            {
                _logger.LogWarning("关闭相机失败！");
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something

            //RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
        }
    }
}

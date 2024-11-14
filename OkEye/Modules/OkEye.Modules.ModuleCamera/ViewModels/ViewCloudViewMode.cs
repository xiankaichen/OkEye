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
using Kitware.VTK;
using System.Windows;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewCloudViewModel : RegionViewModelBase
    {

       private vtkRenderWindow _cloudRenderWindow;
        public vtkRenderWindow CloudRenderWindow
        {
            get { return _cloudRenderWindow; }
            set { SetProperty(ref _cloudRenderWindow, value); }
        }

        private ICameraService _cameraService;

        private Logger<ViewCloudViewModel> _logger;    // 日志记录器


        public DelegateCommand OnInit3DViewerrCommand { get; private set; }

        public ViewCloudViewModel(IRegionManager regionManager, ICameraService cameraService,
            Logger<ViewCloudViewModel> logger) :
            base(regionManager)
        {
            _cameraService = cameraService;

            _logger = logger;
            _logger.LogInformation("初始化点云页面模块");

            CloudRenderWindow = new vtkRenderWindow(); // RenderWindowControl -> vtkRenderWindow



            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            //OnInit3DViewerrCommand = new DelegateCommand(OnInit3DViewerr);
        }

        //private void OnInit3DViewerr()
        //{
        //    // 启动线程连接相机
        //    Thread connectCameraThr = new Thread(() => Init3DViewer());
        //    connectCameraThr.Start();
        //}

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something

            //RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
        }
    }
}

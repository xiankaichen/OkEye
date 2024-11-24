using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Events;
using OkEye.Services.Interfaces;
using OkEye.Services.VirtualCamera;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    
    

    public class ViewDeviceViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message { get; private set; }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        private List<string> _camBandList = new List<string>();

        List<CameraInfoModel> _camList = new List<CameraInfoModel>();
        public List<CameraInfoModel> CamList
        {
            get { return _camList; }
            set
            {
                SetProperty(ref _camList, value);
            }
        }

        private CameraInfoModel _cameraInfo;
        public CameraInfoModel CameraInfo
        {
            get { return _cameraInfo; }
            set
            {
                SetProperty(ref _cameraInfo, value);
                RaisePropertyChanged();
            }
        }

        public ICameraService _cameraService { get; set; }
        public IDialogService _dialogService;
        private Logger<ViewDeviceViewModel> _logger;
        private IEventAggregator _aggregator;
        private IContainerExtension _container;

        public DelegateCommand OpenIpConfigDialogCommand { get; private set; }
        public DelegateCommand ConnectCameraCommand { get; private set; }
        public DelegateCommand DisconnectCameraCommand { get; private set; }
        public DelegateCommand DiscoverCameraCommand { get; private set; }
        public DelegateCommand CameraSelectionChangedCommand { get; private set; }

        private Thread scanDeviceThr;

        delegate void ConnectCameraCallBack(CameraInfoModel caminfo);

        ConnectCameraCallBack connectCameraCallBack;

        /// <summary>
        /// 构造函数，注入依赖，包含区域管理器，消息服务，相机服务，对话框服务，日志记录器
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="cameraService"></param>
        /// <param name="dialogService"></param>
        /// <param name="logger"></param>
        public ViewDeviceViewModel(IRegionManager regionManager, 
            IDialogService dialogService, Logger<ViewDeviceViewModel> logger
            ,IEventAggregator aggregator, IContainerExtension container) :
            base(regionManager)
        {
            _dialogService = dialogService;        // 对话框服务
            _logger = logger;
            _aggregator = aggregator;
            _container = container;

            _camBandList.Add("VirtualCamera");
            _camBandList.Add("AinsCamera");
            _cameraService = new VirtualCameraService();
            //_cameraService = _container.Resolve<ICameraService>("VirtualCamera");
            //CameraInfo.Concat(_cameraService.DiscoveryDeviceList().ToList());

            // 绑定命令
            BindingCommand();
            // 扫描相机
            _aggregator.GetEvent<CameraPubSubEvent>().Publish("DiscoverCamera");

            _logger.LogInformation("启动设备模块");
        }


        public void BindingCommand()
        {
            // 订阅事件
            // 订阅断开相机事件
            _aggregator.GetEvent<CameraPubSubEvent>().Subscribe(OnDisconnectCamera,
                commandType => commandType == "DisconnectCamera");
            // 订阅连接相机事件
            _aggregator.GetEvent<CameraPubSubEvent>().Subscribe(OnConnectCamera,
                commandType => commandType == "ConnectCamera");
            // 订阅刷新相机事件
            _aggregator.GetEvent<CameraPubSubEvent>().Subscribe(OnDiscoverCamera,
                commandType => commandType == "DiscoverCamera");
            // 订阅打开IP配置对话框事件 
            _aggregator.GetEvent<CameraPubSubEvent>().Subscribe(OnOpenIpConfigDialog,
                commandType => commandType == "OpenIpConfigDialog");


            // 断开相机命令
            DisconnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DisconnectCamera");
            });
            // 连接相机命令
            ConnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("ConnectCamera");
            });
            // 刷新相机命令
            DiscoverCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DiscoverCamera");
            });
            // 打开IP配置对话框命令
            OpenIpConfigDialogCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("OpenIpConfigDialog");
            });

            // 选择相机命令
            CameraSelectionChangedCommand = new DelegateCommand(OnCameraSelected);

        }

        private void OnCameraSelected()
        {
            if (SelectedIndex < 0)
            {
                return;
            }
            if (CamList.Count < SelectedIndex)
            {
                return;
            }

            //// 判断新相机当前是否在连接状态
            //if (CameraInfo != null && CameraInfo.Status == "已连接")
            //{
            //    // 先断开相机
            //    return;
            //}

            CameraInfo = CamList[SelectedIndex];
            // 切换成响应的服务
            _cameraService = _container.Resolve<ICameraService>(CameraInfo.Band);
        }

        private void OnDisconnectCamera(string commandType)
        {
            // 启动任务断开相机
            Task.Factory.StartNew(() =>
            {
                DisconnectCameraTask();
            });
        }

        /// <summary>
        /// 断开相机
        /// </summary>
        private void DisconnectCameraTask()
        {
            lock (CamList)
            {
                if (_cameraService == null)
                {
                    _logger.LogError("相机服务模块未初始化！");
                    return;
                }

                if (CameraInfo == null)
                {
                    _logger.LogError("未发现相机！请检查设备是否连接！");
                    return;
                }
                // 获取相机状态
                CameraInfoModel camm = _cameraService.GetCameraInfo();
                if (camm.Status != "已连接")
                {
                    return;
                }
                if (OkEyeCode.Ok == _cameraService.DisconnectCamera(CameraInfo))
                {
                    _logger.LogInformation("关闭相机成功！");

                    // 更新界面
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CameraInfoModel curCameraInfo = _cameraService.GetCameraInfo();
                        CameraInfo = curCameraInfo;
                        CamList[SelectedIndex] = curCameraInfo;
                    }));
                }
                else
                {
                    _logger.LogWarning("关闭相机失败！");
                }
            }
        }

       

        /// <summary>
        /// 打开IP配置对话框
        /// </summary>
        public void OnOpenIpConfigDialog(string commandType)
        {
            try
            {
                if (CameraInfo == null)
                {
                    _logger.LogWarning("无相相机可配置！");
                    return;
                }

                DialogParameters param = new DialogParameters
                {
                    { "CameraIP", CameraInfo.CameraIP },
                    { "UserIP", CameraInfo.UserIP },
                    { "UserMask", "255.255.255.0" },
                    { "CameraMask", "255.255.255.0" }
                };
                _dialogService.ShowDialog("IPConfigDialog", param, r =>
                {
                    if (r.Result == ButtonResult.OK)
                    {
                        var NewCameraIP = r.Parameters.GetValue<string>("CameraIP");
                        var NewCameraMask = r.Parameters.GetValue<string>("CameraMask");
                        var NewUserIP = r.Parameters.GetValue<string>("UserIP");
                        var NewUserMask = r.Parameters.GetValue<string>("UserMask");

                        _cameraService.SetCameraIP(CameraInfo.CameraIP, NewCameraIP);
                        _logger.LogInformation("配置相机IP或者电脑IP完成");
                        OnDiscoverCamera("DiscoverCamera");
                    }
                    else
                    {
                        _logger.LogInformation("取消配置相机IP或者电脑IP");
                    }
                });
            }
            catch (Exception e)
            {
                _logger.LogError("配置相机IP或者电脑IP失败！" + e.ToString());
                throw;
            }
        }

        /// <summary>
        /// 连接相机命令
        /// </summary>
        public void OnConnectCamera(string commandType)
        {
            // 连接相机，启动一个任务
            Task.Factory.StartNew(() =>
            {
                ConnectCameraTask();
            });
        }

        /// <summary>
        /// 连接相机
        /// </summary>
        public void ConnectCameraTask()
        {
            if (_cameraService == null)
            {
                _logger.LogError("相机服务模块未初始化！");
                return;
            }

            if (CameraInfo == null)
            {
                _logger.LogError("未发现相机！请检查设备是否连接！");
                return;
            }

            // 获取相机状态
            CameraInfoModel camm = _cameraService.GetCameraInfo();
            if (camm.Status == "已连接")
            {
                _logger.LogWarning("相机已连接！");
                return;
            }

            OkEyeCode flag = _cameraService.ConnectCamera(CameraInfo);
            if (flag == OkEyeCode.Ok)
            {
                _logger.LogInformation("连接相机成功！");
            }
            else
            {
                _logger.LogWarning("相机连接失败");
                return;
            }

            CameraInfoModel curCameraInfo = _cameraService.GetCameraInfo();

            // 更新界面
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (SelectedIndex == -1)
                    return;
                CameraInfo = curCameraInfo;
                CamList[SelectedIndex] = curCameraInfo;

                NavigationParameters pairs = new NavigationParameters();
                pairs.Add("CamBand", _camBandList[SelectedIndex]);

                RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera",
                    (NavigationResult nr) =>
                    {
                        var error = nr.Error;
                        var result = nr.Result;
                    }, pairs);
            }));
        }
        
        /// <summary>
        /// 发现相机事件,启动线程扫描设备
        /// </summary>
        public void OnDiscoverCamera(string commandType)
        {
            // 启动任务，扫描设备
            Task.Factory.StartNew(() =>
            {
                ScanDeviceTask();
            });
        }

        /// <summary>
        /// 启动程序后，创建线程，定时扫描设备
        /// </summary>
        public void ScanDeviceTask()
        {
            _logger.LogInformation("扫描相机...");
            // 创建线程，定时扫描
            int count = 0;
            int MaxCount = 5;
            while (true)
            {
                if (count >= MaxCount)
                    break;

                DiscoverCamera();
                if (CamList.Count > 0)
                    break;
                // 10秒扫描一次
                Thread.Sleep(1000);
                count++;
            }

            if (CamList.Count > 0)
            {
                _logger.LogInformation("发现相机数量：" + CamList.Count);
            }
            else
            {
                _logger.LogWarning("发现相机数量：" + CamList.Count);
            }
        }

        /// <summary>
        /// 发现相机
        /// </summary>
        public void DiscoverCamera()
        {
            lock (CamList)
            {
                if (_cameraService == null)
                {
                    _logger.LogError("相机服务模块未初始化！");
                    return;
                }

                if (CamList == null)
                {
                    CamList = new List<CameraInfoModel>();
                }

                List<CameraInfoModel> camList = new List<CameraInfoModel>();
                // 扫描虚拟相机
               
                foreach (var camname in _camBandList)
                {
                    _cameraService = _container.Resolve<ICameraService>(camname);
                    camList = camList.Concat(_cameraService.DiscoveryDeviceList()).ToList<CameraInfoModel>();

                }
                
                CamList = camList;
                if (camList.Count > 0)
                {

                    CameraInfoModel tmpCameraInfo = camList[0];
                    CameraInfo = tmpCameraInfo;
                    SelectedIndex = 0;
                    _cameraService = _container.Resolve<ICameraService>(_camBandList[SelectedIndex]);
                }
                else
                {
                    CameraInfo = null;
                }

                // 检查相机IP和用户IP是否在相同子网段下
                if (CameraInfo != null)
                {
                    string[] camIP = CameraInfo.CameraIP.Split('.');
                    string[] userIP = CameraInfo.UserIP.Split('.');
                    if (camIP[0] != userIP[0] || camIP[1] != userIP[1] || camIP[2] != userIP[2])
                    {
                        _logger.LogWarning("相机IP和用户IP不在同一子网段！请重新配置！");
                    }
                }
            }
        }

        /// <summary>
        /// 导航到视图
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}




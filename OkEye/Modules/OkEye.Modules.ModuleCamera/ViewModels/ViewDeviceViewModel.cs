using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using static System.Net.Mime.MediaTypeNames;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    
    public class DeviceInfo
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string camIP;
        public string CameraIP
        {
            get { return camIP; }
            set { camIP = value; }
        }

        private string camStatus;
        public string CameraStatus
        {
            get { return camStatus; }
            set { camStatus = value; }
        }
    }

    public class ViewDeviceViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message { get; private set; }

        private DeviceInfo _deviceInfo;
        public DeviceInfo DeviceInfo
        {
            get { return _deviceInfo; }
            set { SetProperty(ref _deviceInfo, value); }
        }

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

        private IRegionManager _regionManager;
        private ICameraService _cameraService;
        public IDialogService _dialogService;
        private Logger<ViewDeviceViewModel> _logger;

        public DelegateCommand OpenIpConfigDialogCommand { get; private set; }
        public DelegateCommand ConnectCameraCommand { get; private set; }
        public DelegateCommand DisconnectCameraCommand { get; private set; }
        public DelegateCommand DiscoverCameraCommand { get; private set; }

        private Thread scanDeviceThr;

        delegate void ConnectCameraCallBack(CameraInfoModel caminfo);

        ConnectCameraCallBack connectCameraCallBack;

        /// <summary>
        /// 构造函数，注入依赖，包含区域管理器，消息服务，相机服务，对话框服务，日志记录器
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="messageService"></param>
        /// <param name="cameraService"></param>
        /// <param name="dialogService"></param>
        /// <param name="logger"></param>
        public ViewDeviceViewModel(IRegionManager regionManager, IMessageService messageService,
            ICameraService cameraService,
            IDialogService dialogService, Logger<ViewDeviceViewModel> logger) :
            base(regionManager)
        {
            _regionManager = regionManager; // 区域服务
            _cameraService = cameraService; ;   // 相机服务
            _dialogService = dialogService;        // 对话框服务
            _logger = logger;
            
            ConnectCameraCommand = new DelegateCommand(OnConnectCameraCommand);                 // 连接相机命令
            DisconnectCameraCommand = new DelegateCommand(OnDisconnectCameraCommand);        // 断开相机命令
            DiscoverCameraCommand = new DelegateCommand(OnDiscoverCamera);                                 // 发现相机命令
            OpenIpConfigDialogCommand = new DelegateCommand(OnOpenIpConfigDialogCommand);  // 打开IP配置对话框命令

            // 扫描相机
            OnDiscoverCamera();
            
            _logger.LogInformation("启动设备模块");
        }

        private void OnDisconnectCameraCommand()
        {
            // 启动线程连接相机
            Thread connectCameraThr = new Thread(() => DisconnectCameraTask());
            connectCameraThr.Start();
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
                if (0 == _cameraService.DisconnectCamera(CameraInfo))
                {
                    _logger.LogInformation("关闭相机成功！");

                    // 更新界面
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        CameraInfoModel curCameraInfo = _cameraService.GetCameraInfo();
                        CameraInfo = null;
                        CameraInfo = curCameraInfo;

                        List<CameraInfoModel> tmpcamlist = CamList;
                        tmpcamlist[0] = curCameraInfo;
                        CamList = new List<CameraInfoModel>();
                        CamList = tmpcamlist;
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
        public void OnOpenIpConfigDialogCommand()
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
                        OnDiscoverCamera();
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
        public void OnConnectCameraCommand()
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

            int flag = _cameraService.ConnectCamera(CameraInfo);
            if (flag == 0)
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
                CameraInfo = null;
                CameraInfo = curCameraInfo;
                List<CameraInfoModel> tmpcamlist = CamList;
                tmpcamlist[0] = curCameraInfo;
                CamList = new List<CameraInfoModel>();
                CamList = tmpcamlist;
                RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera",
                    (NavigationResult nr) =>
                    {
                        var error = nr.Error;
                        var result = nr.Result;
                    });
            }));
        }

        /// <summary>
        /// 更新相机信息到界面
        /// </summary>
        /// <param name="cameraInfo"></param>
        public void ConnectCameraUpdate(CameraInfoModel cameraInfo)
        {
            CameraInfo.Status = cameraInfo.Status;
            CamList[0].Status = CameraInfo.Status;
            _regionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera",
                (NavigationResult nr) =>
                {
                    var error = nr.Error;
                    var result = nr.Result;
                });

        }

        /// <summary>
        /// 发现相机事件,启动线程扫描设备
        /// </summary>
        public void OnDiscoverCamera()
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

                List<CameraInfoModel> camList = _cameraService.DiscoveryDeviceList();
                CamList = camList;
                if (camList.Count > 0)
                {
                    CameraInfo = camList[0];
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




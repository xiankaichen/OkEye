using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

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
            set { SetProperty(ref _camList, value); }
        }

        private CameraInfoModel _cameraInfo;
        public CameraInfoModel CameraInfo
        {
            get { return _cameraInfo; }
            set { SetProperty(ref _cameraInfo, value); }
        }

        private ICameraService _cameraService;

        public IDialogService _dialogService;
        public DelegateCommand OpenIpConfigDialogCommand { get; private set; }

        public DelegateCommand ConnectCameraCommand { get; private set; }
        public DelegateCommand DisconnectCameraCommand { get; private set; }
        public DelegateCommand DiscoverCameraCommand{ get; private set; }


        private Thread scanDeviceThr;

        private Logger<ViewDeviceViewModel> _logger;

        public ViewDeviceViewModel(IRegionManager regionManager, IMessageService messageService, ICameraService cameraService,
            IDialogService dialogService, Logger<ViewDeviceViewModel> logger) :
            base(regionManager)
        {
            //Message = messageService.GetMessage();
            _cameraService = cameraService; ;
            _dialogService = dialogService;
            _logger = logger;

            _logger.LogInformation("启动设备模块");
            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            ConnectCameraCommand = new DelegateCommand(OnConnectCameraCommand);

            DiscoverCameraCommand = new DelegateCommand(OnDiscoverCamera);

            OpenIpConfigDialogCommand = new DelegateCommand(OnOpenIpConfigDialogCommand);

            scanDeviceThr = new Thread(() => StartScanDevice());
            scanDeviceThr.Start();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        public void OnOpenIpConfigDialogCommand()
        {
            _logger.LogInformation("配置相机IP或者电脑IP");
            DialogParameters param = new DialogParameters();
            param.Add("CameraIP", CameraInfo.CameraIP);
            param.Add("UserIP", CameraInfo.UserIP);
            param.Add("UserMask", "255.255.255.0");
            param.Add("CameraMask", "255.255.255.0");
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
                    _logger.LogInformation("重新扫描设备...");
                    OnDiscoverCamera();
                    _logger.LogInformation("扫描设备完成");
                }
                else
                {
                    _logger.LogInformation("取消配置相机IP或者电脑IP");
                }
            });
        }

        public void OnConnectCameraCommand()
        {
            // 启动线程连接相机
            Thread connectCameraThr = new Thread(() => StartConnectCamera());
            connectCameraThr.Start();


        }

        //public CameraInfoModel GetCameraInfo()
        //{
        //    return CameraInfo;
        //}

        public void StartConnectCamera()
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

            _cameraService.ConnectCamera(CameraInfo);
            _logger.LogInformation("连接相机成功！");

            CameraInfoModel curCameraInfo = _cameraService.GetCameraInfo();

            //CameraInfo = null;
            //CamList = null;
            CameraInfo.Status = curCameraInfo.Status;
            CamList[0].Status = curCameraInfo.Status;
            ConnectCameraCallBack connectCameraCallBack = new ConnectCameraCallBack(ConnectCameraUpdate);
            Dispatcher.CurrentDispatcher.Invoke(connectCameraCallBack, curCameraInfo);
        }

        delegate void ConnectCameraCallBack(CameraInfoModel caminfo);

        public void ConnectCameraUpdate(CameraInfoModel cameraInfo)
        {
            CameraInfo.Status = cameraInfo.Status;
            CamList[0].Status = CameraInfo.Status;
            RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera");
        }


        // 启动程序后，创建线程，定时扫描设备
        public void StartScanDevice()
        {
            // 创建线程，定时扫描
            while (true)
            {

                _logger.LogInformation("扫描是否有新相机！");
                OnDiscoverCamera();

                // 10秒扫描一次
                Thread.Sleep(10000);
            }


        }

        
        public void OnDiscoverCamera()
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
                _logger.LogInformation("发现相机数量：" + camList.Count);
            }
        }
    }
}

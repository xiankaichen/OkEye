using System.Collections.Generic;
using System.Threading;
using System.Windows.Documents;
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

        public ViewDeviceViewModel(IRegionManager regionManager, IMessageService messageService, ICameraService cameraService,
            IDialogService dialogService) :
            base(regionManager)
        {
            //Message = messageService.GetMessage();
            _cameraService = cameraService; ;
            _dialogService = dialogService;

            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            ConnectCameraCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera");
            });

            DiscoverCameraCommand = new DelegateCommand(DiscoverCamera);

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
                    DiscoverCamera();
                }
            });
        }

        // 启动程序后，创建线程，定时扫描设备
        public void StartScanDevice()
        {
            // 创建线程，定时扫描
            while (true)
            {
                DiscoverCamera();

                // 10秒扫描一次
                Thread.Sleep(10000);
            }


        }

        
        public void DiscoverCamera()
        {
            lock (CamList)
            {
                if (_cameraService == null)
                    return;
                if (CamList == null)
                {
                    CamList = new List<CameraInfoModel>();
                }

                List<CameraInfoModel> camList = _cameraService.DiscoveryDeviceList();
                CamList = camList;
                if (camList.Count > 0)
                    CameraInfo = camList[0];
                else
                {
                    CameraInfo = null;
                }
            }
        }
    }
}

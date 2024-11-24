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
using System.Threading.Tasks;
using OpenCvSharp;
using Prism.Events;
using OkEye.Modules.ModuleCamera.Events;
using System.Windows.Media;
using HandyControl.Controls;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Ioc;
using System.Reflection.Metadata;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    /// <summary>
    /// 相机视图模型，包含相机拍照，断开，显示图像，相机参数，拍照参数的显示与设置
    /// </summary>
    public class ViewCameraViewModel : RegionViewModelBase
    {
        private ICameraService _cameraService;                       // 相机服务
        private IEventAggregator _imageAggregator;              // 图片聚合器，支持更新图片，深度图和点云数据的发送
        private Logger<ViewCameraViewModel> _logger;      // 日志记录器
        private readonly IContainerExtension _container;        // 容器扩展


        private bool isSnapRepeat = false;  // 是否在连续拍照

        public DelegateCommand DisconnectCameraCommand { get; private set; }       // 按钮事件，断开相机命令
        public DelegateCommand SnapOnceCommand { get; private set; }                     // 按钮事件，单次拍照命令
        public DelegateCommand SnapRepeatCommand { get; private set; }                  // 按钮事件，连续拍照命令
        public DelegateCommand ShowCloudCommand { get; private set; }                   // 按钮事件，显示点云命令
        public DelegateCommand ShowDepthCommand { get; private set; }                   // 按钮事件，显示深度图命令
        public DelegateCommand ShowImageCommand { get; private set; }                   // 按钮事件，显示图像命令
        public DelegateCommand SaveFrameCommand { get; private set; }                    // 按钮事件，保存图像命令
       
        public DelegateCommand<CameraInfoModel> PropertyValueChangedCommand { get; private set; }       // 相机属性窗口值发生改变

        // 单次拍照按钮背景色
        SolidColorBrush _onceSnapButtonBackground;
        public SolidColorBrush OnceSnapButtonBackground
        {
            get { return _onceSnapButtonBackground; }
            set { SetProperty(ref _onceSnapButtonBackground, value); }
        }

        // 连续拍照按钮背景色
        SolidColorBrush _repeatSnapButtonBackground;
        public SolidColorBrush RepeatSnapButtonBackground
        {
            get { return _repeatSnapButtonBackground; }
            set { SetProperty(ref _repeatSnapButtonBackground, value); }
        }

        // 深度图按钮背景色
        SolidColorBrush _depthButtonBackground;
        public SolidColorBrush DepthButtonBackground
        {
            get { return _depthButtonBackground; }
            set { SetProperty(ref _depthButtonBackground, value); }
        }
        // 点云按钮的背景色
        SolidColorBrush _cloudButtonBackground;
        public SolidColorBrush CloudButtonBackground
        {
            get { return _cloudButtonBackground; }
            set { SetProperty(ref _cloudButtonBackground, value); }
        }
        // 图像按钮的背景色
        SolidColorBrush _imageButtonBackground;
        public SolidColorBrush ImageButtonBackground
        {
            get { return _imageButtonBackground; }
            set { SetProperty(ref _imageButtonBackground, value); }
        }
        
        // 相机信息
        private CameraInfoModel cameraInfo;
        public CameraInfoModel CameraInfo
        {
            get { return cameraInfo; }
            set { SetProperty(ref cameraInfo, value); }
        }


        /// <summary>
        /// 相机页面的构造函数，包含相机拍照，断开，显示图像，相机参数，拍照参数的显示与设置
        /// </summary>
        /// <param name="regionManager"></param>         页面区域管理器
        /// <param name="cameraService"></param>           相机服务
        /// <param name="logger"></param>                        日志服务
        /// <param name="imageAggregator"></param>      显示图像聚合事件
        public ViewCameraViewModel(IRegionManager regionManager,
            Logger<ViewCameraViewModel> logger, IEventAggregator imageAggregator,
            IContainerExtension container
            ) :
            base(regionManager)
        {
            _imageAggregator = imageAggregator;
            _logger = logger;
            _container = container;

            _logger.LogInformation("初始化相机模块");

            OnceSnapButtonBackground = new SolidColorBrush(Color.FromRgb(103,58,183));
            RepeatSnapButtonBackground = new SolidColorBrush(Color.FromRgb(103,58,183));

            DepthButtonBackground = new SolidColorBrush(Color.FromArgb(200,103,58,183));
            CloudButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103,58,183));
            ImageButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103,58,183));

            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            PropertyValueChangedCommand = new DelegateCommand<CameraInfoModel>(OnPropertyValueChangedCommand);

            DisconnectCameraCommand = new DelegateCommand(OnDisconnectCameraCommand );
            SnapOnceCommand = new DelegateCommand(OnSnapOnceCommand);
            SnapRepeatCommand = new DelegateCommand(OnSnapRepeatCommand);
            ShowCloudCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");
                DepthButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));
                CloudButtonBackground = new SolidColorBrush(Colors.Orange); 
                ImageButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));
            });
            ShowDepthCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewDepth");
                DepthButtonBackground = new SolidColorBrush(Colors.Orange);
                CloudButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));
                ImageButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));

            });
            ShowImageCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewImage");
                DepthButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));
                CloudButtonBackground = new SolidColorBrush(Color.FromArgb(200, 103, 58, 183));
                ImageButtonBackground = new SolidColorBrush(Colors.Orange); 
            });

            SaveFrameCommand = new DelegateCommand(() =>
            {
                // 判断是否有数据
                if (_cameraService == null)
                {
                    _logger.LogError("相机服务模块未初始化！");
                    return;
                }
                // 获取保存帧数据的路径 存在程序的data/Images文件夹下，并按照日期时间命名文件夹，数据保存在该文件夹下
                string savePath = AppDomain.CurrentDomain.BaseDirectory + "data\\Images\\" + DateTime.Now.ToString("yyyyMMddHHmmss") +"\\";
                // 调用cameraService的保存图像函数
                if (OkEyeCode.Ok ==_cameraService.SaveFrame(savePath))
                {
                    _logger.LogInformation("保存图像成功！" + savePath);
                    // 打开文件所在的位置
                    Process.Start("explorer.exe", savePath);

                }
                else
                {
                    _logger.LogWarning("保存图像失败！");
                }
            });


            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewImage", r =>
            {
               // string err = r.Error.ToString();
            });
            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewDepth");
            RegionManager.RequestNavigate(RegionNames.FrameDataRegion, "ViewCloud");

            

        }
        
        /// <summary>
        /// 启动单次拍照任务，执行单次拍摄
        /// </summary>
        private void OnSnapOnceCommand()
        {
            // 启动线程连接相机
            Thread connectCameraThr = new Thread(() => SnapOnceTask());
            connectCameraThr.Start();
        }

        /// <summary>
        /// 单次拍照动作
        /// </summary>
        private void SnapOnceTask()
        {
            // 更新界面
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                OnceSnapButtonBackground = new SolidColorBrush(Colors.Orange);  // 更新按钮颜色
            }));

            // 拍照
            Snap();

            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                OnceSnapButtonBackground = new SolidColorBrush(Color.FromRgb(103,58,183)); // 更新按钮颜色
            }));
        }

        /// <summary>
        /// 启动任务连续拍照，每次拍照结束后等待1s，然后再次拍照，直到再次按下拍照按钮，停止拍照
        /// </summary>
        private void OnSnapRepeatCommand()
        {
            if (isSnapRepeat == true)
            {
                isSnapRepeat = !isSnapRepeat;
                return;
            }
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                RepeatSnapButtonBackground = new SolidColorBrush(Colors.Orange);
            }));

            Task.Run(() =>
            {
                isSnapRepeat = !isSnapRepeat;
                while (true)
                {
                    // 拍照
                    Snap();
                    // 休眠一秒
                    Thread.Sleep(1000);

                    // 检查是否需要停止拍照
                    if (isSnapRepeat == false)
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            RepeatSnapButtonBackground = new SolidColorBrush(Color.FromRgb(103, 58, 183));  // 更新界面
                        }));
                        break;
                    }
                }
            });
        }

        /// <summary>
        /// 拍照，仅一次，无界面设置内容
        /// </summary>
        private void Snap()
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

            // 计算拍照耗时，单位ms
            Stopwatch sw = new Stopwatch();
            sw.Start();
            OkFrameData frameData = new OkFrameData();
            if (OkEyeCode.Ok == _cameraService.Capture(ref frameData))
            {
                _imageAggregator.GetEvent<ImagePubSubEvent>().Publish(frameData.image); // 更新图片到界面
                _imageAggregator.GetEvent<DepthPubSubEvent>().Publish(frameData.depth); // 更新深度图到界面
                _imageAggregator.GetEvent<CloudPubSubEvent>().Publish(frameData.cloud); // 更新点云到界面
                _logger.LogInformation("拍照成功！");
            }
            else
            {
                _logger.LogWarning("拍照失败！");
            }

            sw.Stop();
            _logger.LogInformation("拍照耗时：" + sw.ElapsedMilliseconds + "ms");
            // 点云数量打印到日志
            _logger.LogInformation("点云数量：" + frameData.cloudSize);
        }

        /// <summary>
        /// 按钮命令，断开相机连接
        /// </summary>
        private void OnDisconnectCameraCommand()
        {
            if (isSnapRepeat == true)
            {
                // 停止连续拍照
                MessageBox.Show("正在连续拍照，请先关闭连续拍照！", "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // 启动线程连接相机
            
            Thread connectCameraThr = new Thread(() => DisconnectCameraTask());
            connectCameraThr.Start();
        }

        /// <summary>
        /// 断开相机
        /// </summary>
        private void DisconnectCameraTask()
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
            if (OkEyeCode.Ok == _cameraService.DisconnectCamera(camm))
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


        public void OnPropertyValueChangedCommand(CameraInfoModel camInfos)
        {
            if (camInfos == null )
            {
                return;
            }

            OkEyeCode flag = _cameraService.SetCameraParam(camInfos);
            if (flag == OkEyeCode.Ok)
            {
                _logger.LogInformation("相机参数设置成功");
            }
            else
            {
                _logger.LogWarning("参数设置失败!");
            }

        }

        /// <summary>
        /// 导航到页面时触发
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("CamBand"))
            {
                string camBand = navigationContext.Parameters.GetValue<string>("CamBand");
                _logger.LogInformation("导航到相机页面，参数：" + camBand);
                _cameraService = _container.Resolve<ICameraService>(camBand);
                CameraInfo = _cameraService.GetCameraInfo();
            }
        }
    }
}

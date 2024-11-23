using System.Configuration;
using LayUI.Wpf.Extensions;
using Microsoft.Extensions.Logging;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Events;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewMenuViewModel : RegionViewModelBase
    {
        private Logger<ViewCameraViewModel> _logger;        // 日志记录器
        private IDialogService _dialgoService;                             // 对话框服务
        private IEventAggregator _aggregator;                             // 事件聚合器

        public DelegateCommand OpenAboutDialogCommand { get; private set; }                            // 打开关于对话框命令
        public DelegateCommand ConnectCameraCommand { get; private set; }               // 连接相机命令
        public DelegateCommand DisconnectCameraCommand { get; private set; }          // 断开相机命令
        public DelegateCommand DiscoverCameraCommand { get; private set; }              // 刷新相机命令
        public DelegateCommand OpenIpConfigDialogCommand { get; private set; }       // IP配置对话框命令
        public DelegateCommand CloseAppCommand { get; private set; }                         // 关闭程序命令

        // 语言设置命令
        public DelegateCommand ChineseLangCommand { get; private set; }
        public DelegateCommand EnglishLangCommand { get; private set; }

        /// <summary>
        /// 菜单栏视图模型
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        /// <param name="logger"></param>
        public ViewMenuViewModel(IRegionManager regionManager, IDialogService dialogService,
            Logger<ViewCameraViewModel> logger, IEventAggregator aggregator) :
            base(regionManager)
        {
            _logger = logger;                               // 注入日志服务
            _dialgoService = dialogService;         // 注入对话框服务
            _aggregator = aggregator;               // 注入事件聚合器

            RegistCommand();    // 注册命令，绑定菜单栏的动作命令

            _logger.LogInformation("初始化菜单模块");
        }

        public void RegistCommand()
        {
            // 关闭程序命令回调
            CloseAppCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("CloseApp");
            });

            // 关于对话框命令回调
            OpenAboutDialogCommand = new DelegateCommand(() =>
            {
                AboutDialog about = new AboutDialog();
                _dialgoService.ShowDialog("AboutDialog");
            });
            // IP配置对话框命令回调
            OpenIpConfigDialogCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("OpenIpConfigDialog");
            });

            // 连接相机命令回调
            ConnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("ConnectCamera");
            });
            // 断开相机命令回调
            DisconnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DisconnectCamera");
            });
            // 刷新相机命令回调
            DiscoverCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DiscoverCamera");
            });

            // 语言设置命令回调
            ChineseLangCommand = new DelegateCommand(() =>
            {
                LanguageExtension.LoadResourceKey("zh_CN");
                // 更新语言设置到配置文件app.conig中
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["Language"].Value = "zh_CN";//
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
            });
            EnglishLangCommand = new DelegateCommand(() =>
            {
                LanguageExtension.LoadResourceKey("en_US");
                // 程序所在的路径
               
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["Language"].Value = "en_US";//
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
            });
            return;
        }

        /// <summary>
        ///  页面导航事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}

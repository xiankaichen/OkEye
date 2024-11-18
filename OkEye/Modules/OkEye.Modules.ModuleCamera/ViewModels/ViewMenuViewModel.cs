using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Views;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewMenuViewModel : RegionViewModelBase
    {
        private Logger<ViewCameraViewModel> _logger;        // 日志记录器
        private IDialogService _dialgoService;                             // 对话框服务

        public DelegateCommand OpenAboutDialog { get; private set; }    // 打开关于对话框命令

        /// <summary>
        /// 菜单栏视图模型
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        /// <param name="logger"></param>
        public ViewMenuViewModel(IRegionManager regionManager, IDialogService dialogService,
            Logger<ViewCameraViewModel> logger) :
            base(regionManager)
        {
            _logger = logger;                           // 注入日志服务
            _dialgoService = dialogService;     // 注入对话框服务

            // 关于对话框命令回调
            OpenAboutDialog = new DelegateCommand(() =>
            {
                AboutDialog about = new AboutDialog();
                _dialgoService.ShowDialog("AboutDialog");
            });

            _logger.LogInformation("初始化菜单模块");
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

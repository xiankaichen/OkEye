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
        private Logger<ViewCameraViewModel> _logger;    // 日志记录器
        private IDialogService _dialgoService;

        public DelegateCommand OpenAboutDialog { get; private set; }

        public ViewMenuViewModel(IRegionManager regionManager, IDialogService dialogService,
            Logger<ViewCameraViewModel> logger) :
            base(regionManager)
        {
            _logger = logger;
            _logger.LogInformation("初始化菜单模块");
            _dialgoService = dialogService;

            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            OpenAboutDialog = new DelegateCommand(() =>
            {
                AboutDialog about = new AboutDialog();
                _dialgoService.ShowDialog("AboutDialog");
            });

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

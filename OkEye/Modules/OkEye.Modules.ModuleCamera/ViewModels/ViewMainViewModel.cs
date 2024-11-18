using Microsoft.Extensions.Logging;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Views;
using OkEye.Services.Interfaces;
using Prism.Ioc;
using Prism.Regions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    /// <summary>
    /// 主页面视图模型
    /// </summary>
    public class ViewMainViewModel : RegionViewModelBase
    {
        private Logger<ViewMainViewModel> _logger;  // 日志服务
        
        public ViewMainViewModel(IRegionManager regionManager, Logger<ViewMainViewModel> logger) :
            base(regionManager)
        {
            _logger = logger;   // 注入日志服务

            _logger.LogInformation("初始化主界面模块");
        }

        /// <summary>
        /// 页面导航到触发事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}

using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewStatusBarViewModel : RegionViewModelBase
    {
        private Logger<ViewStatusBarViewModel> _logger;    // 日志记录器

        /// <summary>
        /// CPU使用率
        /// </summary>
        private string _cpurate;
        public string CpuRate
        {
            get { return _cpurate; }
            set { SetProperty(ref _cpurate, value); }
        }

        /// <summary>
        /// 内存使用率
        /// </summary>
        private string _ramrate;
        public string RamRate
        {
            get { return _ramrate; }
            set { SetProperty(ref _ramrate, value); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager"></param>    区域管理器
        /// <param name="logger"></param>                   日志服务
        /// <param name="systermInfoService"></param>   系统信息服务
        public ViewStatusBarViewModel(IRegionManager regionManager, 
            Logger<ViewStatusBarViewModel> logger, ISystemInfoService systermInfoService) :
            base(regionManager)
        {
            _logger = logger;

            // 启动线程，获取CPU和磁盘使用率
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                while (true)
                {
                    // 获取CPU使用率
                    CpuRate = systermInfoService.GetCupRate();
                    RamRate = systermInfoService.GetRamRate();
                    System.Threading.Thread.Sleep(5000);
                }
            }));
            thread.Start();
        }

        /// <summary>
        /// 导航到页面的事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO:do something
        }
    }
}

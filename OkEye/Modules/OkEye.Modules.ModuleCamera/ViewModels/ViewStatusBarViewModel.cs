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
        private string _cpurate;
        public string CpuRate
        {
            get { return _cpurate; }
            set { SetProperty(ref _cpurate, value); }
        }

        private string _ramrate;
        public string RamRate
        {
            get { return _ramrate; }
            set { SetProperty(ref _ramrate, value); }
        }

        private Logger<ViewStatusBarViewModel> _logger;    // 日志记录器


        public ViewStatusBarViewModel(IRegionManager regionManager, IMessageService messageService,
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



        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

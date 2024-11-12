using Microsoft.Extensions.Logging;
using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Views;
using OkEye.Services.Interfaces;
using Prism.Ioc;
using Prism.Regions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewMainViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private Logger<ViewMainViewModel> _logger;

        public ViewMainViewModel(IRegionManager regionManager, IMessageService messageService, 
            ICameraService cameraService, Logger<ViewMainViewModel> logger) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
            _logger = logger;

            _logger.LogInformation("初始化主界面模块");
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

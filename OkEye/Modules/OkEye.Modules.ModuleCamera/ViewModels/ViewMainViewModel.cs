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

        public ViewMainViewModel(IRegionManager regionManager, IMessageService messageService, ICameraService cameraService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

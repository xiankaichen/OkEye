using OkEye.Core;
using OkEye.Core.Mvvm;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewCameraViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand DisconnectCameraCommand { get; private set; }

        public ViewCameraViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();

            // 将ViewDevice 和 ViewMain 两个视图添加到MainContentRegion中

            DisconnectCameraCommand = new DelegateCommand(() =>
            {
                RegionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewDevice");
            });

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

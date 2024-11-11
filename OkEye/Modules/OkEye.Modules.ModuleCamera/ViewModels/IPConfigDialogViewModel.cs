using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class IPConfigDialogViewModel : BindableBase, IDialogAware
    {
        public string Title { get; }

        private string _cameraIP;
        public string CameraIP
        {
            get { return _cameraIP; }
            set { SetProperty(ref _cameraIP, value); }
        }

        private string _cameraMask;
        public string CameraMask
        {
            get { return _cameraMask; }
            set { SetProperty(ref _cameraMask, value); }
        }

        private string userIP;
        public string UserIP
        {
            get { return userIP; }
            set { SetProperty(ref userIP, value); }
        }

        private string userMask;
        public string UserMask
        {
            get { return userMask; }
            set { SetProperty(ref userMask, value); }
        }


        public event Action<IDialogResult> RequestClose;
        public DelegateCommand YesDialogCommand { get; private set; }
        public DelegateCommand NoDialogCommand { get; private set; }


        public IPConfigDialogViewModel()
        {
            YesDialogCommand = new DelegateCommand(() =>
            {
                DialogParameters param = new DialogParameters();

                param.Add("CameraIP", CameraIP);
                param.Add("CameraMask", CameraMask);
                param.Add("UserIP", UserIP);
                param.Add("UserMask", UserMask);

                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
            });
            NoDialogCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            });
        }




        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            CameraIP = parameters.GetValue<string>("CameraIP");
            CameraMask = parameters.GetValue<string>("CameraMask");
            UserIP = parameters.GetValue<string>("UserIP");
            UserMask = parameters.GetValue<string>("UserMask");
        }

        
    }
}

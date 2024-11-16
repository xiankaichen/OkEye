using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class AboutDialogViewModel : BindableBase, IDialogAware
    {
        private string title;
        public string Title { get; set; }

        private Logger<IPConfigDialogViewModel> _logger;
        public AboutDialogViewModel(Logger<IPConfigDialogViewModel> logger)
        {
            Title = "关于";

            _logger = logger;
            _logger.LogInformation("打开关于窗口窗口");
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

    }
}

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

            // 去掉最小化和最大化按钮，只保留关闭按钮
            // 为了避免在窗口标题栏上显示最小化和最大化按钮，需要在窗口的Style属性中设置WindowStyle属性为None
            // 为了避免在窗口标题栏上显示关闭按钮，需要在窗口的Style属性中设置ResizeMode属性为NoResize
            // 为了避免在窗口标题栏上显示图标，需要在窗口的Style属性中设置ShowIcon属性为False
            // 为了避免在窗口标题栏上显示标题，需要在窗口的Style属性中设置ShowInTaskbar属性为False

            
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

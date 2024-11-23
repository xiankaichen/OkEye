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
    /// <summary>
    /// 关于窗口视图模型
    /// </summary>
    public class AboutDialogViewModel : BindableBase, IDialogAware
    {
        private Logger<IPConfigDialogViewModel> _logger;    // 日志服务

        /// <summary>
        /// 对话框标题
        /// </summary>
        private string title;
        public string Title { get; set; }

        // 关闭对话框命令
        public DelegateCommand CloseDialogCommand { get; private set; }

        /// <summary>
        /// 对话框服务
        /// </summary>
        /// <param name="logger"></param>   日志服务
        public AboutDialogViewModel(Logger<IPConfigDialogViewModel> logger)
        {
            Title = "关于";

            _logger = logger;   // 注入日志服务
            CloseDialogCommand = new DelegateCommand(() =>
            {
                // 关闭窗口
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));

            });
            _logger.LogInformation("打开关于窗口窗口");
        }

        public event Action<IDialogResult> RequestClose;    // 关闭对话框事件

        /// <summary>
        /// 是否能关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 对话框关闭事件
        /// </summary>
        public void OnDialogClosed()
        {
            
        }

        /// <summary>
        /// 对话框打开事件
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

    }
}

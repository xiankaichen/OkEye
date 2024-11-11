using Microsoft.Extensions.Logging;
using NLog;
using Prism.Mvvm;

namespace OkEye.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "OkEye Viewer V1.2";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Logger<MainWindowViewModel> _logger;

        public MainWindowViewModel(Logger<MainWindowViewModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("启主程序VM模块");
        }
    }
}

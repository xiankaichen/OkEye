using System.Configuration;
using System.Runtime.CompilerServices;
using LayUI.Wpf.Extensions;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using NLog;
using OkEye.Modules.ModuleCamera.Events;
using OkEye.Modules.ModuleCamera.Views;
using OkEye.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace OkEye.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "OkEye Viewer ";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Logger<MainWindowViewModel> _logger;
        private IEventAggregator _aggregator;
        
        public MainWindowViewModel(Logger<MainWindowViewModel> logger, IEventAggregator aggregator)
        {
            _logger = logger;
            _aggregator = aggregator;

            // 初始化多语言服务
            string languageAppSetting = ConfigurationManager.AppSettings["Language"];
            LanguageExtension.LoadResourceKey(languageAppSetting);
            _aggregator.GetEvent<CameraPubSubEvent>().Subscribe((msg) =>
            {
                if (msg == "CloseApp")
                {
                    System.Windows.Application.Current.Shutdown();
                }
            });
            _logger.LogInformation("启主程序VM模块");

        }



    }
}

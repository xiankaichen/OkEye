using System.Configuration;
using System.Runtime.CompilerServices;
using LayUI.Wpf.Extensions;
using MaterialDesignColors;
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

            //// 设置主题
            //string themeAppSetting = ConfigurationManager.AppSettings["Theme"];
            //ModifyTheme(themeAppSetting);
            //// 设置主题颜色
            //string colorAppSetting = ConfigurationManager.AppSettings["PrimaryColor"];
            //ModifyThemePrimaryColor(colorAppSetting);

            // 订阅关闭程序事件
            _aggregator.GetEvent<AppPubSubEvent>().Subscribe((msg) =>
            {
                if (msg == "CloseApp")
                {
                    System.Windows.Application.Current.Shutdown();
                }
            });

            // 订阅最小化程序事件
            _aggregator.GetEvent<AppPubSubEvent>().Subscribe((msg) =>
            {
                if (msg == "MinimizeApp")
                {
                    System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
                }
            });

            // 订阅最大化程序事件
            _aggregator.GetEvent<AppPubSubEvent>().Subscribe((msg) =>
            {
                if (msg == "MaximizeApp")
                {
                    if (System.Windows.Application.Current.MainWindow.WindowState == System.Windows.WindowState.Maximized)
                    {
                        System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                    }
                    else
                    {
                        System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                    }
                }
            });

            _logger.LogInformation("启主程序VM模块");

        }

        /// <summary>
        /// 应用主题
        /// </summary>
        /// <param name="themeStyle"></param>
        private static void ModifyTheme(string themeStyle)
        {
            if (themeStyle == "Light")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();

                theme.SetBaseTheme(BaseTheme.Light);
                paletteHelper.SetTheme(theme);
            }
            else if (themeStyle == "Dark")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();

                theme.SetBaseTheme(BaseTheme.Dark);
                paletteHelper.SetTheme(theme);
            }
            else
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();

                theme.SetBaseTheme(BaseTheme.Inherit);
                paletteHelper.SetTheme(theme);
            }
        }

        /// <summary>
        /// 应用主题
        /// </summary>
        /// <param name="colorStyle"></param>
        private static void ModifyThemePrimaryColor(string colorStyle)
        {
            if (colorStyle == "Blue")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.Blue];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }
            else if (colorStyle == "Teal")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.Teal];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }
            else if (colorStyle == "Orange")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.Orange];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }
            else if (colorStyle == "DeepOrange")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.DeepOrange];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }
            else if (colorStyle == "Purple")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.Purple];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }
            else if (colorStyle == "DeepPurple")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.DeepPurple];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }

        }



    }
}

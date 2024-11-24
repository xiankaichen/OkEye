using System.Configuration;
using System.Drawing;
using LayUI.Wpf.Extensions;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using OkEye.Core.Mvvm;
using OkEye.Modules.ModuleCamera.Events;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.ViewModels
{
    public class ViewMenuViewModel : RegionViewModelBase
    {
        private Logger<ViewCameraViewModel> _logger;        // 日志记录器
        private IDialogService _dialgoService;                             // 对话框服务
        private IEventAggregator _aggregator;                             // 事件聚合器

        public DelegateCommand OpenAboutDialogCommand { get; private set; }                            // 打开关于对话框命令
        public DelegateCommand ConnectCameraCommand { get; private set; }               // 连接相机命令
        public DelegateCommand DisconnectCameraCommand { get; private set; }          // 断开相机命令
        public DelegateCommand DiscoverCameraCommand { get; private set; }              // 刷新相机命令
        public DelegateCommand OpenIpConfigDialogCommand { get; private set; }       // IP配置对话框命令
        public DelegateCommand CloseAppCommand { get; private set; }                         // 关闭程序命令

        // 语言设置命令
        public DelegateCommand ChineseLangCommand { get; private set; }
        public DelegateCommand EnglishLangCommand { get; private set; }

        // 主题设置命令
        public DelegateCommand LightThemeCommand { get; private set; }
        public DelegateCommand DarkThemeCommand { get; private set; }
        public DelegateCommand InheritThemeCommand { get; private set; }

        // 主题主色命令
        public DelegateCommand BluePrimaryColorCommand { get; private set; }
        public DelegateCommand LightBluePrimaryColorCommand { get; private set; }
        public DelegateCommand OrangePrimaryColorCommand { get; private set; }
        public DelegateCommand DeepOrangePrimaryColorCommand { get; private set; }
        public DelegateCommand PurplePrimaryColorCommand { get; private set; }
        public DelegateCommand DeepPurplePrimaryColorCommand { get; private set; }


        /// <summary>
        /// 菜单栏视图模型
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        /// <param name="logger"></param>
        public ViewMenuViewModel(IRegionManager regionManager, IDialogService dialogService,
            Logger<ViewCameraViewModel> logger, IEventAggregator aggregator) :
            base(regionManager)
        {
            _logger = logger;                               // 注入日志服务
            _dialgoService = dialogService;         // 注入对话框服务
            _aggregator = aggregator;               // 注入事件聚合器

            RegistCommand();    // 注册命令，绑定菜单栏的动作命令

            _logger.LogInformation("初始化菜单模块");
        }

        public void RegistCommand()
        {
            // 关闭程序命令回调
            CloseAppCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("CloseApp");
            });

            // 关于对话框命令回调
            OpenAboutDialogCommand = new DelegateCommand(() =>
            {
                AboutDialog about = new AboutDialog();
                _dialgoService.ShowDialog("AboutDialog");
            });
            // IP配置对话框命令回调
            OpenIpConfigDialogCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("OpenIpConfigDialog");
            });

            // 连接相机命令回调
            ConnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("ConnectCamera");
            });
            // 断开相机命令回调
            DisconnectCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DisconnectCamera");
            });
            // 刷新相机命令回调
            DiscoverCameraCommand = new DelegateCommand(() =>
            {
                _aggregator.GetEvent<CameraPubSubEvent>().Publish("DiscoverCamera");
            });

            // 语言设置命令回调
            ChineseLangCommand = new DelegateCommand(() =>
            {
                LanguageExtension.LoadResourceKey("zh_CN");
                // save language setting to th app.config file
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["Language"].Value = "zh_CN";//
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
            });
            EnglishLangCommand = new DelegateCommand(() =>
            {
                LanguageExtension.LoadResourceKey("en_US");
                // Save the language setting to the app.config file
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["Language"].Value = "en_US";//
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
            });

            // 置主题命令回调
            LightThemeCommand = new DelegateCommand(() =>
            {
                ModifyTheme("Light");
                SaveTheme("Light");
            });
            DarkThemeCommand = new DelegateCommand(() =>
            {
                ModifyTheme("Dark");
                SaveTheme("Dark");
            });
            InheritThemeCommand = new DelegateCommand(() =>
            {
                ModifyTheme("Inherit");
                SaveTheme("Inherit");
            });

            // 主题主色命令回调
            BluePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("Blue");
                SaveThemePrimaryColor("Blue");
            });
            LightBluePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("LightBlue");
                SaveThemePrimaryColor("LightBlue");
            });
            OrangePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("Orange");
                SaveThemePrimaryColor("Orange");
            });
            DeepOrangePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("DeepOrange");
                SaveThemePrimaryColor("DeepOrange");
            });
            PurplePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("Purple");
                SaveThemePrimaryColor("Purple");
            });
            DeepPurplePrimaryColorCommand = new DelegateCommand(() =>
            {
                ModifyThemePrimaryColor("DeepPurple");
                SaveThemePrimaryColor("DeepPurple");
            });
            return;
        }

        /// <summary>
        /// 保存主题
        /// </summary>
        /// <param name="theme"></param>
        private void SaveTheme(string theme)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["Theme"].Value = theme;//
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
        }

        /// <summary>
        /// 保存主题主色调
        /// </summary>
        /// <param name="colorStyle"></param>
        private void SaveThemePrimaryColor(string colorStyle)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["PrimaryColor"].Value = colorStyle;//
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//保存修改并刷新
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
            else if (colorStyle == "LightBlue")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.LightBlue];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }else if (colorStyle == "Orange")
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
            }else if (colorStyle == "DeepPurple")
            {
                var paletteHelper = new PaletteHelper();
                var theme = paletteHelper.GetTheme();
                System.Windows.Media.Color color = SwatchHelper.Lookup[MaterialDesignColor.DeepPurple];
                theme.SetPrimaryColor(color);
                paletteHelper.SetTheme(theme);
            }

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
            else if(themeStyle == "Dark")
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
        ///  页面导航事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //TODO: do something
        }
    }
}

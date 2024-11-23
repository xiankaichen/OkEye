using OkEye.Core;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel;
using System.Windows.Controls;
using OkEye.Modules.ModuleCamera.ViewModels;
using Prism.Mvvm;

namespace OkEye.Modules.ModuleCamera
{
    public class ModuleCameraModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;

        public ModuleCameraModule(IRegionManager regionManager, IContainerExtension container)
        {
            _regionManager = regionManager;
            _container = container;
            
           


        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

            RegionManager.UpdateRegions();
            _regionManager.RequestNavigate(RegionNames.MainRegion, "ViewMain");
            _regionManager.RequestNavigate(RegionNames.ContentRegionMenu, "ViewMenu");
            _regionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewDevice",
                (r) =>
                {
                    string s = r.Result.ToString();
                }); ;
            _regionManager.RequestNavigate(RegionNames.ContentRegionStatus, "ViewStatusBar");
            _regionManager.RequestNavigate(RegionNames.ContentRegionLog, "ViewLog");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<IPConfigDialog, IPConfigDialogViewModel>();
            containerRegistry.RegisterDialog<AboutDialog, AboutDialogViewModel>();

            // 注册数据显示区域
            containerRegistry.RegisterForNavigation<ViewCloud>();
            containerRegistry.RegisterForNavigation<ViewDepth>();
            containerRegistry.RegisterForNavigation<ViewImage>();

            containerRegistry.RegisterForNavigation<ViewMain>();
            containerRegistry.RegisterForNavigation<ViewDevice>();
            containerRegistry.RegisterForNavigation<ViewCamera>();
            containerRegistry.RegisterForNavigation<ViewStatusBar>();
            containerRegistry.RegisterForNavigation<ViewMenu>();

            containerRegistry.RegisterForNavigation<ViewLog>();
        }

        

    }
}
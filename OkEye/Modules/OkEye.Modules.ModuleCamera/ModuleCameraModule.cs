using OkEye.Core;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel;
using System.Windows.Controls;
using OkEye.Modules.ModuleCamera.ViewModels;

namespace OkEye.Modules.ModuleCamera
{
    public class ModuleCameraModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleCameraModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.MainRegion, "ViewMain");
            _regionManager.RequestNavigate(RegionNames.ContentRegionMenu, "ViewMenu");
            _regionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewDevice"); ;
            // //_regionManager.RequestNavigate(RegionNames.ContentRegionMain, "ViewCamera");
            _regionManager.RequestNavigate(RegionNames.ContentRegionStatus, "ViewStatusBar");
            _regionManager.RequestNavigate(RegionNames.ContentRegionLog, "ViewLog");


        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<IPConfigDialog, IPConfigDialogViewModel>();
            containerRegistry.RegisterDialog<AboutDialog, AboutDialogViewModel>();
            

            containerRegistry.RegisterForNavigation<ViewMain>();
            containerRegistry.RegisterForNavigation<ViewDevice>();
            containerRegistry.RegisterForNavigation<ViewCamera>();
            containerRegistry.RegisterForNavigation<ViewStatusBar>();
            containerRegistry.RegisterForNavigation<ViewMenu>();
            containerRegistry.RegisterForNavigation<ViewLog>();


        }

        
    }
}
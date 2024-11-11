using OkEye.Modules.ModuleCamera;
using OkEye.Services;
using OkEye.Services.Interfaces;
using OkEye.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace OkEye
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<ICameraService, CameraService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleCameraModule>();
        }
    }
}

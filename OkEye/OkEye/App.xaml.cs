using DryIoc;
using OkEye.Modules.ModuleCamera;
using OkEye.Services;
using OkEye.Services.Interfaces;
using OkEye.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using OkEye.Modules.ModuleCamera.ViewModels;
using OkEye.Modules.ModuleCamera.Views;
using Prism.Mvvm;

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
            containerRegistry.RegisterSingleton<ISystemInfoService, SystemInfoService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleCameraModule>();
        }


        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.SetMinimumLevel(LogLevel.Trace);
                configure.AddNLog();
            });


            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection).Container);
        }

        protected override Rules CreateContainerRules()
        {
            return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                .WithFuncAndLazyWithoutRegistration()
                .WithTrackingDisposableTransients()
                //.WithoutFastExpressionCompiler()
                .WithFactorySelector(Rules.SelectLastRegisteredFactory());
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<ViewImage, ImageCanvasViewMode>();
            ViewModelLocationProvider.Register<ViewDepth, DepthCanvasViewMode>();
            ViewModelLocationProvider.Register<ViewCloud, ViewCloudViewMode>();

        }
    }
}

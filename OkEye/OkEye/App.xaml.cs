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
using OkEye.Services.VirtualCamera;

namespace OkEye
{
    /// <summary>
    /// 系统启动类，全局配置和注册
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// 创建主窗体
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<ICameraService, VirtualCameraService>("VirtualCamera");
            containerRegistry.RegisterSingleton<ICameraService, AinsCameraService>("AinsCamera");
            containerRegistry.RegisterSingleton<ISystemInfoService, SystemInfoService>();
        }

        /// <summary>
        /// 配置模块目录
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleCameraModule>();
        }

        /// <summary>
        /// 创建容器扩展
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 创建容器规则
        /// </summary>
        /// <returns></returns>
        protected override Rules CreateContainerRules()
        {
            return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                .WithFuncAndLazyWithoutRegistration()
                .WithTrackingDisposableTransients()
                //.WithoutFastExpressionCompiler()
                .WithFactorySelector(Rules.SelectLastRegisteredFactory());
        }

        /// <summary>
        /// 配置视图模型定位器
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            //ViewModelLocationProvider.Register<ViewImage, ImageCanvasViewMode>();
            //ViewModelLocationProvider.Register<ViewDepth, DepthCanvasViewMode>();
            //ViewModelLocationProvider.Register<ViewCloud, ViewCloudViewMode>();

        }
    }
}

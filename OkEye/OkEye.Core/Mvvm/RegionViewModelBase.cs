using Prism.Regions;
using System;

namespace OkEye.Core.Mvvm
{
    /// <summary>
    /// 区域视图模型基类
    /// </summary>
    public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        protected IRegionManager RegionManager { get; private set; }    // 区域管理器

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager"></param>
        public RegionViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        /// <summary>
        /// 确认导航请求
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        /// <summary>
        /// 是否导航到当前页面
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 从外部导航到页面的时候触发
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 导航到页面的时候触发
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}

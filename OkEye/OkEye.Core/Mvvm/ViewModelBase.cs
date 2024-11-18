using Prism.Mvvm;
using Prism.Navigation;

namespace OkEye.Core.Mvvm
{
    /// <summary>
    /// 视图模型基类
    /// </summary>
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected ViewModelBase()
        {

        }
        /// <summary>
        /// 销毁
        /// </summary>
        public virtual void Destroy()
        {

        }
    }
}

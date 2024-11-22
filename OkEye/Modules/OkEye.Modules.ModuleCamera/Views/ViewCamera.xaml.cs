using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OkEye.Modules.ModuleCamera.Views
{
    /// <summary>
    /// ViewCamera.xaml 的交互逻辑
    /// </summary>
    public partial class ViewCamera : UserControl
    {
        public ViewCamera(IRegionManager regionManager, IContainerExtension container)
        {
            InitializeComponent();

            //重新刷新区域，否则导航点云图像和深度图页面失败
            RegionManager.SetRegionManager(this, container.Resolve<IRegionManager>());
            RegionManager.UpdateRegions();
        }

    }
}

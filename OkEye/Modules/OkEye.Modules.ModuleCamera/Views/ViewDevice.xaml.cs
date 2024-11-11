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
    /// ViewDevice.xaml 的交互逻辑
    /// </summary>
    public partial class ViewDevice : UserControl
    {
        public ViewDevice()
        {
            InitializeComponent();
        }

        private void _propertyGrid_PropertyValueChanged(object sender, Xceed.Wpf.Toolkit.PropertyGrid.PropertyValueChangedEventArgs e)
        {

        }
    }
}

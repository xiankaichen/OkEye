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
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace OkEye.Modules.ModuleCamera.Views
{
    /// <summary>
    /// MsgDialog.xaml 的交互逻辑
    /// </summary>
    public partial class IPConfigDialog : UserControl
    {
        public string Title { get; set; }

        public IPConfigDialog()
        {
            InitializeComponent();
        }
    }
}

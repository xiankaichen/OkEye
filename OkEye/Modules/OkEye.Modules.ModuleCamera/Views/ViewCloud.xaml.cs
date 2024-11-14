using Kitware.VTK;
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
    /// ViewCloud.xaml 的交互逻辑
    /// </summary>
    public partial class ViewCloud : UserControl
    {
        vtkRenderer renderer;
        vtkOrientationMarkerWidget orientWidget;

        public ViewCloud()
        {
            InitializeComponent();

            renderer = null;
            orientWidget = null;
        }

        private void pcViewerControl_Load(object sender, EventArgs e)
        {
            try
            {
                // 使用vtkRenderer将vtkActor添加到vtkRenderer中
                if (renderer == null)
                    renderer = pcViewerControl.RenderWindow.GetRenderers().GetFirstRenderer();


                // 添加一个独立的坐标系到右下角，缩放不改变大小，有x/y/z标签
                vtkAxesActor axes = vtkAxesActor.New();
                axes.SetTotalLength(1, 1, 1);
                axes.SetShaftType(0);
                axes.SetCylinderRadius(0.02);
                axes.SetAxisLabels(1);
                axes.SetConeRadius(0.1);
                axes.SetConeResolution(10);
                axes.SetTipType(1);

                //// 取消坐标系的x y z标签
                axes.SetXAxisLabelText("X");
                axes.SetYAxisLabelText("Y");
                axes.SetZAxisLabelText("Z");
                // 坐标轴字体大小
                vtkCaptionActor2D textAct = axes.GetXAxisCaptionActor2D();
                textAct.SetPosition2(0.1, 0.1);


                // 设置vtkOrientationMarkerWidget的位置
                if (orientWidget ==  null)
                {
                    orientWidget = vtkOrientationMarkerWidget.New();// 注意做为成员变量否则会被释放，导致崩溃
                }
                orientWidget.SetOrientationMarker(axes);
                orientWidget.SetInteractor(pcViewerControl.RenderWindow.GetInteractor());
                orientWidget.SetViewport(0.8, 0.0, 1.0, 0.2);
                orientWidget.SetEnabled(1);
                orientWidget.InteractiveOn();

                // 坐标系axes放在右下角窗口的位置
                renderer.AddActor(axes);





                // 打开渐变色背景开关
                renderer.GradientBackgroundOn();
                renderer.SetBackground2(10.0 / 255, 102.0 / 255, 148.0 / 255);
                renderer.SetBackground(0, 0, 0);


                // 添加一个视角，设置相机位置
                vtkCamera camera = renderer.GetActiveCamera();
                camera.SetPosition(0, 0, 10);
                camera.SetFocalPoint(0, 0, 0);
                camera.SetViewUp(0, 1, 0);
                camera.Azimuth(30);
                camera.Elevation(30);
                camera.Zoom(1);

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

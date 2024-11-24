﻿using Kitware.VTK;
using OpenCvSharp;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OkEye.Modules.ModuleCamera.Views
{
    /// <summary>
    /// 点云显示控件
    /// </summary>
    public partial class CloudCanvas : UserControl
    {
        vtkRenderer renderer;                                       // vtkRenderer对象，用于显示点云
        vtkOrientationMarkerWidget orientWidget;    // vtkOrientationMarkerWidget对象，用于显示坐标系

        // 点云依赖属性
        public Mat Cloud
        {
            get { return (Mat)GetValue(CloudProperty); }
            set
            {
                SetValue(CloudProperty, value);
            }
        }

        /// <summary>
        /// 点云依赖属性声明
        /// </summary>
        public static readonly DependencyProperty CloudProperty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CloudCanvas()
        {
            InitializeComponent();
            // 初始化3D视图，启动一个任务
            //Task.Factory.StartNew(() =>
            //{
            //Init3DViewer();
            //});
        }

        /// <summary>
        /// 依赖属性注册
        /// </summary>
        static CloudCanvas()
        {
            CloudProperty = DependencyProperty.Register("Cloud",
                typeof(Mat), typeof(CloudCanvas), new PropertyMetadata(new Mat(), 
                    new PropertyChangedCallback(OnCloudChanged)));
        }

        /// <summary>
        /// 依赖属性回调方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void OnCloudChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CloudCanvas p = d as CloudCanvas;

            if (p != null)
            {
               Mat cloud  = (Mat)e.NewValue;
               p.AddCloud2RendWindow(cloud);
            }
        }

        /// <summary>
        /// 初始化3D视图
        /// </summary>
        unsafe private void Init3DViewer()
        {
            try
            {
                // 使用vtkRenderer将vtkActor添加到vtkRenderer中
                
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
                orientWidget = vtkOrientationMarkerWidget.New();// 注意做为成员变量否则会被释放，导致崩溃
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
                //vtkCamera camera = renderer.GetActiveCamera();
                //camera.SetPosition(0, 0, 10);
                //camera.SetFocalPoint(0, 0, 0);
                //camera.SetViewUp(0, 1, 0);
                //camera.Azimuth(30);
                //camera.Elevation(30);
                //camera.Zoom(1);

                // 根据点云范围设置合适的相机位置
                double[] bounds = { -180,335, -260,242,724,790};
                double[] center = {76,0,750};
                center[0] = (bounds[0] + bounds[1]) / 2;
                center[1] = (bounds[2] + bounds[3]) / 2;
                center[2] = (bounds[4] + bounds[5]) / 2;
                double radius = Math.Sqrt((bounds[1] - bounds[0]) * (bounds[1] - bounds[0]) +
                    (bounds[3] - bounds[2]) * (bounds[3] - bounds[2]) +
                    (bounds[5] - bounds[4]) * (bounds[5] - bounds[4])) / 2;
                double distance = radius / Math.Sin(30 * Math.PI / 180);
                vtkCamera camera = renderer.GetActiveCamera();
                camera.SetFocalPoint(center[0], center[1], center[2]);
                camera.SetPosition(center[0], center[1], center[2] - distance * 2);
                camera.SetViewUp(0, -1, 0);
                camera.Azimuth(0);
                camera.Elevation(0);
                camera.Zoom(1.1);
                
            }
            catch (Exception ex)
            {
               
            }
        }

        /// <summary>
        /// 将点云数据添加到vtkRenderer中，启动一个任务
        /// </summary>
        /// <param name="cloud"></param>
        public void AddCloud2RendWindow(Mat cloud)
        {
            // 启动一个任务，将点云数据添加到vtkRenderer中
            Task.Factory.StartNew(() =>
            {
                ShowCloud(cloud);
            });
        }

        /// <summary>
        /// 显示点云
        /// </summary>
        /// <param name="cloud"></param>
        public void ShowCloud(Mat cloud)
        {
            if (cloud == null)
            {
                return;
            }
            //pcViewerControl.RenderWindow.GetRenderers().RemoveAllItems();
            renderer = pcViewerControl.RenderWindow.GetRenderers().GetFirstRenderer();

            // clear all objects
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                renderer.RemoveAllViewProps();
            }));

            // convert Mat to vtkPoints 
            vtkPoints points = new vtkPoints();
            vtkCellArray vtkCellArray = new vtkCellArray();
            // read point cloud data from Mat
            for (int i = 0; i < cloud.Rows; i++)
            {
                for (int j = 0; j < cloud.Cols; j++)
                {
                    Vec3f pixel = cloud.At<Vec3f>(i, j);
                    if (pixel.Item0 > 0 || pixel.Item1 > 0 || pixel.Item2 > 0)
                    {
                        points.InsertNextPoint(pixel.Item0, pixel.Item1, pixel.Item2);
                        vtkCellArray.InsertNextCell(1);
                        vtkCellArray.InsertCellPoint(i);
                    }
                }
            }

            vtkPolyData polyData = new vtkPolyData();
            polyData.SetPoints(points);
            polyData.SetVerts(vtkCellArray);

            vtkVertexGlyphFilter vertexFilter = vtkVertexGlyphFilter.New();
            vertexFilter.SetInputData(polyData);
            vertexFilter.Update();
            double[] minmax = polyData.GetBounds();
            vtkElevationFilter elevationFilter = vtkElevationFilter.New();
            elevationFilter.SetInputConnection(vertexFilter.GetOutputPort());
            elevationFilter.SetLowPoint(0, 0, minmax[4]);
            elevationFilter.SetHighPoint(0, 0, minmax[5]);

            // 使用vtkPolyDataMapper将vtkPolyData转成vtkActor
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            vtkAlgorithmOutput algoutput = elevationFilter.GetOutputPort(0);
            mapper.SetInputConnection(algoutput);

            // 使用vtkActor将vtkPolyDataMapper转成vtkActor
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            // 点云的点大小，设置为2
            actor.GetProperty().SetPointSize(2);

            renderer.AddActor(actor);

            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                pcViewerControl.RenderWindow.Render();
            }));

            //// 根据点云范围设置合适的相机位置
            //double[] bounds = polyData.GetBounds();
            //double[] center = new double[3];
            //center[0] = (bounds[0] + bounds[1]) / 2;
            //center[1] = (bounds[2] + bounds[3]) / 2;
            //center[2] = (bounds[4] + bounds[5]) / 2;
            //double radius = Math.Sqrt((bounds[1] - bounds[0]) * (bounds[1] - bounds[0]) +
            //    (bounds[3] - bounds[2]) * (bounds[3] - bounds[2]) +
            //    (bounds[5] - bounds[4]) * (bounds[5] - bounds[4])) / 2;
            //double distance = radius / Math.Sin(30 * Math.PI / 180);
            //vtkCamera camera = renderer.GetActiveCamera();
            //camera.SetFocalPoint(center[0], center[1], center[2]);
            //camera.SetPosition(center[0], center[1], center[2] - distance * 2);
            //camera.SetViewUp(0, -1, 0);
            //camera.Azimuth(0);
            //camera.Elevation(0);
            //camera.Zoom(1);

            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                pcViewerControl.RenderWindow.Render();
            }));
        }

        private void pcViewerControl_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Init3DViewer();
            });
        }
    }
}

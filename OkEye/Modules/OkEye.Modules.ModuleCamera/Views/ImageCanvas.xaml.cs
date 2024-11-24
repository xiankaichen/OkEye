﻿using System;
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
    /// 图像显示控件
    /// </summary>
    public partial class ImageCanvas : Canvas
    {
        #region Variables
        private readonly MatrixTransform _transform = new MatrixTransform();
        private Point _initialMousePosition;

        private bool _dragging;
        private UIElement _selectedElement;
        private Vector _draggingDelta;

        private Color _lineColor = Color.FromArgb(0xFF, 0x66, 0x66, 0x66);
        private Color _backgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);
        private List<Line> _gridLines = new List<Line>();


        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ImageCanvas()
        {
            InitializeComponent();

            MouseDown += ImageCanvas_MouseDown;
            MouseUp += ImageCanvas_MouseUp;
            MouseMove += ImageCanvas_MouseMove;
            MouseWheel += ImageCanvas_MouseWheel;

            BackgroundColor = _backgroundColor;

            //// draw lines
            //for (int x = -2000; x <= 2000; x += 100)
            //{
            //    Line verticalLine = new Line
            //    {
            //        Stroke = new SolidColorBrush(_lineColor),
            //        X1 = x,
            //        Y1 = -2000,
            //        X2 = x,
            //        Y2 = 2000
            //    };

            //    if ( x % 1000 == 0 )
            //    {
            //        verticalLine.StrokeThickness = 6;
            //    }
            //    else
            //    {
            //        verticalLine.StrokeThickness = 2;
            //    }

            //    Children.Add(verticalLine);
            //    _gridLines.Add(verticalLine);
            //}

            //for (int y = -2000; y <= 2000; y += 100)
            //{
            //    Line horizontalLine = new Line
            //    {
            //        Stroke = new SolidColorBrush(_lineColor),
            //        X1 = -2000,
            //        Y1 = y,
            //        X2 = 2000,
            //        Y2 = y
            //    };

            //    if (y % 1000 == 0)
            //    {
            //        horizontalLine.StrokeThickness = 6;
            //    }
            //    else
            //    {
            //        horizontalLine.StrokeThickness = 2;
            //    }

            //    Children.Add(horizontalLine);
            //    _gridLines.Add(horizontalLine);
            //}
        }

        public float Zoomfactor { get; set; } = 1.1f;

        public Color LineColor
        {
            get { return _lineColor; }

            set
            {
                _lineColor = value;

                foreach( Line line in _gridLines )
                {
                    line.Stroke = new SolidColorBrush(_lineColor);
                }
            }
        }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }

            set
            {
                _backgroundColor = value;
                Background = new SolidColorBrush(_backgroundColor);
            }
        }

        /// <summary>
        /// 设置网格可见性
        /// </summary>
        /// <param name="value"></param>
        public void SetGridVisibility(Visibility value)
        {
            foreach (Line line in _gridLines)
            {
                line.Visibility = value;
            }
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                _initialMousePosition = _transform.Inverse.Transform(e.GetPosition(this));
            }

            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.Children.Contains((UIElement)e.Source))
                {
                    _selectedElement = (UIElement)e.Source;
                    Point mousePosition = Mouse.GetPosition(this);
                    double x = Canvas.GetLeft(_selectedElement);
                    double y = Canvas.GetTop(_selectedElement);
                    Point elementPosition = new Point(x, y);
                    _draggingDelta = elementPosition - mousePosition;
                }
                _dragging = true;
            }
        }

        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _dragging = false;
            _selectedElement = null;
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Point mousePosition = _transform.Inverse.Transform(e.GetPosition(this));
                Vector delta = Point.Subtract(mousePosition, _initialMousePosition);
                var translate = new TranslateTransform(delta.X, delta.Y);
                _transform.Matrix = translate.Value * _transform.Matrix;

                foreach (UIElement child in this.Children)
                {
                    child.RenderTransform = _transform;
                }
            }

            if (_dragging && e.LeftButton == MouseButtonState.Pressed)
            {
                double x = Mouse.GetPosition(this).X;
                double y = Mouse.GetPosition(this).Y;

                if (_selectedElement != null)
                {
                    Canvas.SetLeft(_selectedElement, x + _draggingDelta.X);
                    Canvas.SetTop(_selectedElement,  y + _draggingDelta.Y);
                }
            }
        }

        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            float scaleFactor = Zoomfactor;
            if (e.Delta < 0)
            {
                scaleFactor = 1f / scaleFactor;
            }

            Point mousePostion = e.GetPosition(this);

            Matrix scaleMatrix = _transform.Matrix;
            scaleMatrix.ScaleAt(scaleFactor, scaleFactor, mousePostion.X, mousePostion.Y);
            _transform.Matrix = scaleMatrix;

            foreach (UIElement child in this.Children)
            {
                double x = Canvas.GetLeft(child);
                double y = Canvas.GetTop(child);

                double sx = x * scaleFactor;
                double sy = y * scaleFactor;

                Canvas.SetLeft(child, sx);
                Canvas.SetTop(child, sy);

                child.RenderTransform = _transform;
            }
        }
    }
}

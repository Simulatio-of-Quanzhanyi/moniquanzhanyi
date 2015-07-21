using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data;
using System.Data.OleDb;

namespace Wpf5320
{
    /// <summary>
    /// Window_collect1_PointSurvey1.xaml 的交互逻辑
    /// </summary>
    public partial class collect1_PointSurvey1 : Window
    {
        Point a;
        protected Thickness UCMargin;
        Point StationPoint = new Point(100.968, 100.324);
        Point CurrentPoint = new Point();
        PointData PD = new PointData();
        public collect1_PointSurvey1()
        {
            double Hhudu, Vhudu, Dis;
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            // LastPoint.PtName = "pt1";
            TbPname.Text = "pt1";
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LBVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LbHD.Content = (Dis * Math.Cos(Vhudu)).ToString("f03");
            LbVD.Content = (Dis * Math.Sin(Vhudu)).ToString("f03");
            LBSD.Content = Dis.ToString("f03");
            TBjinggao.Text = (1.75).ToString("f02");
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口
        }

        private void BtDistanceMeasuring_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            double denrtaX, denrtaY;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LBVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LbHD.Content = (Dis * Math.Cos(Vhudu)).ToString("f03");
            LbVD.Content = (Dis * Math.Sin(Vhudu)).ToString("f03");
            LBSD.Content = Dis.ToString("f03");
            TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
            denrtaX = (Dis * Math.Cos(Vhudu)) * Math.Cos(Hhudu);
            denrtaY = (Dis * Math.Cos(Vhudu)) * Math.Sin(Hhudu);
            CurrentPoint.X = StationPoint.X + denrtaX;
            CurrentPoint.Y = StationPoint.Y + denrtaY;

            PD.N = CurrentPoint.X.ToString("f3");
            PD.E = CurrentPoint.Y.ToString("f03");
            PD.Z = (10.87).ToString("f03");
            PD.HA = ToolCase.huduTojiaodu(Hhudu);
            PD.VA = ToolCase.huduTojiaodu(Vhudu);
            PD.HD = (Dis * Math.Cos(Vhudu)).ToString("f03");
            PD.VD = (Dis * Math.Sin(Vhudu)).ToString("f03");
            PD.SD = Dis.ToString("f03");

            Point_N.DataContext = PD;
            Point_E.DataContext = PD;
            Point_Z.DataContext = PD;
            Point_HA.DataContext = PD;
            Point_VA.DataContext = PD;
            Point_HD.DataContext = PD;
            Point_VD.DataContext = PD;
            Point_SD.DataContext = PD;
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                myMessageBox my = new myMessageBox();
                my.show("开机界面退出");
                //MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            //规划坐标宽153，长313，以测站为中心

            Line line1 = new Line();
            Line line2 = new Line();
            double draw_x, draw_y;
            draw_x = 150.0 / 200 * (CurrentPoint.X - StationPoint.X) + 150;
            draw_y = 75 - 75.0 / 200 * (CurrentPoint.Y - StationPoint.Y);
            line1.X1 = draw_x - 3;
            line1.Y1 = draw_y;
            line1.X2 = draw_x + 3;
            line1.Y2 = draw_y;
            line2.X1 = draw_x;
            line2.Y1 = draw_y - 3;
            line2.X2 = draw_x;
            line2.Y2 = draw_y + 3;
            line1.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            line2.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            CanvasDraw.Children.Add(line1);
            CanvasDraw.Children.Add(line2);
        }

        private void BtMeasuringSave_Click(object sender, RoutedEventArgs e)
        {
            BtDistanceMeasuring_Click(sender, e);
            BtSave_Click(sender, e);
        }

        private void BT_Fangda_Click(object sender, RoutedEventArgs e)
        {
            double dbl_ZoomX = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleX;
            double dbl_ZoomY = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleY;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleX = dbl_ZoomX * 1.2;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleY = dbl_ZoomY * 1.2;
        }

        private void BT_Shuoxiao_Click(object sender, RoutedEventArgs e)
        {
            double dbl_ZoomX = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleX;
            double dbl_ZoomY = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleY;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleX = dbl_ZoomX * 0.8;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleY = dbl_ZoomY * 0.8;
        }

        private void CanvasDraw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            myMessageBox my = new myMessageBox();
            my.show("ok");
       
            //MessageBox.Show("ok");
            this.MouseMove += new MouseEventHandler(CanvasDraw_MouseMove);
            a = e.GetPosition(this);
            if (a.X > 0 && a.Y > 0)
            {
                UCMargin = CanvasDraw.Margin;
            }
        }

        private void CanvasDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Released)
            {
                this.Cursor = Cursors.SizeAll;
                this.MouseLeftButtonUp += new MouseButtonEventHandler(CanvasDraw_MouseLeftButtonUp);
                Point PCurrent = e.GetPosition(this);

                double x = UCMargin.Left + PCurrent.X - a.X;
                double y = UCMargin.Top + PCurrent.Y - a.Y;
                CanvasDraw.Margin = new Thickness(x, y, 0, 0);
            }
            else
            {
                this.MouseMove -= new MouseEventHandler(CanvasDraw_MouseMove);
                this.Cursor = null;
            }
        }

        private void CanvasDraw_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Cursor = null;
            this.MouseMove -= new MouseEventHandler(CanvasDraw_MouseMove);
        }

        private void BTquanju_Click(object sender, RoutedEventArgs e)
        {
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleX=1.0;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.CanvasDraw)).RenderTransform)).Children[0])).ScaleY=1.0;
        }

        private void BT_Move_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }
    }
}

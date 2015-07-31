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
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace Wpf5320
{
    /// <summary>
    /// Window_collect1_PointSurvey1.xaml 的交互逻辑
    /// </summary>
    public partial class collect1_PointSurvey1 : Window
    {
        bool isMove = false;
        Point a;
        protected Thickness UCMargin;
        Point StationPoint = new Point(100.968, 100.324);
        Point CurrentPoint = new Point();
        int pointCount = 0;
        List<Line> CurrentLine1 = new List<Line>();
        List<Line> CurrentLine2 = new List<Line>();
        List<String> CurrentPoints = new List<String>();
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
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
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
                MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            //规划坐标宽153，长313，以测站为中心
            pointCount++;
            CurrentPoints.Add("pt" + pointCount);
            Line stationLine = new Line();
            Line stationLine1 = new Line();
            Line stationLine2 = new Line();
            Line line1 = new Line();
            Line line2 = new Line();
            double draw_x, draw_y, draw_stationX, draw_stationY;
            draw_x = 150.0 / 200 * (CurrentPoint.X - StationPoint.X) + 150;
            draw_y = 75 - 75.0 / 200 * (CurrentPoint.Y - StationPoint.Y);
            draw_stationX = 150.0 / 200 * StationPoint.X + 150;
            draw_stationY = 75 - 75.0 / 200 * StationPoint.Y;
            stationLine1.X1 = draw_stationX - 3;
            stationLine1.Y1 = draw_stationY;
            stationLine1.X2 = draw_stationX + 3;
            stationLine1.Y2 = draw_stationY;
            stationLine2.X1 = draw_stationX;
            stationLine2.Y1 = draw_stationY + 3;
            stationLine2.X2 = draw_stationX;
            stationLine2.Y2 = draw_stationY - 3;
            line1.X1 = draw_x - 3;
            line1.Y1 = draw_y;
            line1.X2 = draw_x + 3;
            line1.Y2 = draw_y;
            line2.X1 = draw_x;
            line2.Y1 = draw_y - 3;
            line2.X2 = draw_x;
            line2.Y2 = draw_y + 3;
            stationLine.X1 = draw_stationX;
            stationLine.Y1 = draw_stationY;
            stationLine.X2 = draw_x;
            stationLine.Y2 = draw_y;
            line1.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            line2.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            stationLine1.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            stationLine2.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            stationLine.Stroke = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            CurrentLine1.Add(line1);
            CurrentLine2.Add(line2);

            CanvasDraw.Children.Add(stationLine);     
            CanvasDraw.Children.Add(CurrentLine1[pointCount - 1]);
            CanvasDraw.Children.Add(CurrentLine2[pointCount - 1]);
            CanvasDraw.Children.Add(stationLine2);
            CanvasDraw.Children.Add(stationLine1);

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


        private void CanvasDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && isMove == true)
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
        private void CanvasDraw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.MouseMove += new MouseEventHandler(CanvasDraw_MouseMove);
            a = e.GetPosition(this);
            
            if (a.X > 0 && a.Y > 0)
            {
                UCMargin = CanvasDraw.Margin;
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
            CanvasDraw.Margin = new Thickness(0, 0, 0, 0);
        }

        private void BT_Move_Click(object sender, RoutedEventArgs e)
        {
            
           if(isMove == false)
           {
               isMove = true;
               BT_Move.Background = Brushes.LightBlue;
 
           }
           else
           {
               isMove = false;
               BT_Move.Background = BT_Fangda.Background;
           }
        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }

    }
}

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
using System.Windows.Shapes;

namespace Wpf5320
{
    /// <summary>
    /// collect2.xaml 的交互逻辑
    /// </summary>

    public partial class collect2 : Window
    {
        Point_ylj StationPoint = new Point_ylj(100.968, 100.324, 0);
        Point_ylj CurrentPoint = new Point_ylj();
        PointData PD = new PointData();
        public collect2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口
        }

        private void BtMeasuring_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            double denrtaX = 0, denrtaY = 0, denrtaZ = 0;

            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
            if (RBFront.IsChecked == true)
            {
                Dis = Dis + Convert.ToDouble(TBFB.Text);
            }
            else
            {
                Dis = Dis - Convert.ToDouble(TBFB.Text);
            }
            if (RBUper.IsChecked == true)
            {
                denrtaZ = -Convert.ToDouble(TBFB.Text);

            }
            else
            {
                denrtaZ = Convert.ToDouble(TBFB.Text);
            }



            if (RBLeft.IsChecked == true)
            {
                Hhudu = Hhudu - Convert.ToDouble(TBLR.Text) / Dis;
            }
            else if (RBRight.IsChecked == true)
            {
                Hhudu = Hhudu + Convert.ToDouble(TBLR.Text) / Dis;
            }
            denrtaX = (Dis * Math.Cos(Vhudu)) * Math.Cos(Hhudu);
            denrtaY = (Dis * Math.Cos(Vhudu)) * Math.Sin(Hhudu);
            denrtaZ = denrtaZ + Dis * Math.Tan(Vhudu);
            //坐标
            CurrentPoint.X = StationPoint.X + denrtaX;
            CurrentPoint.Y = StationPoint.Y + denrtaY;
            CurrentPoint.Z = StationPoint.Z + denrtaZ;

            //数据显示
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

        private void BtMeasuringSave_Click(object sender, RoutedEventArgs e)
        {
            DBClass DB = new DBClass();
            string SQL = null;
            BtMeasuring_Click(sender, e);//先测
            //规划坐标宽153，长313，以测站为中心
            // 画图
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
          //  CanvasDraw.Children.Add(line1);
          //  CanvasDraw.Children.Add(line2);
            //把点的坐标插入到数据库
            SQL = "INSERT INTO NEZCoord (PName,PCode,N,E,Z) values ('" + TbPname.Text + "','" + CBcode.SelectionBoxItem.ToString() + "','" + CurrentPoint.X.ToString("f03") + "','" + CurrentPoint.Y.ToString("f03") + "','" + CurrentPoint.Z.ToString("f03") + "')";
            //  MessageBox.Show(SQL);
            DB.DbOpen();
            DB.Manipulation_CMD(SQL);
            DB.DbClose();
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                myMessageBox my = new myMessageBox();
                my.show("主界面退出");
                //MessageBox.Show("主界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
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

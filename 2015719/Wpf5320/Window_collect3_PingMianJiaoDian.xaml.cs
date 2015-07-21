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
    /// collect3.xaml 的交互逻辑
    /// </summary>
    public partial class collect3 : Window
    {
        Point_ylj StationPoint = new Point_ylj(100.968, 100.324, 0);
        Point_ylj CurrentPoint = new Point_ylj();
        Point_ylj Point_A = new Point_ylj();
        Point_ylj Point_B = new Point_ylj();
        Point_ylj Point_C = new Point_ylj();
        PointData PD = new PointData();

        public collect3()
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

        private void BtMeasuring1_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            DBClass DB = new DBClass();
            //           string SQL = null;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            //坐标
            Point_A = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LbVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LbdcA.Content = "完成";
        }

        private void BtMeasuring2_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            DBClass DB = new DBClass();
            //           string SQL = null;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            //坐标
            Point_B = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LbVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LbdcB.Content = "完成";

        }

        private void BtMeasuring3_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            DBClass DB = new DBClass();
            // string SQL = null;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            //坐标
            Point_C = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LbVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LbdcC.Content = "完成";

        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            //计算平面方程
            /* 
               A(x - x1) + B(y - y1) + C(z - z1) = 0 (点法式)
               A = (y3 - y1)*(z3 - z1) - (z2 -z1)*(y3 - y1);
               B = (x3 - x1)*(z2 - z1) - (x2 - x1)*(z3 - z1);
               C = (x2 - x1)*(y3 - y1) - (x3 - x1)*(y2 - y1);
             直线方程：
             * m = Lx2 - Lx1;
             * n = Ly2 - Ly1;
             * p = Lz2 - Lz1;
             
             */
            double A, B, C, D;//平面方程参数
            double m, n, p;//直线方程参数
            double ZX_X, ZX_Y, ZX_Z;//重心坐标
            double Hhudu, Vhudu, Dis;
            //           double denrtaX = 0, denrtaY = 0, denrtaZ = 0;
            DBClass DB = new DBClass();
            string SQL = null;
            Point_ylj Point_P = new Point_ylj();
            Point_ylj Point_jiao = new Point_ylj();
            double t = 0;
            //平面方程
            A = (Point_C.Y - Point_A.Y) * (Point_C.Z - Point_A.Z) - (Point_B.Z - Point_A.Z) * (Point_C.Y - Point_A.Y);
            B = (Point_C.X - Point_A.X) * (Point_B.Z - Point_A.Z) - (Point_B.X - Point_A.X) * (Point_C.Z - Point_A.Z);
            C = (Point_B.X - Point_A.X) * (Point_C.Y - Point_A.Y) - (Point_C.X - Point_A.X) * (Point_B.Y - Point_A.Y);
            D = -A * Point_A.X - B * Point_A.Y - C * Point_A.Z;
            //三个点重心坐标
            ZX_X = Point_A.X + Point_B.X + Point_C.X;
            ZX_Y = Point_A.Y + Point_B.Y + Point_C.Y;
            ZX_Z = Point_A.Z + Point_B.Z + Point_C.Z;

            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            //坐标
            Point_P = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            //已知两点建直线方程
            m = Point_P.X - StationPoint.X;
            n = Point_P.Y - StationPoint.Y;
            p = Point_P.Z - StationPoint.Z;
            //直线与平面的焦点
            if (A * m + B * n + C * p == 0)  //判断直线是否与平面平行   
            {
                myMessageBox my = new myMessageBox();
                my.show("直线与平面平行，无法确定交点");
            
                //MessageBox.Show("直线与平面平行，无法确定交点");
            }
            else
            {
                t = -(StationPoint.X * A + StationPoint.Y * B + StationPoint.Z * C + D) / (A * m + B * n + C * p);
                Point_jiao.X = StationPoint.X + m * t;
                Point_jiao.Y = StationPoint.Y + n * t;
                Point_jiao.Z = StationPoint.Z + p * t;
            }
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LbVA.Content = ToolCase.huduTojiaodu(Vhudu);
            //显示坐标信息
            //数据显示
            PD.N = Point_jiao.X.ToString("f3");
            PD.E = Point_jiao.Y.ToString("f03");
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
            //画图
            int caseSwitch = -1;
            caseSwitch = CBProj.SelectedIndex;
            switch (caseSwitch)
            {
                case 1:
                    //NE投影Z=0
                    Draw_ylj(Point_jiao.X, Point_jiao.Y, ZX_X, ZX_Y);
                    break;
                case 2:
                    //NZ投影Y=0
                    Draw_ylj(Point_jiao.X, Point_jiao.Z, ZX_X, ZX_Z);
                    break;
                default:
                    //EZ投影X=0
                    Draw_ylj(Point_jiao.Y, Point_jiao.Z, ZX_Y, ZX_Z);
                    break;
            }
            //获取的点加入数据库
            SQL = "INSERT INTO NEZCoord (PName,PCode,N,E,Z) values ('" + TbPname.Text + "','" + CBcode.SelectionBoxItem.ToString() + "','" + Point_jiao.X.ToString("f03") + "','" + Point_jiao.Y.ToString("f03") + "','" + Point_jiao.Z.ToString("f03") + "')";
            //  MessageBox.Show(SQL);
            DB.DbOpen();
            DB.Manipulation_CMD(SQL);
            DB.DbClose();
            TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
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
        private void Draw_ylj(double X, double Y, double ZX_X, double ZX_Y)
        {
            Line line1 = new Line();
            Line line2 = new Line();
            double draw_x, draw_y;
            draw_x = 150.0 / 300 * (X - ZX_X) + 150;
            draw_y = 75 - 75.0 / 300 * (Y - ZX_X);
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

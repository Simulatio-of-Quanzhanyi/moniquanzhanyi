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
    /// collect4.xaml 的交互逻辑
    /// </summary>
    public partial class collect4 : Window
    {

        double Hhudu_A = 0;
        double Hhudu_B = 0;
        double Distance = 0;
        double Hhudu_YX = 0;
        double arfa;
        Point_ylj StationPoint = new Point_ylj(100.968, 100.324, 0);
        PointData PD = new PointData();

        public collect4()
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

        private void BtHA_A_Click(object sender, RoutedEventArgs e)
        {
            if (string.Equals(BtHA_A.Content, "测角"))
            {
                Hhudu_A = ToolCase.HARadom;
                LbHA_A.Content = ToolCase.huduTojiaodu(Hhudu_A);
                BtHA_A.Content = "确定";
            }
            else
            {
                BtHA_A.Content = "测角";
            }
        }



        private void BtHA_B_Click(object sender, RoutedEventArgs e)
        {

            if (string.Equals(BtHA_B.Content, "测角"))
            {
                Random Hrd = new Random();
                //A,B间为0-2°的随机数
                Hhudu_B = Hhudu_A + Hrd.NextDouble() * 2 / 360 * 2 * Math.PI;
                LbHA_B.Content = ToolCase.huduTojiaodu(Hhudu_B);
                BtHA_B.Content = "确定";
            }
            else
            {
                BtHA_B.Content = "测角";
            }
        }

        private void BtHA_Dis_Click(object sender, RoutedEventArgs e)
        {
            if (string.Equals(BtHA_Dis.Content, "测距"))
            {
                Distance = ToolCase.DistanceRadom;
                LBDis.Content = Distance.ToString("f03");
                BtHA_Dis.Content = "确定";
            }
            else
            {
                BtHA_Dis.Content = "测距";
            }



        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            string SQL = null;
            double Dis_YX = 0;
            double Vhudu = 0;//核实
            DBClass DB = new DBClass();
            arfa = (Hhudu_B - Hhudu_A) / 2;
            if (Distance > 0 && arfa > 0)
            {
                Point_ylj Point_Center = new Point_ylj();
                //圆心距离
                Dis_YX = Distance * (1 / (1 - Math.Tan(arfa)));
                //圆心方位角
                Hhudu_YX = Hhudu_A + arfa;

                //圆心坐标
                Point_Center = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis_YX, Hhudu_YX, 0);
                //画图
                Draw_ylj(Point_Center.X, Point_Center.Y, StationPoint.X, StationPoint.Y);
                //显示数据

                //数据显示
                PD.N = Point_Center.X.ToString("f3");
                PD.E = Point_Center.Y.ToString("f03");
                PD.Z = (10.87).ToString("f03");
                PD.HA = ToolCase.huduTojiaodu(Hhudu_YX);
                PD.VA = ToolCase.huduTojiaodu(Vhudu);
                PD.HD = (Dis_YX * Math.Cos(Vhudu)).ToString("f03");
                PD.VD = (Dis_YX * Math.Sin(Vhudu)).ToString("f03");
                PD.SD = Dis_YX.ToString("f03");

                Point_N.DataContext = PD;
                Point_E.DataContext = PD;
                Point_Z.DataContext = PD;
                Point_HA.DataContext = PD;
                Point_VA.DataContext = PD;
                Point_HD.DataContext = PD;
                Point_VD.DataContext = PD;
                Point_SD.DataContext = PD;
                //添加数据库
                SQL = "INSERT INTO NEZCoord (PName,PCode,N,E,Z) values ('" + TbPname.Text + "','" + CBcode.SelectionBoxItem.ToString() + "','" + Point_Center.X.ToString("f03") + "','" + Point_Center.Y.ToString("f03") + "','" + Point_Center.Z.ToString("f03") + "')";
                //  MessageBox.Show(SQL);
                DB.DbOpen();
                DB.Manipulation_CMD(SQL);
                DB.DbClose();
                TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
            }
            else
            {
                myMessageBox my = new myMessageBox();
                my.show("没有测角或者测距");
              
               // MessageBox.Show("没有测角或者测距");
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

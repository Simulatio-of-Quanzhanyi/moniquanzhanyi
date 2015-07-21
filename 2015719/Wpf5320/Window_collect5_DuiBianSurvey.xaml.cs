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
    /// collect5.xaml 的交互逻辑
    /// </summary>
    public partial class collect5 : Window
    {
        Point_ylj StationPoint = new Point_ylj();
        Point_ylj StartPoint = new Point_ylj(100, 100, 10);
        Point_ylj SeconPoint = new Point_ylj();
        Boolean IsLock =true;
        int SurveyNumber = 0;
        public collect5()
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

        private void BTSurvey_Click(object sender, RoutedEventArgs e)
        {

            double Hhudu = 0;
            double Distance = 0;
            double Vhudu = 0;
            double HD, SD, VD, FW;
            PointData PD = new PointData();


            if (SurveyNumber == 0)
            {
                Hhudu = ToolCase.HARadom;
                Vhudu = ToolCase.VARadom;
                Distance = ToolCase.DistanceRadom;
                //已知距离方位角反算测站坐标
                StartPoint.X = StationPoint.X - Distance * Math.Cos(Hhudu);
                StartPoint.Y = StationPoint.Y - Distance * Math.Cos(Hhudu);
                SurveyNumber = 1;
                //显示第一点数据信息
                SD = ToolCase.IIPointSD(StationPoint,StartPoint);
                HD = ToolCase.IIPointHD(StationPoint, StartPoint);
                VD = ToolCase.IIPointVD(StationPoint, StartPoint);
                FW = ToolCase.IIPointFW(StationPoint, StartPoint);
                LBFW.Content = ToolCase.huduTojiaodu(FW);
                LBXJ.Content = SD.ToString("f03");
                LbPJ.Content = HD.ToString("f03");
                LbGC.Content = VD.ToString("f03");

                //数据显示
                PD.N = StartPoint.X.ToString("f3");
                PD.E = StartPoint.Y.ToString("f03");
                PD.Z = (10.87).ToString("f03");
                PD.HA = ToolCase.huduTojiaodu(Hhudu);
                PD.VA = ToolCase.huduTojiaodu(Vhudu);
                PD.HD = (Distance * Math.Cos(Vhudu)).ToString("f03");
                PD.VD = (Distance * Math.Sin(Vhudu)).ToString("f03");
                PD.SD = Distance.ToString("f03");

                Point_N.DataContext = PD;
                Point_E.DataContext = PD;
                Point_Z.DataContext = PD;
                Point_HA.DataContext = PD;
                Point_VA.DataContext = PD;
                Point_HD.DataContext = PD;
                Point_VD.DataContext = PD;
                Point_SD.DataContext = PD;
            }
            else
            {
                Hhudu = ToolCase.HARadom;
                Vhudu = ToolCase.VARadom;
                Distance = ToolCase.DistanceRadom;
                SeconPoint = ToolCase.CalculationOfCoordinatePoints(StationPoint, Distance, Hhudu, Vhudu);
                SurveyNumber = SurveyNumber + 1;
                SD = ToolCase.IIPointSD(StartPoint, SeconPoint);
                HD = ToolCase.IIPointHD(StartPoint, SeconPoint);
                VD = ToolCase.IIPointVD(StartPoint, SeconPoint);
                FW = ToolCase.IIPointFW(StartPoint, SeconPoint);
                LBFW.Content = ToolCase.huduTojiaodu(FW);
                LBXJ.Content = SD.ToString("f03");
                LbPJ.Content = HD.ToString("f03");
                LbGC.Content = VD.ToString("f03");

                PD.N = SeconPoint.X.ToString("f3");
                PD.E = SeconPoint.Y.ToString("f03");
                PD.Z = (10.87).ToString("f03");
                PD.HA = ToolCase.huduTojiaodu(Hhudu);
                PD.VA = ToolCase.huduTojiaodu(Vhudu);
                PD.HD = (Distance * Math.Cos(Vhudu)).ToString("f03");
                PD.VD = (Distance * Math.Sin(Vhudu)).ToString("f03");
                PD.SD = Distance.ToString("f03");

                Point_N.DataContext = PD;
                Point_E.DataContext = PD;
                Point_Z.DataContext = PD;
                Point_HA.DataContext = PD;
                Point_VA.DataContext = PD;
                Point_HD.DataContext = PD;
                Point_VD.DataContext = PD;
                Point_SD.DataContext = PD;
                if (IsLock == false)
                {
                    StartPoint.X = SeconPoint.X;
                    StartPoint.Y = SeconPoint.Y;
                    StartPoint.Z = SeconPoint.Z;
                }
            }
        }

        private void BtLock_Click(object sender, RoutedEventArgs e)
        {
            if (IsLock == false)
            {
                IsLock = true;
                BtLock.Content = "锁定";
                //   BtLock.Background = Color.FromRgb(255, 0, 0);
            }
            else
            {
                IsLock = false;
                BtLock.Content = "未锁定";
                // BtLock.Background = Color.FromRgb(155, 155, 155);
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DBClass DB = new DBClass();
            string SQL = null;
            string TbPname = "DB";
            string CBcode = null;

            //保存当前点的测量坐标
            //画图
            Draw_ylj(SeconPoint.X, SeconPoint.Y, StationPoint.X, StationPoint.Y);
            //添加数据库

            SQL = "INSERT INTO NEZCoord (PName,PCode,N,E,Z) values ('" + TbPname + "','" + CBcode + "','" + SeconPoint.X.ToString("f03") + "','" + SeconPoint.Y.ToString("f03") + "','" + SeconPoint.Z.ToString("f03") + "')";

            //  MessageBox.Show(SQL);
            DB.DbOpen();
            DB.Manipulation_CMD(SQL);
            DB.DbClose();
            //TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
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

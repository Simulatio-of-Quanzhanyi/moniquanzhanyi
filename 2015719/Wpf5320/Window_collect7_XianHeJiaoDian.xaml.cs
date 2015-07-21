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
    /// Window_collect7_XianHeYanChangDian.xaml 的交互逻辑
    /// </summary>
    public partial class collect7 : Window
    {
        Point_ylj StationPoint = new Point_ylj(100.968, 100.324, 0);
        Point_ylj FirstP = new Point_ylj();
        Point_ylj SeconP = new Point_ylj();
        Point_ylj EX_Point = new Point_ylj();
        PointData PD = new PointData();
        public collect7()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void BTSur1_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            FirstP = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LBVA.Content = ToolCase.huduTojiaodu(Vhudu);
            LBP1Dis.Content = Dis.ToString("f03");

        }

        private void BTView1_Click(object sender, RoutedEventArgs e)
        {
            myMessageBox my = new myMessageBox();
            my.show(FirstP.X.ToString("f03") + ";" + FirstP.Y.ToString("f03") + ";" + FirstP.Z.ToString("f03"));
            //MessageBox.Show(FirstP.X.ToString("f03") + ";" + FirstP.Y.ToString("f03") + ";" + FirstP.Z.ToString("f03"));
        }

        private void BTSur2_Click_1(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis;
            Hhudu = ToolCase.HARadom;
            Vhudu = ToolCase.VARadom;
            Dis = ToolCase.DistanceRadom;
            SeconP = ToolCase.CalculationOfCoordinatePoints(StationPoint, Dis, Hhudu, Vhudu);
            LBP2Dis.Content = Dis.ToString("f03");
            LBHA.Content = ToolCase.huduTojiaodu(Hhudu);
            LBVA.Content = ToolCase.huduTojiaodu(Vhudu);
        }

        private void BTView2_Click(object sender, RoutedEventArgs e)
        {
            myMessageBox my = new myMessageBox();
            my.show(SeconP.X.ToString("f03") + ";" + SeconP.Y.ToString("f03") + ";" + SeconP.Z.ToString("f03"));
          // MessageBox.Show(SeconP.X.ToString("f03") + ";" + SeconP.Y.ToString("f03") + ";" + SeconP.Z.ToString("f03"));
        }

        private void BTSur3_Click(object sender, RoutedEventArgs e)
        {

            double S;
            double k, b;
            double x1, y1, x2, y2;
            double x, y;
            double a1, b1, c1;
            double HA, VA;
            double VD, HD, SD;
            Random RD = new Random();
            S = RD.NextDouble() * Math.PI;
            TBEXDis.Text = ToolCase.huduTojiaodu(S);

            x1 = FirstP.X;
            y1 = FirstP.Y;
            x2 = SeconP.X;
            y2 = SeconP.Y;
            k = (y2 - y1) / (x2 - x1);
            b = y1 - x1 * (y2 - y1) / (x2 - x1);
            a1 = 1 + k * k;
            b1 = 2 * k * (b - y2) - 2 * x2;
            c1 = x2 * x2 + (b - y2) * (b - y2) - S * S;
            x = (b1 - Math.Sqrt(b1 * b1 - 4 * a1 * c1)) / (-2 * a1);
            y = k * x + b;
            EX_Point.X = x;
            EX_Point.Y = y;
            EX_Point.Z = 0;

            HA = ToolCase.IIPointFW(EX_Point, StationPoint);
            VA = Math.Atan(EX_Point.Y / StationPoint.Y);
            HD = ToolCase.IIPointHD(EX_Point, StationPoint);
            VD = ToolCase.IIPointVD(EX_Point, StationPoint);
            SD = ToolCase.IIPointSD(EX_Point, StationPoint);

            //数据显示
            PD.N = EX_Point.X.ToString("f3");
            PD.E = EX_Point.Y.ToString("f03");
            PD.Z = (10.87).ToString("f03");
            PD.HA = ToolCase.huduTojiaodu(HA);
            PD.VA = ToolCase.huduTojiaodu(VA);
            PD.HD = HD.ToString("f03");
            PD.VD = VD.ToString("f03");
            PD.SD = SD.ToString("f03");

            Point_N.DataContext = PD;
            Point_E.DataContext = PD;
            Point_Z.DataContext = PD;
            Point_HA.DataContext = PD;
            Point_VA.DataContext = PD;
            Point_HD.DataContext = PD;
            Point_VD.DataContext = PD;
            Point_SD.DataContext = PD;

        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            string SQL = null;
            DBClass DB = new DBClass();
            Draw_ylj(EX_Point.X, EX_Point.Y, StationPoint.X, StationPoint.Y);
            //添加数据库

            SQL = "INSERT INTO NEZCoord (PName,PCode,N,E,Z) values ('" + TbPname.Text + "','" + CBcode.SelectionBoxItem.ToString() + "','" + EX_Point.X.ToString("f03") + "','" + EX_Point.Y.ToString("f03") + "','" + EX_Point.Z.ToString("f03") + "')";
            //  MessageBox.Show(SQL);
            DB.DbOpen();
            DB.Manipulation_CMD(SQL);
            DB.DbClose();
            TbPname.Text = ToolCase.PointNumberAdd1(TbPname.Text);
            myMessageBox my = new myMessageBox();
            my.show("存储一个点，并画图");
            //MessageBox.Show("存储一个点，并画图");
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口
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

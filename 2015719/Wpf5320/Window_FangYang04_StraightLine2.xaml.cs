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

using System.Data.OleDb;
namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang04_StraightLine2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang04_StraightLine2 : Window
    {
        private jiaodu j1 = new jiaodu();
        Point StationPoint = new Point(100.968, 100.324);
        Point CurrentPoint = new Point();
        public Window_FangYang04_StraightLine2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang window_FangYang = new Window_FangYang();
            window_FangYang.Show();
            this.Close();//关闭当前窗口
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1 window_FangYang04_StraightLine1 = new Window_FangYang04_StraightLine1();
            window_FangYang04_StraightLine1.Show();
            this.Close();//关闭当前窗口
        }

        private void Measure_Click(object sender, RoutedEventArgs e)
        {
            double Hhudu, Vhudu, Dis, Dis1, Dis2, Dis3, Dis4;
            Hhudu = ToolCase.HA;
            Vhudu = ToolCase.VA;
            Dis = ToolCase.Distance;
            Dis1 = ToolCase.Distance1;
            Dis2 = ToolCase.Distance2;
            Dis3 = ToolCase.Distance3;
            Dis4 = ToolCase.Distance4;
            TurnRight1.Content = ToolCase.huduTojiaodu(Hhudu);
            //HA.Text = ToolCase.huduTojiaodu(Vhudu);
            Movefar1.Content = Dis.ToString("f03");
            GoLeft1.Content = Dis1.ToString("f03");
            TianFang1.Content = Dis2.ToString("f03");
            // HD.Text = Dis3.ToString("f03");
            // Z.Text = Dis4.ToString("f03");

            HA11.Content = ToolCase.huduTojiaodu(Hhudu);
            VA11.Content = ToolCase.huduTojiaodu(Vhudu);
            HD11.Content = Dis1.ToString("f03");
            VD11.Content = Dis2.ToString("f03");
            SD11.Content = Dis.ToString("f03");
            N11.Content = (24279847.0 - Dis3).ToString("f03");
            E11.Content = (31848.621 - Dis4).ToString("f03");
            Z11.Content = (378.251 - Dis1).ToString("f03");

            //Window_FangYang04_StraightLine2 StraightLine2 = new Window_FangYang04_StraightLine2();
            //StraightLine2.Show();
            //StraightLine2.TabControl1.SelectedIndex = 1;
            //this.Close();//关闭当前窗口
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select(镜高,右转,移远,向左,填方,HA,HD,Z) from FangYang_StraightLine where FY_StraightLine_ID = 2";
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            sql = "Update  FangYang_StraightLine Set 镜高='" + JingGao1.Text.Trim() + "',右转='" + TurnRight1.Content + "',移远='" + Movefar1.Content + "',向左='" + GoLeft1.Content + "',填方='" + TianFang1.Content + "',HA='" + HA1.Text.Trim() + "',HD='" + HD1.Text.Trim() + "',Z = '" + Z1.Text.Trim() + "'   where FY_StraightLine_ID = 2";

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("成功!");
            conn.Close();

            double Hhudu, Vhudu, Dis;
            double denrtaX, denrtaY;
            Hhudu = ToolCase.HA;
            Vhudu = ToolCase.VA;
            Dis = ToolCase.Distance;
            denrtaX = (Dis * Math.Cos(Vhudu)) * Math.Cos(Hhudu);
            denrtaY = (Dis * Math.Cos(Vhudu)) * Math.Sin(Hhudu);
            CurrentPoint.X = StationPoint.X + denrtaX;
            CurrentPoint.Y = StationPoint.Y + denrtaY;

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

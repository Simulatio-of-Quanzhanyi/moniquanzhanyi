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
using System.Data;
namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang02_jiaodujuli.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang02_jiaodujuli : Window
    {
        private jiaodu j1 = new jiaodu();
        Point StationPoint = new Point(100.968, 100.324);
        Point CurrentPoint = new Point();
        public Window_FangYang02_jiaodujuli()
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
            Right.Content = ToolCase.huduTojiaodu(Hhudu);
            //HA.Text = ToolCase.huduTojiaodu(Vhudu);
            MoveClose.Content = Dis.ToString("f03");
            TurnLeft.Content = Dis1.ToString("f03");
            WaFang.Content = Dis2.ToString("f03");
           // HD.Text = Dis3.ToString("f03");
           // Z.Text = Dis4.ToString("f03");

            HA1.Content = ToolCase.huduTojiaodu(Hhudu);
            VA1.Content = ToolCase.huduTojiaodu(Vhudu);
            HD1.Content = Dis1.ToString("f03");
            VD1.Content = Dis2.ToString("f03");
            SD1.Content = Dis.ToString("f03");
            N1.Content = (24279847.0 - Dis3).ToString("f03");
            E1.Content = (31848.621 - Dis4).ToString("f03");
            Z1.Content = (378.251 - Dis1).ToString("f03");
           // Window_FangYang02_jiaodujuli window_FangYang02 = new Window_FangYang02_jiaodujuli();
           // window_FangYang02.Show();
            //window_FangYang02.TabControl1.SelectedIndex = 1;
            //this.Close();//关闭当前窗口
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            string sql = "select * from FangYang_AngleDistance";
            cmd1.CommandText = sql;
            sql = "insert into FangYang_AngleDistance (镜高,HA,HD,Z) values ('" + JG.Text.Trim() + "','" + HA.Text.Trim() + "','" + HD.Text.Trim() + "','" + Z.Text.Trim() + "')";
            //MessageBox.Show(sql);
            cmd1.CommandText = sql;
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("存储成功！");


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

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
    /// Window_jianzhan4.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan4 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        
        public Window_jianzhan4()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            OleDbDataReader dr;
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            string sql = "select * from rearview_checking";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s;
                double t,k;
                station_point.Content = dr.GetString(1).ToString();
                rearview_point.Content = dr.GetString(2).ToString();
                BS.Content = dr.GetString(3).ToString();
                s = BS.Content.ToString();
                t = Convert.ToDouble(s);
                Random ran = new Random();
                k = ran.Next(0, 200)*0.0001;
                t = k + t;
                HA.Content = t.ToString();
                dHA.Content = k.ToString();
            }
            conn.Close();                    
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void resetting_Click(object sender, RoutedEventArgs e)
        {
            HA.Content = BS.Content;
            dHA.Content = "0.0000";
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
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

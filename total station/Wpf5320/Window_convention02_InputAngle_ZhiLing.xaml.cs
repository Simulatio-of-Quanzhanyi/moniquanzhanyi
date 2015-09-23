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
    /// Window_convention02_InputAngle_ZhiLing.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention02_InputAngle_ZhiLing : Window
    {
        private jiaodu j1 = new jiaodu();
        public Window_convention02_InputAngle_ZhiLing()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnStr);

            conn.Open();
            string sql = "select CAM_V from Convention_AngleMeasure where CAM_ID=1";
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            sql = "update Convention_AngleMeasure set CAM_HL= '0°0′0″' where CAM_ID=1 ";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            myMessageBox my = new myMessageBox();
            my.show("置零成功！");
            //MessageBox.Show("置零成功！");
            conn.Close();
           // Lab_HL.Content = "0";

            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select CAM_V ,CAM_HL from Convention_AngleMeasure where CAM_ID=1";
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                j1.v1 = reader["CAM_V"].ToString().Trim();
                j1.v2 = reader["CAM_HL"].ToString().Trim();
            }

            //Lab_V.DataContext = j1;
            //Lab_HL.DataContext = j1;
            reader.Close();
            conn.Close();

            Window_convention01 window_convention = new Window_convention01();
            window_convention.Show();
            this.Close();//关闭当前窗口
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            this.Close();//关闭当前窗口
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {

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

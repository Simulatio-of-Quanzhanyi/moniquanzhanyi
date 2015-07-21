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

using System.Data;
using System.Data.OleDb;

namespace Wpf5320
{
    /// <summary>
    /// Window_convention02_InputAngle_Keep.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention02_InputAngle_Keep : Window
    {
        private jiaodu j1 = new jiaodu();
        public Window_convention02_InputAngle_Keep()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

            
            // 读取数据库的HL在lable控件显示 
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select CAM_HL from Convention_AngleMeasure where CAM_ID=1";
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                j1.v1 = reader["CAM_HL"].ToString().Trim();
                
            }

            Keep_HL.DataContext = j1;
           
            reader.Close();
            conn.Close();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            myMessageBox my = new myMessageBox();
            my.show("HL保持");
            //MessageBox.Show("HL保持");
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            this.Close();//关闭当前窗口
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key window_Shortcut_key = new Window_Shortcut_key();
            window_Shortcut_key.Show();
            this.Close();//关闭当前窗口
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

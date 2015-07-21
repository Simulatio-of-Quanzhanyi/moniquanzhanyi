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
    /// Window_convention03jlfangyang.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention03jlfangyang : Window
    {
        public Window_convention03jlfangyang()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            //window_convention01.tabControl1.SelectedTab = window_convention01.TabItem_Distance;
            window_convention01.tabControl1.SelectedIndex = 1;
            this.Close();//关闭当前窗口

        }
        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            CDM_SD.IsEnabled = true;
            CDM_HD.IsEnabled = true;
            CDM_VD.IsEnabled = true ;
            

            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            if (CDM_SD.Text.Trim() != "" && CDM_HD.Text.Trim() != "" && CDM_VD.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select * from Convention_DistanceMeasure whereCDM_SD='" + CDM_SD.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                sql = "insert into Convention_DistanceMeasure (CDM_SD,CDM_HD,CDM_VD) values ('"
                    + CDM_SD.Text.Trim() + "','" + CDM_HD.Text.Trim() + "','" + CDM_VD.Text.Trim() + "')";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                myMessageBox my = new myMessageBox();
                my.show("放样值加成功！");

                conn.Close();
            }
            else
            {
                myMessageBox my = new myMessageBox();
                my.show("输入距离放样值均不能为空！");
               // MessageBox.Show("输入距离放样值均不能为空！", "提示");
            }
        }

        private void RadioButton_HD_Click(object sender, RoutedEventArgs e)
        {
            // CDM_HD.Background = Black;   
            CDM_HD.IsEnabled = true ;
            CDM_VD.IsEnabled = false ;
            CDM_SD.IsEnabled = false ;
        }

        private void RadioButton_VD_Click(object sender, RoutedEventArgs e)
        {
            CDM_HD.IsEnabled = false ;
            CDM_VD.IsEnabled = true ;
            CDM_SD.IsEnabled = false;
        }

        private void RadioButton_SD_Click(object sender, RoutedEventArgs e)
        {
            CDM_HD.IsEnabled = false;
            CDM_VD.IsEnabled = false ;
            CDM_SD.IsEnabled = true;
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {

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

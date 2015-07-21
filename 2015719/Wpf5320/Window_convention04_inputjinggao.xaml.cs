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
    /// Window_convention04jinggao.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention04jinggao : Window
    {
        public Window_convention04jinggao()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 2;
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            if (CCM_棱镜高.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select  CCM_棱镜高 from Convention_CoordinatesMeasure where CCM_棱镜高='" + CCM_棱镜高.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                sql = "update  Convention_CoordinatesMeasure set CCM_棱镜高 = ('" + CCM_棱镜高.Text.Trim() + "') where CCM_ID=1";
              
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                myMessageBox my = new myMessageBox();
                my.show("棱镜高添加成功！"); //MessageBox.Show("棱镜高添加成功！");
                conn.Close();
            }
            else
            {
                myMessageBox my = new myMessageBox();
                my.show("输入棱镜高不能为空！");// MessageBox.Show("输入棱镜高不能为空！", "提示");
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

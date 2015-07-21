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
    /// Window_Project18.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project18 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_Project18()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            //添加数据库
            //读数据
            OleDbDataReader reader;
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            string sql = "SELECT ItemName,ItemDate FROM ItemInfor";
            conn.Open();// 打开数据连接
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();//获得数据集

            ListViewItemInfor.ItemsSource = reader;
            conn.Close();

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window_Project17 window_Start1 = new Window_Project17();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Project17 window_Start1 = new Window_Project17();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void DaoRu_Click(object sender, RoutedEventArgs e)
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

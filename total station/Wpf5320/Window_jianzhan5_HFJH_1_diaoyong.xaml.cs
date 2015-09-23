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
    /// Window_jianzhan5_HFJH_1_diaoyong.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan5_HFJH_1_diaoyong : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_jianzhan5_HFJH_1_diaoyong()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            //打开数据库
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //读取数据库
            string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp.Fill(ds);//将数据源加载到dataset中
            LV.ItemsSource = ds.DefaultView;
            conn.Close();
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("主界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan5_1 win = new Window_jianzhan5_1();
            win.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Buildstation");
                int c = LV.SelectedIndex;
                string s = ds.Tables["Buildstation"].Rows[c]["测站"].ToString().Trim();
                DBClass.Manipulation("Delete from HFJH_2");
                DBClass.Manipulation("Insert into HFJH_2 (站名,编码,N,E,Z) select 测站,编码,N,E,Z from Buildstation where 测站='" + s + "'");
                ESC_Click(sender, e);
            }
            else
            {
                MessageBox.Show("请选择数据！", "提示");
            }
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            LV.SelectedIndex = 0;
            LV.ScrollIntoView(LV.SelectedItem);
        }

        private void last_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Buildstation");
            int c = ds.Tables["Buildstation"].Rows.Count;
            LV.SelectedIndex = c - 1;
            LV.ScrollIntoView(LV.SelectedItem);
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

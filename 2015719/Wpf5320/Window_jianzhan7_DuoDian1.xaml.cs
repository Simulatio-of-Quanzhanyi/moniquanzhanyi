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
    /// Window_jianzhan7_1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan7_1 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        Window_jianzhan7_2 win = new Window_jianzhan7_2();
        public Window_jianzhan7_1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //读取数据库
            string sql = "select 测站,N,E,Z,水平角,垂直角,斜距 from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp.Fill(ds);//将数据源加载到dataset中
            LV.ItemsSource = ds.DefaultView;
            conn.Close();
            win.fangwei.Content = ToolCase.huduTojiaodu(ToolCase.HA);
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7 window_jianzhan7 = new Window_jianzhan7();
            window_jianzhan7.Show();
            this.Close();//关闭当前窗口
        }

        private void CeLiang_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian1_celiang window_jianzhan7_2 = new Window_jianzhan7_DuoDian1_celiang();
            window_jianzhan7_2.Show();
            this.Close();//关闭当前窗口
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select 测站,N,E,Z from Buildstation";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Buildstation");
                int c = LV.SelectedIndex;
                string s = ds.Tables["Buildstation"].Rows[c]["测站"].ToString().Trim();
                DBClass.Manipulation("Delete from Buildstation where 测站='" + s + "'");
                Window_jianzhan7_1 window_jianzhan7_1 = new Window_jianzhan7_1();//刷新界面
                window_jianzhan7_1.Show();
                this.Close();//关闭当前窗口
            }
            else
            {
                MessageBox.Show("请选择数据！", "提示");
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Buildstation");
            int c = ds.Tables["Buildstation"].Rows.Count;           
            if (c==1)
            {               
                win.standard_deviation.Content = "0.0000";
            }  
            else
            {
                Random ran = new Random();
                float a = Convert.ToSingle(ran.NextDouble());
                float b = 1 + a;                
                win.standard_deviation.Content = b.ToString();               
            }
            win.Show();
            this.Close();
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

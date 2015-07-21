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
    /// Window_Data2_CoordinateData.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Data2_CoordinateData : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_Data2_CoordinateData()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            //打开数据库
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //读取数据库
            string sql = "select ID,D_NAME,D_TYPE,D_CODE,N,E,Z from Original_data";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp.Fill(ds);//将数据源加载到dataset中
            LV.ItemsSource = ds.DefaultView;

            conn.Close();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Data window_Start1 = new Window_Data();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void BianJi_Click(object sender, RoutedEventArgs e)
        {
            Window_Data2_CoordinateData_1bianji window_Start1 = new Window_Data2_CoordinateData_1bianji();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Data2_CoordinateData_1new window_Start1 = new Window_Data2_CoordinateData_1new();
            window_Start1.Show();
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

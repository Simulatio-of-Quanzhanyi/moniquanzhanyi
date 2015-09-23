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
    /// Window_calculate04_MianJiJiSuan_addPoint.xaml 的交互逻辑
    /// </summary>
    public partial class Window_calculate04_MianJiJiSuan_addPoint : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_calculate04_MianJiJiSuan_addPoint()
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

            Window_calculate04 MianJiJiSuan = new Window_calculate04();
            MianJiJiSuan.Show();
            this.Close();//关闭当前窗口
        }


        private void first_Click(object sender, RoutedEventArgs e)
        {
            LV.SelectedIndex = 0;
           // LV.Items.MoveCurrentToFirst();
          
            LV.ScrollIntoView(LV.SelectedItem);
            //MessageBox.Show(LV.View.GetType().ToString());
        }

        private void last_click(object sender, RoutedEventArgs e)
        {

            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select ID,D_NAME,D_TYPE,N,E,Z from Original_data";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Original_data");
            int c = ds.Tables["Original_data"].Rows.Count;
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

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select ID,D_NAME,D_TYPE,N,E,Z from Original_data";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Original_data");  
                int c = LV.SelectedIndex;
                int id = (int) ds.Tables["Original_data"].Rows[c]["ID"];


                //读取数据库
                sql = "select ID,D_NAME,D_TYPE,N,E,Z from Original_data where ID = " + id;
                OleDbDataAdapter adp_new = new OleDbDataAdapter(sql, conn);
                DataTable ds_new = new DataTable();
                adp_new.Fill(ds_new);//将数据源加载到dataset中

                Window_calculate04 MianJiJiSuan = new Window_calculate04();

                MianJiJiSuan.LV.ItemsSource = ds_new.DefaultView;
                conn.Close();

                MianJiJiSuan.Show();
                this.Close();//关闭当前窗口
            }
            else
            {
                MessageBox.Show("请选择数据！", "提示");
            }
        }





    }
}

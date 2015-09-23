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
            string sql = "select ID,D_NAME,D_TYPE,N,E,Z from Original_data";
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

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = LV.SelectedItem as DataRowView;
            if (data != null && data is DataRowView)
            {
                Window_Data2_CoordinateData_Edit data_Bianji = new Window_Data2_CoordinateData_Edit();
                data_Bianji.tbItemName.Text = data.Row["D_NAME"].ToString();
                data_Bianji.ID = data.Row["ID"].ToString();
                data_Bianji.tbItemN.Text = data.Row["N"].ToString();
                data_Bianji.tbItemE.Text = data.Row["E"].ToString();
                data_Bianji.tbItemZ.Text = data.Row["Z"].ToString();
                data_Bianji.Show();
                this.Close();//关闭当前窗口
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Window_Data2_CoordinateData_1new window_Start1 = new Window_Data2_CoordinateData_1new();
            window_Start1.Show();
            this.Close();//关闭当前窗口
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

        private void del_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = LV.SelectedItem as DataRowView;
            if (data != null && data is DataRowView)
            {
                string id = data.Row["ID"].ToString();
                data.Delete();
                //要删除的项目在ItemInfor中删除
                string sql = "delete * from Original_data where ID=" + id;
                DBClass.Manipulation_CMD(sql);
            }
            else
            {
                MessageBox.Show("没有选择点");
            }
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

        private void first_Click(object sender, RoutedEventArgs e)
        {
            LV.SelectedIndex = 0;
            // LV.Items.MoveCurrentToFirst();

            LV.ScrollIntoView(LV.SelectedItem);
            //MessageBox.Show(LV.View.GetType().ToString());
        }


    }
}

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
    /// Window_Project12.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project12 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_Project12()
        {

            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            DBClass DB = new DBClass();
            DB.DbOpen();
            string sql = "select ItemName,ItemDate from ItemInfor";
            DataSet ds=DB.ConditionQuery(sql);
            ListView1.ItemsSource = ds.Tables[0].DefaultView;
            DB.DbClose();
          /*  string itemName, itemdate;
            var sb = new StringBuilder();
            int temp;
            systime.Content = DateTime.Now.ToShortTimeString();
            //读取数据库
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select ItemName,ItemDate from ItemInfor";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            itemlist.Items.MoveCurrentToFirst();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                itemName = ds.Tables[0].Rows[i]["ItemName"].ToString();
                temp = itemName.Length;
                if (itemName.Length > 15)
                {
                    itemName.Substring(0, 15);
                }
                else
                {
                    //添加指定空格
                    sb.Append(itemName);
                    sb.Append(' ', 2 * (15 - itemName.Length));
                    itemName = sb.ToString();
                    //itemdate = ds.Tables[0].Rows[i]["ItemDate"].ToString();
                    itemdate = ds.Tables[0].Rows[i]["ItemDate"].ToString();
                    //itemdate = itemdqate.Substring(0, itemdate.Length - 7);
                    itemlist.Items.Add(itemName + itemdate);
                    sb.Clear();
                }

            }
            conn.Close();*/


        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Project window_Start1 = new Window_Project();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
   
            DataRowView dav = (DataRowView)ListView1.SelectedItem;
            GlobalVariables.OpenItem = dav["ItemName"].ToString();
            BT_default.Content = GlobalVariables.OpenItem;
            Window_Project window_Start1 = new Window_Project();
            window_Start1.Show();
            this.Close();//关闭当前窗口
           // MessageBox.Show(dav["ItemName"].ToString());

            //存储当前项目ID号
          /*  OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select ItemID,ItemName from ItemInfor where ItemName='" + itemlist.SelectedItem.ToString().Substring(0, 15).Trim() + "'";
            MessageBox.Show(sql);
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            MessageBox.Show(ds.Tables[0].Rows[0]["ItemID"].ToString().Trim());
            Window_Project11.CurrentItemID = int.Parse(ds.Tables[0].Rows[0]["ItemID"].ToString().Trim());*/
        }






        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dav = (DataRowView)ListView1.SelectedItem;
            GlobalVariables.OpenItem = dav["ItemName"].ToString();
            BT_default.Content = GlobalVariables.OpenItem;
            //MessageBox.Show(dav["ItemName"].ToString());
        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }

    }
}

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
    /// Window_Project13.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project13 : Window
    {
  //      private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_Project13()
        {

            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            DBClass DB = new DBClass();
            DB.DbOpen();
            string sql = "select ItemName,ItemDate from ItemInfor";
            DataSet ds = DB.ConditionQuery(sql);
            ListView1.ItemsSource = ds.Tables[0].DefaultView;
            DB.DbClose();

  /*          // 读取数据库在listbox控件显示
   *             string itemName, itemdate;
            int temp;
            var sb = new StringBuilder();
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select ItemName,ItemDate from ItemInfor";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
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
                    //                   itemdate = itemdate.Substring(0, itemdate.Length - 7);

                    ItemList.Items.Add(itemName + itemdate);
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
        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedIndex > -1)
            {
                DBClass db = new DBClass();
                DataRowView dav = (DataRowView)ListView1.SelectedItem;
                dav.Delete();
                BT_beixuanzhong.Content = "default";
                //要删除的项目添加到删除项目数据库
                db.DbOpen();
                String ItemName = dav["ItemName"].ToString();
                string sql = "insert into DeleteItem(ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount) select ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount from ItemInfor where ItemName='" + ItemName + "'";
                db.Manipulation_CMD(sql);
                //要删除的项目在ItemInfor中删除
                sql = "delete * from ItemInfor where ItemName='" + ItemName + "'";
                db.Manipulation_CMD(sql);
                db.DbClose();
            }
            else
            {
                MessageBox.Show("没有选择删除项目");
            }


            /*    string ItemName = ItemList.SelectedItem.ToString().Substring(0, 15).Trim();
            string sql = "select * from ItemInfor where ItemName='" + ItemName + "'";
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("删除失败，请选择删除项目！", "提示");
                conn.Close();
            }
            else
            {
                sql = "insert into DeleteItem(项目名称,项目作者,项目解释,修改时间) select ItemName,ItemAuthor,ItemAnnotation,ItemDate from ItemInfor where ItemName='" + ItemName + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = "delete * from ItemInfor where ItemName='" + ItemName + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //            MessageBox.Show("删除成功！", "提示");
                //   conn.Close();
            }
            string itemName, itemdate;
            int temp;
            var sb = new StringBuilder();
            sql = "select ItemName,ItemDate from ItemInfor";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ItemList.Items.Clear();
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
                    // itemdate = itemdate.Substring(0, itemdate.Length - 7);

                    ItemList.Items.Add(itemName + itemdate);
                    sb.Clear();
                }

            }*/

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
          //  MessageBox.Show("1");
              DataRowView dav = (DataRowView)ListView1.SelectedItem;
           //   dav.Delete();
              BT_beixuanzhong.Content = dav["ItemName"].ToString();
              BT_Delete_Click(sender,e);
        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }
    }
}

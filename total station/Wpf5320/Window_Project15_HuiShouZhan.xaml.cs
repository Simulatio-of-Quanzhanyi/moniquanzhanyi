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
using System.IO;

namespace Wpf5320
{
    /// <summary>
    /// Window_Project15.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project15 : Window
    {
  //      private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
  
        public Window_Project15()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

            string sql = "select ItemName,ItemDate from DeleteItem";
            DataSet ds = DBClass.ConditionQuery(sql);
            ListView1.ItemsSource = ds.Tables[0].DefaultView;

     /*       string itemName, itemdate;
            int temp;
            var sb = new StringBuilder();
            // 读取数据库在listbox控件显示
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            // string sql = "SELECT ItemName,ItemDate FROM DeleteItem";
            string sql = "select 项目名称,修改时间 from DeleteItem";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                itemName = ds.Tables[0].Rows[i]["项目名称"].ToString();
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
                    itemdate = ds.Tables[0].Rows[i]["修改时间"].ToString();
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

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                // MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void Bt_Delete_Click(object sender, RoutedEventArgs e)
        {

            //在数据库中删除
            if (ListView1.SelectedIndex > -1)
            {
                DataRowView dav = (DataRowView)ListView1.SelectedItem;
                dav.Delete();
                BT_beixuanzhong.Content = "default";
                String ItemName = dav["ItemName"].ToString();
                //要删除的项目在ItemInfor中删除
                string sql = "delete * from DeleteItem where ItemName='" + ItemName + "'";
                DBClass.Manipulation_CMD(sql);
            }
            else
            {
                MessageBox.Show("没有选择删除项目");
            }


            //在数据库中删除
            //按项目名称删除
        /*    string ItemName = ItemList.SelectedItem.ToString().Substring(0, 15).Trim();
            string sql = "select * from DeleteItem where 项目名称='" + ItemName + "'";
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
                sql = "delete * from DeleteItem where 项目名称='" + ItemName + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("删除成功！", "提示");
                //   conn.Close();
            }

            string itemName, itemdate;
            int temp;
            var sb = new StringBuilder();
            sql = "select 项目名称,修改时间 from DeleteItem";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ItemList.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                itemName = ds.Tables[0].Rows[i]["项目名称"].ToString();
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
                    itemdate = ds.Tables[0].Rows[i]["修改时间"].ToString();
                    ItemList.Items.Add(itemName + itemdate);
                    sb.Clear();
                }

            }*/

        }

        private void Bt_Recover_Click(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedIndex > -1)
            {
                DataRowView dav = (DataRowView)ListView1.SelectedItem;
                dav.Delete();
                BT_beixuanzhong.Content = "default";
                //要删除的项目添加到删除项目数据库
                String ItemName = dav["ItemName"].ToString();
         //       sql = "insert into DeleteItem(项目名称,项目作者,项目解释,修改时间) select ItemName,ItemAuthor,ItemAnnotation,ItemDate from ItemInfor where ItemName='" + ItemName + "'";
                string sql = "insert into ItemInfor(ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount) select ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount from DeleteItem where ItemName='" + ItemName + "'";
               // string sql = "insert into DeleteItem(ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount) select ItemName,ItemAuthor,ItemAnnotation,ItemDate,PointCount,CodeCount from ItemInfor where ItemName='" + ItemName + "'";
                DBClass.Manipulation_CMD(sql);
                //要删除的项目在ItemInfor中删除
                sql = "delete * from DeleteItem where ItemName='" + ItemName + "'";
                DBClass.Manipulation_CMD(sql);
            }
            else
            {
                MessageBox.Show("没有选择删除项目");
            }
            /*   OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string ItemName = ItemList.SelectedItem.ToString().Substring(0, 15).Trim();
            string sql = "select * from DeleteItem where 项目名称='" + ItemName + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);


            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("恢复失败！", "提示");
                conn.Close();
            }
            else
            {
                //先插入后删除
                sql = "INSERT INTO ItemInfor(ItemName, ItemAuthor, ItemAnnotation,ItemDate) SELECT 项目名称, 项目作者, 项目解释,修改时间 FROM DeleteItem";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //在原记录中删除
                sql = "delete * from DeleteItem where 项目名称='" + ItemName + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            //listbox重新显示
            ItemList.Items.Clear();
            string itemName, itemdate;
            int temp;
            var sb = new StringBuilder();
            // 读取数据库在listbox控件显示
            conn.Open();
            // string sql = "SELECT ItemName,ItemDate FROM DeleteItem";
            sql = "select 项目名称,修改时间 from DeleteItem";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                itemName = ds.Tables[0].Rows[i]["项目名称"].ToString();
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
                    itemdate = ds.Tables[0].Rows[i]["修改时间"].ToString();
                    //                   itemdate = itemdate.Substring(0, itemdate.Length - 7);

                    ItemList.Items.Add(itemName + itemdate);
                    sb.Clear();
                }

            }*/
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

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
    /// Window_jianzhan2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan2 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
       
        public Window_jianzhan2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            Random ran = new Random();    //随机产生度分秒数值
            string angle1 = ran.Next(0,180).ToString();
            string angle2 = ran.Next(0, 60).ToString();
            string angle3 = ran.Next(0, 60).ToString();
            string ha = angle1 + "." + angle2 + angle3;
            HA.Content = ha;
            if(DBClass.Judge("select 点名 from CreatePoint"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from CreatePoint";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stationtext.Text = dr.GetString(0).ToString();
                }
                conn.Close();     
            }
            if (DBClass.Judge("select 点名 from Createrearview"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from Createrearview";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   rearviewpoint_textbox.Text = dr.GetString(0).ToString();
                }
                conn.Close();
            }
                 
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1= new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            if (stationtext.Text==""||YH.Text==""||JH.Text=="")
            {
                MessageBox.Show("请输入（选择）相关数据！", "提示");
            }
            else
            {
                if(rearview_point.Visibility==0)
                {
                    if (rearviewpoint_textbox.Text == "")
                        MessageBox.Show("后视点不能为空！");
                    else
                    {
                        OleDbConnection conn = new OleDbConnection(odbcConnStr);
                        conn.Open();
                        string sql = "select * from Buildstation where 测站='" + stationtext.Text.Trim() + "'";
                        OleDbCommand cmd = new OleDbCommand(sql, conn);                       
                        if (cmd.ExecuteScalar() != null)
                        {                          
                                sql = "Insert into Buildstation (测站,仪高,镜高,后视点,后视角,HA) Values('" + stationtext.Text.Trim() + "','" + YH.Text.Trim() + "','" + JH.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "','" + HA.Content + "')";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                sql = "Delete from rearview_checking";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                sql = "Insert into rearview_checking (测站点名,后视点名,BS) Values('" + stationtext.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + HA.Content + "')";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("设置成功！", "提示");
                                conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("该已知点不存在！","提示");
                        }
                    }                       
                }
                else
                {                   
                        if (rearview_angle.Visibility == 0)
                        {
                            if (rearviewangle_textbox.Text == "")
                                MessageBox.Show("请输入后视角！");
                            else
                            {
                                string sql = "select * from Buildstation where 测站='" + stationtext.Text.Trim() + "'";
                                if (DBClass.Judge(sql))
                                {
                                    if (MessageBox.Show("已经存在的测站点，是否覆盖？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        DBClass.Manipulation("Update Buildstation set 仪高='" + YH.Text.Trim() + "',镜高='" + JH.Text.Trim() + "',后视点='" + rearviewpoint_textbox.Text.Trim() + "',后视角='" + rearviewangle_textbox.Text.Trim() + "' where测站='" + stationtext.Text.Trim() + "'");
                                        ESC_Click(sender, e);
                                    }
                                }
                                else
                                {
                                    sql = "Insert into Buildstation (测站,仪高,镜高,后视点,后视角,HA) Values('" + stationtext.Text.Trim() + "','" + YH.Text.Trim() + "','" + JH.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "','" + HA.Content + "')";
                                    DBClass.Manipulation(sql);
                                    sql = "Delete from rearview_checking";
                                    DBClass.Manipulation(sql);
                                    sql = "Insert into rearview_checking (测站点名,后视点名,BS) Values('" + stationtext.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "')";
                                    DBClass.Manipulation(sql);           
                                    MessageBox.Show("设置成功！", "提示");
                                }
                            }                          
                        }                     
                    }
                }                          
            }

        private void rearview_point_Click(object sender, RoutedEventArgs e)
        {
            rearview_combox.Visibility = (Visibility)1;
            rearview_point.Visibility = (Visibility)1;
            rearviewpoint_textbox.Visibility = (Visibility)1;
            rearview_angle.Visibility = 0;
            DMS.Visibility =0;
            rearviewangle_textbox.Visibility = 0;
        }

        private void rearview_angle_Click(object sender, RoutedEventArgs e)
        {          
            rearview_angle.Visibility = (Visibility)1;
            DMS.Visibility = (Visibility)1;
            rearviewangle_textbox.Visibility = (Visibility)1;
            rearview_combox.Visibility = 0;
            rearview_point.Visibility = 0;
            rearviewpoint_textbox.Visibility = 0;
        }
       
        private void diaoyong1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_diaoyong diaoyong =new Window_jianzhan2_YiZhiDian_diaoyong();
            diaoyong.Show();
            this.Close();

        }

        private void diaoyong2_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_DY DY =new Window_jianzhan2_YiZhiDian_DY();
            DY.Show();
            this.Close();
        }

        private void xinjian1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_new jianzhan_new = new Window_jianzhan2_YiZhiDian_new();
            jianzhan_new.Show();
            this.Close();
        }

        private void xinjian2_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDianHSD_NEW jianzhan_new = new Window_jianzhan2_YiZhiDianHSD_NEW();
            jianzhan_new.Show();
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

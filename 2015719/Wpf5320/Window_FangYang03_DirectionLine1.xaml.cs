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
    /// Window_FangYang03_fangxiangxian.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang03_DirectionLine1 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_FangYang03_DirectionLine1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

            if (DBClass.Judge("select 点名 from CreatePoint"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from CreatePoint";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    PointName1text.Text = dr.GetString(0).ToString();
                }
                conn.Close();
            }

            
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang window_FangYang = new Window_FangYang();
            window_FangYang.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenNEXT(object sender, RoutedEventArgs e)
        {
            if (PointName1.Text.Trim() != "" && FangWeiJiao.Text.Trim() != "" && PingJu.Text.Trim() != "" && PingJu.Text.Trim() != "" && GaoCha.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select * from FangYang_DirectionLine where 点名='" + PointName1.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                sql = "insert into FangYang_DirectionLine (点名,方位角,平距,高差,镜高,右转,移近,向左,填方,HA,HD,Z) values ('"
                    + PointName1.Text.Trim() + "','" + FangWeiJiao.Text.Trim() + "','" + PingJu.Text.Trim() + "' ,'" + GaoCha.Text.Trim() + "' ," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + ")";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("存储成功！");
                conn.Close();


                Window_FangYang03_fangxiangxian2 window_FangYang03_fangxiangxian2 = new Window_FangYang03_fangxiangxian2();
                window_FangYang03_fangxiangxian2.Show();
                this.Close();//关闭当前窗口
            }
            else
            {
                MessageBox.Show("输入值均不能为空！", "提示");
            }
            
            

        }

        private void call1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine3_DY DirectionLine3_DY = new Window_FangYang03_DirectionLine3_DY();
            DirectionLine3_DY.Show();
            this.Close();//关闭当前窗口
        }

        private void new1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine3_New DirectionLine3_New = new Window_FangYang03_DirectionLine3_New();
            DirectionLine3_New.Show();
            this.Close();//关闭当前窗口
        }

        private void input1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine3_Input DirectionLine3_Input = new Window_FangYang03_DirectionLine3_Input();
            DirectionLine3_Input.Show();
            this.Close();//关闭当前窗口
        }

        private void measure1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine3_Survey DirectionLine3_Survey = new Window_FangYang03_DirectionLine3_Survey();
            DirectionLine3_Survey.Show();
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
    }
}

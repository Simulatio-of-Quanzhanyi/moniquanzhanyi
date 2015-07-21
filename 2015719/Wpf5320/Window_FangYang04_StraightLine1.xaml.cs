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
    /// Window_FangYang04_StraightLine1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang04_StraightLine1 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_FangYang04_StraightLine1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();


            ACEESSDB DB = new ACEESSDB();
            if (DB.Judge("select 点名 from CreatePoint"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from CreatePoint";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   Linetext1.Text = dr.GetString(0).ToString();
                }
                conn.Close();
            }

           
            if (DB.Judge("select 点名 from CreatePoint"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from Createrearview";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Linetext2.Text = dr.GetString(0).ToString();
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

            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            if (StartPoint.Text.Trim() != "" && OverPoint.Text.Trim() != "" && LeftRight.Text.Trim() != "" && BeforeAfter.Text.Trim() != "" &&UpDown.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select * from FangYang_StraightLine where FY_StraightLine_ID= 2";
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                sql = "insert into FangYang_StraightLine (起始点,结束点,左右,前后,上下,镜高,右转,移远,向左,填方,HA,HD,Z) values ('"
                    + StartPoint.Text.Trim() + "','" + OverPoint.Text.Trim() + "','" + LeftRight.Text.Trim() + "' ,'" + BeforeAfter.Text.Trim() + "' ," + UpDown.Text.Trim() + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + ")";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("已成功存储！");
                conn.Close();
            }
            else
            {
                MessageBox.Show("输入值均不能为空！", "提示");
            }


            Window_FangYang04_StraightLine2 window_FangYang04_StraightLine2 = new Window_FangYang04_StraightLine2();
            window_FangYang04_StraightLine2.Show();
            this.Close();//关闭当前窗口
        }

        private void ZY(object sender, RoutedEventArgs e)
        {

            LeftRight.IsEnabled = true;
        }
        private void QH(object sender, RoutedEventArgs e)
        {
            BeforeAfter.IsEnabled = true;
        }
        private void SX(object sender, RoutedEventArgs e)
        {
            UpDown.IsEnabled = true;
        }


        private void call1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_DY1 DY1 = new Window_FangYang04_StraightLine1_DY1();
            DY1.Show();
            this.Close();

        }
        private void new1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_New1 New1 = new Window_FangYang04_StraightLine1_New1();
            New1.Show();
            this.Close();
        }
        private void input1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_Input1 Input1 = new Window_FangYang04_StraightLine1_Input1();
            Input1.Show();
            this.Close();
        }
        private void measure1_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_Survey1 Survey1 = new Window_FangYang04_StraightLine1_Survey1();
            Survey1.Show();
            this.Close();
        }

        private void call2_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_DY2 DY2 = new Window_FangYang04_StraightLine1_DY2();
            DY2.Show();
            this.Close();

        }
        private void new2_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_New2 New2 = new Window_FangYang04_StraightLine1_New2();
            New2.Show();
            this.Close();
        }
        private void input2_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_Input2 Input2 = new Window_FangYang04_StraightLine1_Input2();
            Input2.Show();
            this.Close();
        }
        private void measure2_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1_Survey2 Survey2 = new Window_FangYang04_StraightLine1_Survey2();
            Survey2.Show();
            this.Close();
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

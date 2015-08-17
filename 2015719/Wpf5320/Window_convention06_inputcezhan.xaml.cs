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
    /// Window_convention06srcezhan.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention06srcezhan : Window
    {
        public Window_convention06srcezhan()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 2;
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            if (CCM_N.Text.Trim() != "" && CCM_E.Text.Trim() != "" && CCM_Z.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql1 = "select CCM_N from Convention_CoordinatesMeasure where CCM_N='" + CCM_N.Text.Trim() + "'";
                OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
             
                    sql1 = "update Convention_CoordinatesMeasure set CCM_N = ('"
                        + CCM_N.Text.Trim() +  "') where CCM_ID=1" ;

                    cmd1.CommandText = sql1;
                    cmd1.ExecuteNonQuery();

                    string sql2 = "select CCM_E from Convention_CoordinatesMeasure where CCM_E='" + CCM_E.Text.Trim() + "'";
                    OleDbCommand cmd2 = new OleDbCommand(sql2, conn);

                    sql2 = "update Convention_CoordinatesMeasure set CCM_E = ('"
                        + CCM_E.Text.Trim() +  "') where CCM_ID=1";

                    cmd2.CommandText = sql2;
                    cmd2.ExecuteNonQuery();

                    string sql3 = "select CCM_Z from Convention_CoordinatesMeasure where CCM_Z='" + CCM_Z.Text.Trim() + "'";
                    OleDbCommand cmd3 = new OleDbCommand(sql3, conn);

                    sql3 = "update Convention_CoordinatesMeasure set CCM_Z = ('"
                        + CCM_Z.Text.Trim() + "') where CCM_ID=1";

                    cmd3.CommandText = sql3;
                    cmd3.ExecuteNonQuery();
                    myMessageBox my = new myMessageBox();
                    my.show("测站添加成功！");
                 conn.Close();
            }
            else
            {
                MessageBox.Show("测站坐标名称不能为空！", "提示!");
            }
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

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
    /// Window_convention02zhipan.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention02zhipan : Window
    {
        public Window_convention02zhipan()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

            //产生随机数
            //Random ran = new Random();
            //int rndInt = ran.Next(1,100);
            //CAM_HL.Text = rndInt.ToString();
           

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 3;
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            if (CAM_HL.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                //double CAM_HL.Text.Trim()
                double m = Convert.ToDouble( CAM_HL.Text.Trim());
                int A = Convert.ToInt32(m);
                double B = m - A ;
                int C = Convert.ToInt32(B * 100);                
                int D =Convert.ToInt32((B*100 - C)*100);
                string EF = A.ToString() + "°" + C.ToString() + "′" + D.ToString() + "″";
                myMessageBox my = new myMessageBox();
                my.show(EF);
                //MessageBox.Show(EF);
                string sql = "select CAM_HL from Convention_AngleMeasure where CAM_ID = 1 ";
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                sql = "Update Convention_AngleMeasure Set CAM_HL = '" + EF + "' Where CAM_ID = 1";
                //sql = "Insert into Convention_AngleMeasure (CAM_HL) values ('" + EF + "') ";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                   // myMessageBox my = new myMessageBox();
                    my.show("角度置盘成功！"); 
                   // MessageBox.Show("角度置盘成功！");                    
                   conn.Close();
            }
            else
            {
                myMessageBox my = new myMessageBox();
                my.show("输入角度不能为空！");
                //MessageBox.Show("输入角度不能为空！", "提示");
            }


            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 3;
            this.Close();//关闭当前窗口
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {

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

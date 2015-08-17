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
    /// Window_jianzhan7_DuoDian1_celiang.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan7_DuoDian1_celiang : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_jianzhan7_DuoDian1_celiang()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            ACEESSDB DB = new ACEESSDB();
            OleDbDataReader dr;
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            string sql = "select 站名 from HFJH_2";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pointname.Text = dr.GetString(0).ToString();
            }
            conn.Close();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_1 window_jianzhan7 = new Window_jianzhan7_1();
            window_jianzhan7.Show();
            this.Close();//关闭当前窗口
        }

        private void diaoyong1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian1_celiang_DY win = new Window_jianzhan7_DuoDian1_celiang_DY();
            win.Show();
            this.Close();
        }

        private void xinjian1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian1_celiang_NEW xinjian = new Window_jianzhan7_DuoDian1_celiang_NEW();
            xinjian.Show();
            this.Close();
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian1_celiang_input win = new Window_jianzhan7_DuoDian1_celiang_input();
            win.Show();
            this.Close();
        }
        private void angle_Click(object sender, RoutedEventArgs e)
        {
            if (SD.Content.ToString() != "")
            {
                SD.Content = "";
            }
            HA.Content = ToolCase.huduTojiaodu(ToolCase.HA);
            VA.Content = ToolCase.huduTojiaodu(ToolCase.VA);
        }

        private void distance_Click(object sender, RoutedEventArgs e)
        {
            if (HA.Content.ToString() == "")
                angle_Click(sender, e);
            SD.Content = Convert.ToSingle(ToolCase.Distance).ToString();
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            string s = "输入";
            if (pointname.Text.Trim() != s)
            {
                string sql = "select * from Buildstation where 测站='" + pointname.Text.Trim() + "'";
                bool B = DBClass.Judge(sql);
                if (B)  //调用
                {
                    DBClass.Manipulation("Update Buildstation set 镜高='" + JH.Text.Trim() + "',水平角='" + HA.Content + "',垂直角='" + VA.Content + "',斜距='" + SD.Content + "' where 站名='" + pointname.Text.Trim() + "' where 测站='" + pointname.Text.Trim() + "'");
                    ESC_Click(sender, e);
                }
                else  //新建
                {
                   /* ACEESSDB insert = new ACEESSDB();
                    insert.Manipulation("Update HFJH_2 set 镜高='" + JH.Text.Trim() + "',水平角='" + HA.Content + "',垂直角='" + VA.Content + "',斜距='" + SD.Content + "' where 站名='" + pointname.Text.Trim() + "'");
                    insert.Manipulation("Insert into Buildstation (测站,镜高,N,E,Z,水平角,垂直角,斜距) select 站名,镜高,N,E,Z,水平角,垂直角,斜距 from HFJH_2");
                   */
                    Window_jianzhan7_DuoDian1_celiang_NEW win = new Window_jianzhan7_DuoDian1_celiang_NEW();
                    win.Show();
                    this.Close();
                }
            }
            else   //输入
            {
                DBClass.Manipulation("Update HFJH_2 set 镜高='" + JH.Text.Trim() + "',水平角='" + HA.Content + "',垂直角='" + VA.Content + "',斜距='" + SD.Content + "' where 站名='" + pointname.Text.Trim() + "'");
                DBClass.Manipulation("Insert into Buildstation (测站,镜高,N,E,Z,水平角,垂直角,斜距) select 站名,镜高,N,E,Z,水平角,垂直角,斜距 from HFJH_2");
                ESC_Click(sender, e);
            }
           
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }
    }
}


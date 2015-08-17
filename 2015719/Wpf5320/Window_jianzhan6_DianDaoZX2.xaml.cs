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
    /// Window_jianzhan6_2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan6_2 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_jianzhan6_2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            string rear=ToolCase.huduTojiaodu(ToolCase.HA);
            rearview.Content = rear;
            Random ran = new Random();
            double n = ToolCase.Distance;
            N.Content = Convert.ToSingle(n).ToString();
          /*  Random ran2 = new Random();
            string e = Convert.ToSingle(ran2.NextDouble() * 100).ToString();
            E.Content = e;*/
            Random ran1 = new Random();
            string z = Convert.ToSingle(ran.NextDouble()*100).ToString();
            Z.Content = z;
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            if (station.Text.ToString()=="")
            {
                MessageBox.Show("请输入站名");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select * from Buildstation where 测站='" + station.Text.ToString().Trim() + "'";
                bool B = DBClass.Judge(sql);
                if (B)
                {                   
                    MessageBox.Show("该点名已存在！","提示");
                }
                else
                {
                    DBClass.Manipulation("Insert into Buildstation(测站,N,E,Z,后视角,方位角) Values('" + station.Text.Trim() + "','" + N.Content.ToString().Trim() + "','" + E.Content.ToString().Trim() + "','" + Z.Content.ToString().Trim() + "','" + rearview.Content.ToString() + "','" + fangweijiao.Content.ToString() + "')");
                    MessageBox.Show("设置成功！", "提示");                   
                }               
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

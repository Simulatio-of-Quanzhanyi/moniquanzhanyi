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
    /// Window_jianzhan7.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan7 : Window
    {
        public Window_jianzhan7()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (station.Text.ToString() != "")
            {
                ACEESSDB DB = new ACEESSDB();
                if (DB.Judge("select 测站 from Buildstation where 测站='" + station.Text.Trim() + "'"))//判断测站是否存在，不存在不能进行下一步
                {
                    DB.Manipulation("Update Buildstation set 仪高='" + YH.Text.Trim() + "',镜高='" + JH.Text.Trim() + "' where 测站='" + station.Text.Trim() + "' ");
                    Window_jianzhan7_1 window_jianzhan7_1 = new Window_jianzhan7_1();
                    window_jianzhan7_1.Show();
                    this.Close();//关闭当前窗口
                }  
                else
                {
                    MessageBox.Show("该测站不存在！");
                }
            }
            else
            {
                MessageBox.Show("请输入站名！");
            }
        }

        private void diaoyong1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian_diaoyong win = new Window_jianzhan7_DuoDian_diaoyong();
            win.Show();
            this.Close();
        }

        private void xinjian1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian_new win = new Window_jianzhan7_DuoDian_new();
            win.Show();
            this.Close();
        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }
    }
}

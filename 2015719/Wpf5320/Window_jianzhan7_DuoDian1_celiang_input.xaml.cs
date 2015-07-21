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

namespace Wpf5320
{
    /// <summary>
    /// Window_jianzhan7_DuoDian1_celiang_input.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan7_DuoDian1_celiang_input : Window
    {
        public Window_jianzhan7_DuoDian1_celiang_input()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_DuoDian1_celiang win = new Window_jianzhan7_DuoDian1_celiang();
            win.Show();
            this.Close();
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (N.Text.ToString().Trim() == "" || E.Text.ToString().Trim() == "" || Z.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                ACEESSDB DB = new ACEESSDB();
                string s = "输入";
                DB.Manipulation("Delete from HFJH_2");
                DB.Manipulation("Insert into HFJH_2 (站名,N,E,Z) Values('" + s + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
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
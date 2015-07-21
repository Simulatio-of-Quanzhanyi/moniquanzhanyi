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
    /// Window_jianzhan7_2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan7_2 : Window
    {        
        public Window_jianzhan7_2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            HA.Content = ToolCase.huduTojiaodu(ToolCase.HA);
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan7_1 window_jianzhan7_1 = new Window_jianzhan7_1();
            window_jianzhan7_1.Show();
            this.Close();//关闭当前窗口
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("设置成功！");
            setting.Visibility = (Visibility)1;
            FanHui.Visibility = (Visibility)1;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 can = new Window_jianzhan1();
            can.Show();
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

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

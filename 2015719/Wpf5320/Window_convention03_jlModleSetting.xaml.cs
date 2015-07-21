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
    /// Window_convention03_ModleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention03_ModleSetting : Window
    {
        public Window_convention03_ModleSetting()
        {
            InitializeComponent(); systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 1;
            this.Close();//关闭当前窗口

        }




        private void Battery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("设置成功！");
            Window_convention01 window_convention01 = new Window_convention01();
            window_convention01.Show();
            window_convention01.tabControl1.SelectedIndex = 1;
            this.Close();//关闭当前窗口
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

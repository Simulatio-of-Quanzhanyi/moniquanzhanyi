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
    /// Window_Shortcut_key.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Shortcut_key : Window
    {
        public Window_Shortcut_key()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

       /* private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("主界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }
        */
        private void ppm_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key_PPM key = new Window_Shortcut_key_PPM();
            key.Show();
            this.Close();//关闭当前窗口
        }

        private void target_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key_HZMB key = new Window_Shortcut_key_HZMB();
            key.Show();
            this.Close();//关闭当前窗口
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Start start = new Window_Start();
            start.Show();
            this.Close();//关闭当前窗口
        }

        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            Window_Short_key_calculate window_Short_key_calculate = new Window_Short_key_calculate();
            window_Short_key_calculate.Show();
            this.Close();//关闭当前窗口
        }
      

        private void JGZSred_Click(object sender, RoutedEventArgs e)
        {
            JGZSblue.Visibility = 0;
            JGZSred.Visibility = (Visibility)1;
        }

        private void JGZSblue_Click(object sender, RoutedEventArgs e)
        {
            JGZSblue.Visibility = (Visibility)1;
            JGZSred.Visibility = 0;
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

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
    /// adjust6.xaml 的交互逻辑
    /// </summary>
    public partial class adjust6 : Window
    {
        public adjust6()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                //MessageBox.Show("主界面退出！");//在全站仪界面中加载
                myMessageBox my = new myMessageBox();
                my.show("需要输入的提示语句");
                Application.Current.Shutdown();
            }

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {

            Window_adjust window_adjust = new Window_adjust();
            window_adjust.Show();
            this.Close();//关闭当前窗口

        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
            {
                DragMove();
            }
        }
    }
}

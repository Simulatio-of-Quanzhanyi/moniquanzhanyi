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
    /// Window_Shutdown_PowerOff.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Shutdown_PowerOff : Window
    {
        public Window_Shutdown_PowerOff()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting17_Power Setting17_Power = new Window_Setting17_Power();
            Setting17_Power.Show();
            this.Close();//关闭当前窗口
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Start Start = new Window_Start();
            Start.Show();
            this.Close();//关闭当前窗口 
        }

        private void dormant_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("进入休眠状态！");
            Grid2.Visibility = Visibility.Visible;
            dormant1.Visibility=Visibility.Visible;
            Grid1.Visibility = Visibility.Hidden;
            dormant.Visibility = Visibility.Hidden;
            poweroff.Visibility = Visibility.Hidden;
            systime.Visibility = Visibility.Hidden;
        }

        private void poweroff_Click(object sender, RoutedEventArgs e)
        {

            //if (MessageBox.Show("确定关机吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            //{             
            //    Application.Current.Shutdown();
            //}

            myMessageBox my = new myMessageBox();
            my.show("开机界面退出！");
          //  Application.Current.Shutdown();
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
            {
                DragMove();
            }
        }

 
        private void dormant1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("解除休眠状态！");
            Grid2.Visibility = Visibility.Hidden;
            dormant1.Visibility = Visibility.Hidden;
            Grid1.Visibility = Visibility.Visible;
            dormant.Visibility = Visibility.Visible;
            poweroff.Visibility = Visibility.Visible;
            systime.Visibility = Visibility.Visible;
        }
    }
}

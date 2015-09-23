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
    /// Window_Project21.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project21 : Window
    {
        public Window_Project21()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window_Project20 window_Start1 = new Window_Project20();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Project20 window_Start1 = new Window_Project20();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void DaoChu_Click(object sender, RoutedEventArgs e)
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

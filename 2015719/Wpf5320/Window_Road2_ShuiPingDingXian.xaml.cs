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
    /// Window_Road2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Road2 : Window
    {
        public Window_Road2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }



        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Road window_Road = new Window_Road();
            window_Road.Show();
            this.Close();//关闭当前窗口
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Road3_2 win = new Window_Road3_2();
            win.Show();
            this.Close();            
        }

        private void Adit_Click(object sender, RoutedEventArgs e)
        {
            Window_Road3_1 win = new Window_Road3_1();
            win.Show();
            this.Close(); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Road1_Selected_new : Window
    {
        public Window_Road1_Selected_new()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }
        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
            {
                DragMove();
            }
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Road1 win = new Window_Road1();
            win.Show();
            this.Close();
        }
    }
}

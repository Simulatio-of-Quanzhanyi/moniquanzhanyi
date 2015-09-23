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
    /// Window_Road3_2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Road3_2 : Window
    {
        public Window_Road3_2()
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


        private void straight_line_Checked(object sender, RoutedEventArgs e)
        {
            Mitigated_curve.Visibility = (Visibility)1;
            Circle_curve.Visibility = (Visibility)1;  
            Straightline.Visibility = 0;
        }

        private void circle_Click(object sender, RoutedEventArgs e)
        {
            Straightline.Visibility = (Visibility)1;
            Mitigated_curve.Visibility = (Visibility)1; 
            Circle_curve.Visibility = 0;

        }

        private void Mitigatecurve_Click(object sender, RoutedEventArgs e)
        {
            Straightline.Visibility = (Visibility)1;
            Circle_curve.Visibility = (Visibility)1;  
            Mitigated_curve.Visibility = 0;
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Road2 win = new Window_Road2();
            win.Show();
            this.Close();  
        }

    }
}

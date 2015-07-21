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
    ///Window_jianzhan6.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan6 : Window
    {
        string a;
        public Window_jianzhan6()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            Random ran = new Random();
            a = Convert.ToSingle(ran.NextDouble()).ToString();
            //window_jianzhan6_1.dVD_label.Content = a;
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan6_1 window_jianzhan6_1 = new Window_jianzhan6_1();
            float ahd= Convert.ToSingle(AHD.Content.ToString());
            float bhd = Convert.ToSingle(BHD.Content.ToString());
            float dhd = ahd - bhd;           
            window_jianzhan6_1.dVD_label.Content = a;
            window_jianzhan6_1.dHD_label.Content = dhd.ToString();
            window_jianzhan6_1.Show();
            this.Close();//关闭当前窗口
        }

        private void CLA_Click(object sender, RoutedEventArgs e)
        {
            AHD.Content = Convert.ToSingle(ToolCase.Distance).ToString(); 
            if(BHD.Content.ToString()!="")
            {
                Next.Visibility = 0;
            }
        }

        private void CLB_Click(object sender, RoutedEventArgs e)
        {
            BHD.Content =  Convert.ToSingle(ToolCase.Distance).ToString();
            if (AHD.Content.ToString() != "")
            {
                Next.Visibility = 0;
            }
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

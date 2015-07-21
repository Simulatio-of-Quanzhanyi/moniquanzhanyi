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
    /// Window_jianzhan6_1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan6_1 : Window
    {
        string fangwei,s;
        public Window_jianzhan6_1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();                      
            Random ran = new Random();
            string dsd =  Convert.ToSingle(ran.NextDouble()).ToString();
            dSD_label.Content = dsd;
            if (ToolCase.HA<=180)
                fangwei = ToolCase.huduTojiaodu(ToolCase.HA);
            else
                fangwei = ToolCase.huduTojiaodu(ToolCase.HA-180);
            s = Convert.ToSingle(ToolCase.Distance).ToString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan6 window_jianzhan6 = new Window_jianzhan6();
            window_jianzhan6.Show();
            this.Close();//关闭当前窗口
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan6_2 window_jianzhan6_2 = new Window_jianzhan6_2();            
            window_jianzhan6_2.fangweijiao.Content = fangwei;
            window_jianzhan6_2.E.Content = s;
            window_jianzhan6_2.Show();            
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

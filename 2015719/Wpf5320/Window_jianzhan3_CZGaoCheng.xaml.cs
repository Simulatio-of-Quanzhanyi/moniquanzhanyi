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
    /// Window_jianzhan3.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan3 : Window
    {
        public Window_jianzhan3()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            Random ran = new Random();
            string _VD = ran.Next(0, 999).ToString();
            string distan = "1." + _VD;
            VD_label.Content = distan;
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void measure_Click(object sender, RoutedEventArgs e)
        {
            if (elevation.Text == "")
            {
                MessageBox.Show("请输入已知点高程值！");
            }
            else
            {
                float jh,eh,vd,js,yh;
                eh = Convert.ToSingle(elevation.Text);
                jh = Convert.ToSingle(JH.Text);
                vd = Convert.ToSingle(VD_label.Content);
                yh = Convert.ToSingle(YH.Text);
                js = eh + jh + vd - yh;
                stationH_JS.Content = js.ToString();
            }           

        }

        private void diaoyong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            stationH_NOW.Content = stationH_JS.Content;
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

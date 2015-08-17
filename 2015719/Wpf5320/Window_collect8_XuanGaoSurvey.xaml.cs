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
    /// collect8.xaml 的交互逻辑
    /// </summary>
    public partial class collect8 : Window
    {
        double VA0,VA1, dis;
        public collect8()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            double  VA1,HDVD;
            VA1 = ToolCase.VARadom;
            HDVD = 0;
            LBVA1.Content = ToolCase.huduTojiaodu(VA1);
            LBVD.Content = HDVD.ToString("f03");

        }

        private void BTVA0_Click(object sender, RoutedEventArgs e)
        {

            VA0 = ToolCase.VARadom;
            LBVA0.Content = ToolCase.huduTojiaodu(VA0);
            LBVA1.Content = ToolCase.huduTojiaodu(VA0);
            
        }

        private void BTDis_VA_Click(object sender, RoutedEventArgs e)
        {

            VA0=ToolCase.VARadom;
            LBVA0.Content = ToolCase.huduTojiaodu(VA0);
            dis = ToolCase.DistanceRadom;
            LBVA1.Content = ToolCase.huduTojiaodu(VA0);
            LBHD.Content = dis.ToString("f03");
        }

        private void BT_angle_Click(object sender, RoutedEventArgs e)
        {
           //增加角度
            double HDVD;
            double h1, h2;

            VA1= ToolCase.VARadom;
            LBVA1.Content = ToolCase.huduTojiaodu(VA1);
            h1 = dis * Math.Tan(VA1);
            h2 = dis * Math.Tan(VA0);
            HDVD = h1 - h2 + Convert.ToDouble(TBJinggao.Text);
            LBVD.Content = HDVD.ToString("f03");
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

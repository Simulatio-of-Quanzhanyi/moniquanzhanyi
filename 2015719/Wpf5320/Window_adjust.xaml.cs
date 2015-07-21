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
    /// adjust.xaml 的交互逻辑
    /// </summary>
    public partial class Window_adjust : Window
    {
        public Window_adjust()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Start window_Start = new Window_Start();
            window_Start.Show();
            this.Close();//关闭当前窗口
        }


        private void BuChangQi_Click(object sender, RoutedEventArgs e)
        {
            adjust1 window_adjust1 = new adjust1();
            window_adjust1.Show();
            this.Close();//关闭当前窗口
        }

        private void ChuiZhiJiao_Click(object sender, RoutedEventArgs e)
        {
            adjust2 window_adjust2 = new adjust2();
            window_adjust2.Show();
            this.Close();//关闭当前窗口
        }

        private void YiQiCS_Click(object sender, RoutedEventArgs e)
        {
            adjust3 window_adjust3 = new adjust3();
            window_adjust3.Show();
            this.Close();//关闭当前窗口
        }

        private void ChuMoPing_Click(object sender, RoutedEventArgs e)
        {
            adjust4 window_adjust4 = new adjust4();
            window_adjust4.Show();
            this.Close();//关闭当前窗口
        }

        private void TuoLuoYi_Click(object sender, RoutedEventArgs e)
        {
            adjust5 window_adjust5 = new adjust5();
            window_adjust5.Show();
            this.Close();//关闭当前窗口
        }

        private void YingXingCenter_Click(object sender, RoutedEventArgs e)
        {
            adjust6 window_adjust6 = new adjust6();
            window_adjust6.Show();
            this.Close();//关闭当前窗口
        }
        ///////
        private void OpenCalculate(object sender, RoutedEventArgs e)
        {
            Window_calculate window_calculate = new Window_calculate();
            window_calculate.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenConvention(object sender, RoutedEventArgs e)
        {
            Window_convention window_convention = new Window_convention();
            window_convention.Show();
            this.Close();//关闭当前窗口   
        }

        private void OpenFangYang(object sender, RoutedEventArgs e)
        {
            Window_FangYang window_FangYang = new Window_FangYang();
            window_FangYang.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenProject(object sender, RoutedEventArgs e)
        {
            Window_Project window_Project = new Window_Project();
            window_Project.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenDataManagement(object sender, RoutedEventArgs e)
        {
            Window_Data window_Data = new Window_Data();
            window_Data.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenSetting(object sender, RoutedEventArgs e)
        {
            Window_Setting window_Setting = new Window_Setting();
            window_Setting.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenAdjust(object sender, RoutedEventArgs e)
        {
            Window_adjust window_adjust = new Window_adjust();
            window_adjust.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenBuild(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenCollect(object sender, RoutedEventArgs e)
        {
            collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenRoad(object sender, RoutedEventArgs e)
        {
            Window_Road window_Road = new Window_Road();
            window_Road.Show();
            this.Close();//关闭当前窗口
        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key window_Shortcut_key = new Window_Shortcut_key();
            window_Shortcut_key.Show();
            this.Close();//关闭当前窗口
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting17_Power Setting17_Power = new Window_Setting17_Power();
            Setting17_Power.Show();
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

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
    /// Window_jianzhan1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan1 : Window
    {
        public Window_jianzhan1()
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

        private void YiZhiDian_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan2 window_jianzhan2 = new Window_jianzhan2();
            window_jianzhan2.Show();
            this.Close();//关闭当前窗口

        }

        private void CeZhanGaoCheng_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan3 window_jianzhan3 = new Window_jianzhan3();
            window_jianzhan3.Show();
            this.Close();//关闭当前窗口

        }
        private void HouShiJianCha_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan4 window_jianzhan4 = new Window_jianzhan4();
            window_jianzhan4.Show();
            this.Close();//关闭当前窗口

        }
        private void HouFangJiaoHui_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan5 window_jianzhan5 = new Window_jianzhan5();
            window_jianzhan5.Show();
            this.Close();//关闭当前窗口

        }
   
        private void DianDaoZhiXian_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan6 window_jianzhan6 = new Window_jianzhan6();
            window_jianzhan6.Show();
            this.Close();//关闭当前窗口

        }
        private void DuoDianDingXiang_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan7 window_jianzhan7 = new Window_jianzhan7();
            window_jianzhan7.Show();
            this.Close();//关闭当前窗口

        }
        /////
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
    }
}

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
    ///Window_Setting1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Setting : Window
    {
        public Window_Setting()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("主界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Start window_Start = new Window_Start();
            window_Start.Show();
            this.Close();//关闭当前窗口
        }

        private void DanWei_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting11 window_Setting11 = new Window_Setting11();
            window_Setting11.Show();
            this.Close();//关闭当前窗口
        }

        private void Angle_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting12 window_Setting12 = new Window_Setting12();
            window_Setting12.Show();
            this.Close();//关闭当前窗口
        }

        private void Distance_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting13 window_Setting13 = new Window_Setting13();
            window_Setting13.Show();
            this.Close();//关闭当前窗口
        }

        private void ZuoBiao_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting14 window_Setting14 = new Window_Setting14();
            window_Setting14.Show();
            this.Close();//关闭当前窗口
        }

        private void Communication_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting15 window_Setting15 = new Window_Setting15();
            window_Setting15.Show();
            this.Close();//关闭当前窗口
        }

        private void Bluetooth_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting16 window_Setting16 = new Window_Setting16();
            window_Setting16.Show();
            this.Close();//关闭当前窗口
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            //暂无
        }

        private void Other_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting17 window_Setting17 = new Window_Setting17();
            window_Setting17.Show();
            this.Close();//关闭当前窗口
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting18_1 window_Setting18_1 = new Window_Setting18_1();
            window_Setting18_1.Show();
            this.Close();//关闭当前窗口
        }

        private void Formatting_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting19 window_Setting19 = new Window_Setting19();
            window_Setting19.Show();
            this.Close();//关闭当前窗口
        }

        private void HuiFuChuChang_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting20 window_Setting20 = new Window_Setting20();
            window_Setting20.Show();
            this.Close();//关闭当前窗口
        }

        private void RuanJianYingYong_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting21 window_Setting21 = new Window_Setting21();
            window_Setting21.Show();
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

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
    /// collect.xaml 的交互逻辑
    /// </summary>
    public partial class collect : Window
    {
        public collect()
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

       /*private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }

        }
        */
        private void PointDistance_Click(object sender, RoutedEventArgs e)
        {
            collect1_PointSurvey1 window_collect1 = new collect1_PointSurvey1();
            window_collect1.Show();
            this.Close();//关闭当前窗口
        }

        private void JuLiPianCha_Click(object sender, RoutedEventArgs e)
        {
            collect2 window_collect2 = new collect2();
            window_collect2.Show();
            this.Close();//关闭当前窗口
        }

        private void PingMianJiaoDian_Click(object sender, RoutedEventArgs e)
        {
            collect3 window_collect3 = new collect3();
            window_collect3.Show();
            this.Close();//关闭当前窗口
        }

        private void YuanZhuCenter_Click(object sender, RoutedEventArgs e)
        {
            collect4 window_collect4 = new collect4();
            window_collect4.Show();
            this.Close();//关闭当前窗口
        }

        private void DuiBianSuevey_Click(object sender, RoutedEventArgs e)
        {
            collect5 window_collect5 = new collect5();
            window_collect5.Show();
            this.Close();//关闭当前窗口
        }

        private void XianHeYanChangDian_Click(object sender, RoutedEventArgs e)
        {
            collect6 window_collect6 = new collect6();
            window_collect6.Show();
            this.Close();//关闭当前窗口
        }

        private void XianHeJiaoDian_Click(object sender, RoutedEventArgs e)
        {
            collect7 window_collect7 = new collect7();
            window_collect7.Show();
            this.Close();//关闭当前窗口
        }

        private void XuanGaoSurvey_Click(object sender, RoutedEventArgs e)
        {
            collect8 window_collect8 = new collect8();
            window_collect8.Show();
            this.Close();//关闭当前窗口
        }

        private void F1F2_Click(object sender, RoutedEventArgs e)
        {
            collect9 window_collect9 = new collect9();
            window_collect9.Show();
            this.Close();//关闭当前窗口
        }

        private void YingXiang_Click(object sender, RoutedEventArgs e)
        {
            collect10 window_collect10 = new collect10();
            window_collect10.Show();
            this.Close();//关闭当前窗口
        }

        //////////////
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

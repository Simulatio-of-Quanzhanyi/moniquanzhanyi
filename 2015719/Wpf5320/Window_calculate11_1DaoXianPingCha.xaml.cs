﻿using System;
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
    /// Window_calculate11_1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_calculate111 : Window
    {
        public Window_calculate111()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_calculate window_calculate = new Window_calculate();
            window_calculate.Show();
            this.Close();//关闭当前窗口
        }

        private void NEXT_Click(object sender, RoutedEventArgs e)
        {
            Window_calculate112 window_calculate112 = new Window_calculate112();
            window_calculate112.Show();
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

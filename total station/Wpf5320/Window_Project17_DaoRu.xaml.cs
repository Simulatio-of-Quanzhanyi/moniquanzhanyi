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
    /// Window_Project17.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project17 : Window
    {
        public Window_Project17()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {


            Window_Project window_Start1 = new Window_Project();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
           // Window_Project18 window_Project18 = new Window_Project18();
         /*   Window_Project18 win = new Window_Project18();
            win.Show();
            this.Close();//关闭当前窗口*/
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

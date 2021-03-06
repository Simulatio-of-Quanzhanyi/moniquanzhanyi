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
using System.Data.OleDb;
using System.Data;

namespace Wpf5320
{
    /// <summary>
    /// Window_jianzhan5_HFJH_1_input.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan5_HFJH_1_input : Window
    {
        public Window_jianzhan5_HFJH_1_input()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan5_1 win = new Window_jianzhan5_1();
            win.Show();
            this.Close();
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (N.Text.ToString().Trim() == "" || E.Text.ToString().Trim() == "" || Z.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {              
                string s= "输入";
                DBClass.Manipulation("Delete from HFJH_2");
                DBClass.Manipulation("Insert into HFJH_2 (站名,N,E,Z) Values('"+s+"','"+N.Text.Trim()+"','"+E.Text.Trim()+"','"+Z.Text.Trim()+"')");
                ESC_Click(sender, e);
            }
               
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

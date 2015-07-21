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
    /// Window_FangYang04_StraightLine1_Input1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang04_StraightLine1_Input1 : Window
    {
        public Window_FangYang04_StraightLine1_Input1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1 StraightLine1 = new Window_FangYang04_StraightLine1();
            StraightLine1.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            if (N.Text.Trim() == "" || E.Text.Trim() == "" || Z.Text.Trim() == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                ACEESSDB DB = new ACEESSDB();
                string s = "输入";
                DB.Manipulation("Insert into HFJH (站名,N,E,Z) Values('" + s + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                DB.Manipulation("Update HFJH_2 set 站名='" + s + "'");
                ESC_Click(sender, e);
            }

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
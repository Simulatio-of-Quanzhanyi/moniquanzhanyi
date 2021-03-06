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
    /// Window_FangYang04_StraightLine1_DY1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang04_StraightLine1_DY1 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_FangYang04_StraightLine1_DY1()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            //打开数据库
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //读取数据库
            string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp.Fill(ds);//将数据源加载到dataset中
            LV.ItemsSource = ds.DefaultView;
            conn.Close();
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Buildstation");
                int c = LV.SelectedIndex;
                string s = ds.Tables["Buildstation"].Rows[c]["测站"].ToString().Trim();
                DBClass.Manipulation("Delete from CreatePoint");
                DBClass.Manipulation("Insert into CreatePoint (点名,编码,N,E,Z) select 测站,编码,N,E,Z from Buildstation where 测站='" + s + "'");
                ESC_Click(sender, e);
            }
            else
            {
                MessageBox.Show("请选择数据！", "提示");
            }
        }



        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang04_StraightLine1 StraightLine1 = new Window_FangYang04_StraightLine1();
            StraightLine1.Show();
            this.Close();//关闭当前窗口
        }
        private void first_Click(object sender, RoutedEventArgs e)
        {
            LV.SelectedIndex = 0;
        }

        private void last_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select 测站,类型,编码,N,E,Z from Buildstation";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Buildstation");
            int c = ds.Tables["Buildstation"].Rows.Count;
            LV.SelectedIndex = c - 1;
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

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

using System.Data.OleDb;
using System.Data;

namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang01.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang01 : Window
    {
        int Num = 0;
        private jiaodu j1 = new jiaodu();
        Point StationPoint = new Point(100.968, 100.324);
        Point CurrentPoint = new Point();
        
        public Window_FangYang01()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();

            j1.v1 ="pt8";
            Com_Point.DataContext = j1 ;
            DianMing.DataContext = j1;


            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
             OleDbCommand cmd1 = conn.CreateCommand();
             cmd1.CommandText = "select MirrorHigh from FangYang_Point where PointName='" + j1.v1 + "'";

            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                j1.v2 = reader["MirrorHigh"].ToString().Trim();               
            }
            JingGao.DataContext = j1 ;
            //MessageBox.Show(j1.v2);
            reader.Close();  
            conn.Close();
            
           
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang window_FangYang = new Window_FangYang();
            window_FangYang.Show();
            this.Close();//关闭当前窗口
        }

        private void PreviousPoint_Click(object sender, RoutedEventArgs e)
        {
            
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select FY_Point_ID  from FangYang_Point where PointName='" + Com_Point.Text.Trim() + "'";
            OleDbDataReader reader = cmd1.ExecuteReader(); 
            if (reader.Read())
            {
                int i;
                 i= (int)reader ["FY_Point_ID"];

                if (i > 1)
                    i = i-1;
                //string s = i.ToString();
                //MessageBox.Show(s);
                else
                    MessageBox.Show("已经是第一个点");
           
            OleDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "select PointName from FangYang_Point where FY_Point_ID ="+ i +"";
            OleDbDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                Com_Point.Text = reader2["PointName"].ToString().Trim();
                DianMing.Text = reader2["PointName"].ToString().Trim();
                //MessageBox.Show(Com_Point.Text);
            }

            reader2.Close();  

            OleDbCommand cmd3 = conn.CreateCommand();
            cmd3.CommandText = "select  MirrorHigh from FangYang_Point where FY_Point_ID = " + i + "";
            OleDbDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.Read())
            {
                JingGao.Text = reader3["MirrorHigh"].ToString().Trim();
                //MessageBox.Show(JingGao.Text);
            }

            reader3.Close();
            }
            reader.Close(); 
            conn.Close();
        }

        private void NextPoint_Click(object sender, RoutedEventArgs e)
        {
            
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select FY_Point_ID  from FangYang_Point where PointName='" + Com_Point.Text.Trim() + "'";
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                int i;
                 i = (int)reader["FY_Point_ID"];
                if (i< 18)
                    i = i + 1;
                else
                    MessageBox.Show("已经是最后一个点");
                //string s = i.ToString();
                //MessageBox.Show(s);
            
            OleDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "select PointName from FangYang_Point where FY_Point_ID =" + i + "";
            OleDbDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                Com_Point.Text = reader2["PointName"].ToString().Trim();
                DianMing.Text = reader2["PointName"].ToString().Trim();
                //MessageBox.Show(Com_Point.Text);
            }

            reader2.Close();

            OleDbCommand cmd3 = conn.CreateCommand();
            cmd3.CommandText = "select MirrorHigh from FangYang_Point where FY_Point_ID =" + i + "";
            OleDbDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.Read())
            {
                JingGao.Text = reader3["MirrorHigh"].ToString().Trim();
                //MessageBox.Show(JingGao.Text);
            }
            

            reader3.Close();

            }
            reader.Close();
            conn.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            string sql = "select * from FangYang_Point";
            cmd1.CommandText = sql;
            sql = "insert into FangYang_Point (PointName,MirrorHigh) values ('"
                        + Com_Point.Text.Trim() + "','" + JingGao.Text.Trim() + "')";
            //MessageBox.Show(sql);
            cmd1.CommandText = sql;
            cmd1.ExecuteNonQuery();                  
            conn.Close();
            MessageBox.Show("存储成功！");


            double Hhudu, Vhudu, Dis;
            double denrtaX, denrtaY;
            Hhudu = ToolCase.HA;
            Vhudu = ToolCase.VA;
            Dis = ToolCase.Distance;
            denrtaX = (Dis * Math.Cos(Vhudu)) * Math.Cos(Hhudu);
            denrtaY = (Dis * Math.Cos(Vhudu)) * Math.Sin(Hhudu);
            CurrentPoint.X = StationPoint.X + denrtaX;
            CurrentPoint.Y = StationPoint.Y + denrtaY;

            Line line1 = new Line();
            Line line2 = new Line();
            double draw_x, draw_y;
            draw_x = 150.0 / 200 * (CurrentPoint.X - StationPoint.X) + 150;
            draw_y = 75 - 75.0 / 200 * (CurrentPoint.Y - StationPoint.Y);
            line1.X1 = draw_x - 3;
            line1.Y1 = draw_y;
            line1.X2 = draw_x + 3;
            line1.Y2 = draw_y;
            line2.X1 = draw_x;
            line2.Y1 = draw_y - 3;
            line2.X2 = draw_x;
            line2.Y2 = draw_y + 3;
            line1.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            line2.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            CanvasDraw.Children.Add(line1);
            CanvasDraw.Children.Add(line2);

        }

        private void Measure_Click(object sender, RoutedEventArgs e)
        {
            Num = Num + 1;
            double Hhudu, Vhudu, Dis, Dis1, Dis2, Dis3, Dis4;

            Hhudu = ToolCase.HA;
            Vhudu = ToolCase.VA;
            Dis = ToolCase.Distance;
            Dis1 = ToolCase.DistanceN1(Num);
            Dis2 = ToolCase.DistanceN2(Num);
            Dis3 = ToolCase.DistanceN3(Num);
            Dis4 = ToolCase.DistanceN4(Num);
            Point_HA.Content = ToolCase.huduTojiaodu(Hhudu);
            Point_TurnLeft.Content = ToolCase.huduTojiaodu(Vhudu);
            Point_MoveFar.Content = Dis.ToString("f03");
            Point_Right.Content = Dis1.ToString("f03");
            Point_TianFang.Content = Dis2.ToString("f03");
            Point_HD.Content = Dis3.ToString("f03");
            Point_Z.Content = Dis4.ToString("f03");

            Point_HA1.Content = ToolCase.huduTojiaodu(Hhudu);
            Point_VA1.Content = ToolCase.huduTojiaodu(Vhudu);
            Point_SD1.Content = Dis.ToString("f03");
            Point_VD1.Content = Dis1.ToString("f03");
            Point_HD1.Content = Dis3.ToString("f03");
            Point_N1.Content = (24279847.0-Dis2).ToString("f03");
            Point_E1.Content = (31848.621-Dis4).ToString("f03");
            Point_Z1.Content = (378.251-Dis1).ToString("f03");
            //Window_FangYang01 window_FangYang01 = new Window_FangYang01();
           // window_FangYang01.Show();
           // window_FangYang01.TabControl1.SelectedIndex = 1;
           // this.Close();//关闭当前窗口
        }




        private void SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select FY_Point_ID  from FangYang_Point where PointName='" + Com_Point.Text.Trim() + "'";
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                int i;
                i = (int)reader["FY_Point_ID"];

                OleDbCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = "select PointName from FangYang_Point where FY_Point_ID =" + i + "";
                OleDbDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    Com_Point.Text = reader2["PointName"].ToString().Trim();
                    DianMing.Text = reader2["PointName"].ToString().Trim();
                    //MessageBox.Show(Com_Point.Text);
                }

                reader2.Close();

                OleDbCommand cmd3 = conn.CreateCommand();
                cmd3.CommandText = "select MirrorHigh from FangYang_Point where FY_Point_ID =" + i + "";
                OleDbDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    JingGao.Text = reader3["MirrorHigh"].ToString().Trim();
                    //MessageBox.Show(JingGao.Text);
                }
                reader3.Close();

            }
            reader.Close();
            conn.Close();
        }

        private void diaoyong1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_diaoyong diaoyong = new Window_jianzhan2_YiZhiDian_diaoyong();
            diaoyong.Show();
            this.Close();
        }

        private void xinjian1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_new jianzhan_new = new Window_jianzhan2_YiZhiDian_new();
            jianzhan_new.Show();
            this.Close();
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

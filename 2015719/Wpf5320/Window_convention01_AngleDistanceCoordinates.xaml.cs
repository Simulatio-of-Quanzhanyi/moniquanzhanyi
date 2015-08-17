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
    /// Window_convention01.xaml 的交互逻辑
    /// </summary>
    public partial class Window_convention01 : Window
    {
        private jiaodu j1 = new jiaodu();


        public Window_convention01()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();



            //角度 读取数据库在lable控件显示 
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "select CAM_V ,CAM_HL ,CAM_HR from Convention_AngleMeasure where CAM_ID=1";
            OleDbDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                j1.v1 = reader["CAM_V"].ToString().Trim();
                j1.v2 = reader["CAM_HL"].ToString().Trim();
                j1.v3 = reader["CAM_HR"].ToString().Trim();
            }

            Lab_V.DataContext = j1;
            Lab_HL.DataContext = j1;
            Lab_HL_Copy.DataContext = j1;
            Lab_V_Copy.Content = 83.1158 + "%";
            reader.Close();
            conn.Close();

            /*
            //V 与HL 产生随机数
            Random rand1 = new Random(1);
            int rndInt1 = rand1.Next(0, 179);
            Random rand2 = new Random(2);
            int rndInt2 = rand2.Next(0, 59);
            Random rand3 = new Random(3);
            int rndInt3 = rand3.Next(0, 59);
            Random rand4 = new Random(4);
            int rndInt4 = rand4.Next(0, 179);
            Random rand5 = new Random(5);
            int rndInt5 = rand5.Next(0, 59);
            Random rand6 = new Random(6);
            int rndInt6 = rand6.Next(0, 59);

            //Lab_V.Content = rndInt1.ToString() + "°" + rndInt2.ToString() + "′" + rndInt3.ToString() + "″";
            // Lab_HL.Content = rndInt4.ToString() + "°" + rndInt5.ToString() + "′" + rndInt6.ToString() + "″";

            double V1 = (double)(rndInt1 + rndInt2 / 60 + rndInt3 / 360) / 180 * 3.14;
            float V2 = (float)Math.Tan(V1);
            i = Math.Tan(V1);
            Lab_V_Copy.Content = V2 * 100 + "%";
            // MessageBox.Show(V1.ToString ());
            //Lab_HL_Copy.Content = (359 - rndInt4).ToString() + "°" + (59 - rndInt5).ToString() + "′" + (60 - rndInt6).ToString() + "″";
            */


            // 距离 读取数据库在lable控件显示
                        
            conn.Open();
            OleDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "select CDM_V ,CDM_HL,CDM_SD,CDM_HD,CDM_VD from Convention_DistanceMeasure where CDM_ID=2";
            OleDbDataReader rd = cmd2.ExecuteReader();
            if (rd.Read())
            {
                Lab_D_V.Content = rd["CDM_V"].ToString().Trim();
                Lab_D_HL.Content =rd["CDM_HL"].ToString().Trim();
                //Lab_SD.Content = rd["CDM_SD"].ToString().Trim();
                // Lab_HD.Content = rd["CDM_HD"].ToString().Trim();
                //Lab_VD.Content = rd["CDM_VD"].ToString().Trim();
            }
            rd.Close();
            conn.Close();

            //坐标    读取数据库在lable控件显示          
            conn.Open();
            OleDbCommand cmd3 = conn.CreateCommand();
            cmd3.CommandText = "select CCM_V ,CCM_HL from Convention_CoordinatesMeasure where CCM_ID=1";
            OleDbDataReader read = cmd3.ExecuteReader();
            if (read.Read())
            {
                Lab_C_V.Content = read["CCM_V"].ToString().Trim();
                Lab_C_HL.Content = read["CCM_HL"].ToString().Trim();
            }
            read.Close();
            conn.Close();

            conn.Open();
            OleDbCommand cmd4 = conn.CreateCommand();
            cmd4.CommandText = "select CMR_N,CMR_E,CMR_Z from Convention_MeasureResult where CMR_ID=1";
            OleDbDataReader readerr = cmd4.ExecuteReader();
            if (readerr.Read())
            {
                Lab_N.Content = readerr["CMR_N"].ToString().Trim();
                Lab_E.Content = readerr["CMR_E"].ToString().Trim();
                Lab_Z.Content = readerr["CMR_Z"].ToString().Trim();
            }
            readerr.Close();
            conn.Close();
          
        }



        private void OpenZhiPan(object sender, RoutedEventArgs e)
        {
            Window_convention02zhipan window_convention02zhipan = new Window_convention02zhipan();
            window_convention02zhipan.Show();
            this.Close();//关闭当前窗口

            

        }
        private void OpenFangYang(object sender, RoutedEventArgs e)
        {
            Window_convention03jlfangyang window_convention03jlfangyang = new Window_convention03jlfangyang();
            window_convention03jlfangyang.Show();
            this.Close();//关闭当前窗口
        }
        private void OpenJingGao(object sender, RoutedEventArgs e)
        {
            Window_convention04jinggao window_convention04jinggao = new Window_convention04jinggao();
            window_convention04jinggao.Show();
            this.Close();//关闭当前窗口
        }
        private void OpenYiGao(object sender, RoutedEventArgs e)
        {
            Window_convention05sryigao window_convention05sryigao = new Window_convention05sryigao();
            window_convention05sryigao.Show();
            this.Close();//关闭当前窗口
        }
        private void OpenCeZhan(object sender, RoutedEventArgs e)
        {
            Window_convention06srcezhan window_convention06srcezhan = new Window_convention06srcezhan();
            window_convention06srcezhan.Show();
            this.Close();//关闭当前窗口
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_convention window_convention = new Window_convention();
            window_convention.Show();
            this.Close();//关闭当前窗口
        }

        private void ZhiLing_Click(object sender, RoutedEventArgs e)//置零
        {
            Window_convention02_InputAngle_ZhiLing InputAngle_ZhiLing = new Window_convention02_InputAngle_ZhiLing();
            InputAngle_ZhiLing.Show();
            this.Close();//关闭当前窗口
        }


        private void jlModel_click(object sender, RoutedEventArgs e)
        {
            Window_convention03_ModleSetting window_convention03_ModleSetting = new Window_convention03_ModleSetting();
            window_convention03_ModleSetting.Show();
            window_convention03_ModleSetting.TabControl1.SelectedIndex = 1;
            this.Close();//关闭当前窗口
        }

        private void zbModel_Click(object sender, RoutedEventArgs e)
        {
            Window_convention03_zbModleSetting window_convention03_zbModleSetting = new Window_convention03_zbModleSetting();
            window_convention03_zbModleSetting.Show();
            window_convention03_zbModleSetting.TabControl1.SelectedIndex = 1;
            this.Close();//关闭当前窗口
        }

        private void RL(object sender, RoutedEventArgs e)//切换水平左右角
        {
            HL1.Visibility = (Visibility)1;
            Lab_HL.Visibility = (Visibility)1;
            ZhuanHuanRL1.Visibility = (Visibility)1;

            HL1_Copy.Visibility = 0;
            Lab_HL_Copy.Visibility = 0;
            ZhuanHuanRL1_Copy.Visibility = 0;

        }

        private void RL_Copy(object sender, RoutedEventArgs e)
        {
            HL1.Visibility = 0;
            Lab_HL.Visibility = 0;
            ZhuanHuanRL1.Visibility = 0;

            HL1_Copy.Visibility = (Visibility)1;
            Lab_HL_Copy.Visibility = (Visibility)1;
            ZhuanHuanRL1_Copy.Visibility = (Visibility)1;
        }

        private void jlMeasure_click(object sender, RoutedEventArgs e)
        {
           
            //原来的
           /* Random rand1 = new Random(1);
            int rndInt1 = rand1.Next(0, 179);
            Random rand2 = new Random(2);
            int rndInt2 = rand2.Next(0, 59);
            Random rand3 = new Random(3);
            int rndInt3 = rand3.Next(0, 59);

            Random rand7 = new Random(7);
            int rndInt7 = rand7.Next(0, 99);
            Random rand8 = new Random(8);
            int rndInt8 = rand8.Next(0, 99);
            Lab_SD.Content = rndInt7.ToString() + "." + rndInt8.ToString() ;

            double V3 = (double)(rndInt7 + rndInt8 /100);
            double V4 = V3 * i;
            double V5 = Math .Sqrt (V3 *V3 +V4*V4) /10;
            //double V6 = jg1-V4-yg1;
            double V6 = (jg1 - V4 - yg1)/10 ;
            jg1 = jg1 + rndInt7/100;
             //MessageBox.Show(V1.ToString ());
            Lab_HD.Content = V5.ToString() ;
            Lab_VD.Content = V6.ToString();
            */

            double Hhudu, Vhudu, Dis;
            Hhudu = ToolCase.HA;
            Vhudu = ToolCase.VA;
            Dis = ToolCase.Distance;
            Lab_D_V.Content = ToolCase.huduTojiaodu1(Hhudu);
            Lab_D_HL.Content = ToolCase.huduTojiaodu1(Vhudu);
            Lab_HD.Content = (Dis * Math.Cos(Vhudu)).ToString("f03");
            Lab_VD.Content = (Dis * Math.Sin(Vhudu)).ToString("f03");
            Lab_SD.Content = Dis.ToString("f03");
            




        }

        private void QieHuanV_Click(object sender, RoutedEventArgs e)
        {
         
            Lab_V.Visibility = (Visibility)1;
            QieHuanV.Visibility = (Visibility)1;
            Lab_V_Copy.Visibility = 0;
            QieHuanV_Copy.Visibility = 0;

        }

        private void QieHuanV_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            Lab_V.Visibility = 0;
            QieHuanV.Visibility = 0;           
            Lab_V_Copy.Visibility = (Visibility)1;
            QieHuanV_Copy.Visibility = (Visibility)1;
        }

        private void Keep_Click(object sender, RoutedEventArgs e)
        {
            Window_convention02_InputAngle_Keep window_convention02_InputAngle_Keep= new Window_convention02_InputAngle_Keep();
            window_convention02_InputAngle_Keep.Show();
            this.Close();//关闭当前窗口
        }

        private void zbMeasure_Click(object sender, RoutedEventArgs e)
        {
            double NN, EE, ZZ;
            string odbcConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            OleDbConnection conn = new OleDbConnection(odbcConnString);
            conn.Open();
            OleDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "select CCM_N , CCM_E , CCM_Z   from Convention_CoordinatesMeasure where CCM_ID=19";
            OleDbDataReader rd = cmd2.ExecuteReader();
            if (rd.Read())
            {
                NN = Convert.ToDouble(rd["CCM_N"]);
                EE = Convert.ToDouble(rd["CCM_E"]);
                ZZ = Convert.ToDouble(rd["CCM_Z"]);
                /////

                 double Hhudu, Vhudu, Dis;
                 Hhudu = ToolCase.HA;
                 Vhudu = ToolCase.VA;
                 Dis = ToolCase.Distance;
                 Lab_C_V.Content = ToolCase.huduTojiaodu1(Hhudu);
                 Lab_C_HL.Content = ToolCase.huduTojiaodu1(Vhudu);
                 Lab_N.Content = (NN + (Dis * Math.Sin(Hhudu))).ToString("f03");
                 Lab_E.Content = (EE + (Dis * Math.Cos(Hhudu))).ToString("f03");
                 Lab_Z.Content = (ZZ + (Dis * Math.Tan(Vhudu))).ToString("f03");
            }
            rd.Close();
            conn.Close();
           

        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key window_Shortcut_key = new Window_Shortcut_key();
            window_Shortcut_key.Show();
            this.Close();//关闭当前窗口
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {

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

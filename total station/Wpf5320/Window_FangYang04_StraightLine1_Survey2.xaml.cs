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
namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang04_StraightLine1_Survey2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang04_StraightLine1_Survey2 : Window
    {
        public Window_FangYang04_StraightLine1_Survey2()
        {
            
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine1 DirectionLine1 = new Window_FangYang03_DirectionLine1();
            DirectionLine1.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            //DB.Manipulation("Insert into CreatePoint (点名,N,E,Z) Values('" + s + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
            DBClass.Manipulation("Update CreatePoint set 点名='" + pointname0.Text.Trim() + "',N='" + N0.Content + "' ,E='" + E0.Content + "' ,Z='" + Z0.Content + "'   ");
            ESC_Click(sender, e);


        }

        private void CeLiang_Click(object sender, RoutedEventArgs e)
        {
            double Dis, Dis1, Dis2;
            Dis = ToolCase.Distance;
            Dis1 = ToolCase.Distance1;
            Dis2 = ToolCase.Distance2;
            N0.Content = Dis.ToString("f03");
            E0.Content = Dis1.ToString("f03");
            Z0.Content = Dis2.ToString("f03");
        }

        private void Complicate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveComplicate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("已保存");
            ENT_Click(sender, e);
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
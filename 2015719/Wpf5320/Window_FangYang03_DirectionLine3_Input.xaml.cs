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
    /// Window_FangYang03_DirectionLine3_Input.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang03_DirectionLine3_Input : Window
    {
        public Window_FangYang03_DirectionLine3_Input()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_FangYang03_DirectionLine1 DirectionLine1 = new Window_FangYang03_DirectionLine1();
            DirectionLine1.Show();
            this.Close();
        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {
            if (N.Text.Trim() == "" || E.Text.Trim() == "" || Z.Text.Trim() == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                string s = "Pt01";
                //DB.Manipulation("Insert into CreatePoint (点名,N,E,Z) Values('" + s + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                DBClass.Manipulation("Update CreatePoint set 点名='" + s + "',N='" + N.Text.Trim() + "' ,E='" + E.Text.Trim() + "' ,Z='" + Z.Text.Trim() + "'   ");
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

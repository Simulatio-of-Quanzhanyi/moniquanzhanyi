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
    /// Window_FangYang01_Point_NEW.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang01_Point_NEW : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_FangYang01_Point_NEW()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {

            Window_FangYang01_Point FangYang01_Point = new Window_FangYang01_Point();
            FangYang01_Point.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (Pointname.Text.Trim() == "" || N.Text.Trim() == "" || E.Text.Trim() == "" || Z.Text.Trim() == "")
            {
                MessageBox.Show("请输入点信息！", "提示");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select * from Buildstation where 测站='" + Pointname.Text.Trim() + "'";
                bool B = DBClass.Judge(sql);
                if (B)
                {
                    if (MessageBox.Show("已存在该点，是否覆盖？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DBClass.Manipulation("Update Buildstation set 编码='" + Code.Text.Trim() + "',N='" + N.Text.Trim() + "',E='" + E.Text.Trim() + "',Z='" + Z.Text.Trim() + "' where 测站='" + Pointname.Text.Trim() + "'");
                        DBClass.Manipulation("Delete from Createrearview");
                        DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                        ESC_Click(sender, e);
                    }

                }
                else
                {
                    DBClass.Manipulation("Insert into Buildstation(测站,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                    DBClass.Manipulation("Delete from Createrearview");
                    DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                    ESC_Click(sender, e);
                }
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


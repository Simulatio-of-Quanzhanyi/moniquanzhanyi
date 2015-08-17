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
    /// Window_Data2_CoordinateData_1new.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Data2_CoordinateData_1new : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_Data2_CoordinateData_1new()
        {
            InitializeComponent();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Data2_CoordinateData window_Start1 = new Window_Data2_CoordinateData();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
              if (tbItemName.Text.Trim() != "")
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();


                string sql = "select * from Coordinate_data where D_NAME='" + tbItemName.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);                          
                if (cmd.ExecuteScalar() !=null)
                {
                    MessageBox.Show("已经存在的项目名称！", "提示");
                }
                else
                {
                    sql = "insert into Coordinate_data (D_NAME,D_CODE,D_TYPE,N,E,Z) values ('"
                + tbItemName.Text.Trim() + "','" + tbItemCode.Text.Trim() + "','" + "输入" + "','" + tbItemN.Text.Trim() + "','" + tbItemE.Text.Trim() + "','" + tbItemZ.Text.Trim() + "')"; 
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("项目添加成功！");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("项目名称不能为空！", "提示");
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

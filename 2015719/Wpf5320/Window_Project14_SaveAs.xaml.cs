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

using System.Data;
using System.Data.OleDb;

namespace Wpf5320
{
    /// <summary>
    /// Window_Project14.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project14 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_Project14()
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

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                // MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }


        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            //项目名称修改
            if (TbFileName.Text == "")
            {
                MessageBox.Show("文件项目名不能为空！", "提示");
            }
            else
            {
                //更新数据库
                //Window_Project11.CurrentItemName;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select * from ItemInfor where ItemName='" + TbFileName.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("该项目已经存在！", "提示");
                }
                else
                {
                    // sql = "update tbCourseInfo set filedCourseName='" + tbCourseName.Text.Trim() + "' where filedCourseID=" + courseID;
                    sql = "update ItemInfor set ItemName='" + TbFileName.Text.Trim() + "' where ItemID=" + Window_Project11.CurrentItemID;
                    MessageBox.Show(sql);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("项目修改成功！", "提示");
                }
            }

        }

        private void ENT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}

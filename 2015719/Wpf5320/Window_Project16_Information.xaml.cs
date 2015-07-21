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
    /// Window_Project16.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project16 : Window
    {
       
        public Window_Project16()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            //项目名称，点数，编码个数，作者，备注，创建时间
            //读取数据库
            DBClass db = new DBClass();
            db.DbOpen();


            string sql = "select * from ItemInfor where ItemName='" + GlobalVariables.OpenItem + "'";
            DataSet ds = db.ConditionQuery(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ItemName.Content = ds.Tables[0].Rows[0]["ItemName"].ToString().Trim();
                ItemAuthor.Content = ds.Tables[0].Rows[0]["ItemAuthor"].ToString().Trim();
                ItemTime.Content = ds.Tables[0].Rows[0]["ItemDate"].ToString().Trim();
                ItemRemark.Content = ds.Tables[0].Rows[0]["ItemAnnotation"].ToString().Trim();
                ItemPointCount.Content = ds.Tables[0].Rows[0]["PointCount"].ToString().Trim();
                ItemCodeCount.Content = ds.Tables[0].Rows[0]["CodeCount"].ToString().Trim();

            }
            else
            {
                MessageBox.Show("当前不存在打开项目");
            }
            db.DbClose();

        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Project window_Start1 = new Window_Project();
            window_Start1.Show();
            this.Close();//关闭当前窗口
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

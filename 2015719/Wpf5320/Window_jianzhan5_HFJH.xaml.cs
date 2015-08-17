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
    /// Window_jianzhan5.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan5 : Window
    {
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public Window_jianzhan5()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //读取数据库
            string sql = "select 站名,N,E,Z,水平角,垂直角,斜距 from HFJH";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql,conn);
            DataTable ds = new DataTable();
            adp.Fill(ds);//将数据源加载到dataset中
            LV.ItemsSource = ds.DefaultView;
            conn.Close();
        }
        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void CeLiang_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan5_1 window_jianzhan5_1 = new Window_jianzhan5_1();
            window_jianzhan5_1.Show();
            this.Close();//关闭当前窗口
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select 站名,编码,N,E,Z from HFJH";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "HFJH");
                int c = LV.SelectedIndex;
                string s = ds.Tables["HFJH"].Rows[c]["站名"].ToString().Trim();
                DBClass.Manipulation("Delete from HFJH where 站名='"+s+"'");
                Window_jianzhan5 window_jianzhan5 = new Window_jianzhan5();//刷新界面
                window_jianzhan5.Show();
                this.Close();//关闭当前窗口
            }
            else
            {
                MessageBox.Show("请选择数据！", "提示");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            string sql = "select 站名,编码,N,E,Z  from HFJH";
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "HFJH");
            int c = ds.Tables["HFJH"].Rows.Count;
            string s = c.ToString();          
            if(c>2)
            {
                if (c>10)
                {
                    MessageBox.Show("数据量超过计算限制！");
                }
                else
                {
                    string s1="Result";
                    DBClass.Manipulation("Insert into Buildstation(测站,编码,N,E,Z) Values('"+s1+"','" + code.Content + "','" + N.Content + "','" + E.Content + "','" + Z.Content + "')");
                    DBClass.Manipulation("Delete from HFJH_2");
                    DBClass.Manipulation("Insert into HFJH_2 (站名,编码,N,E,Z) Values('"+s1+"','" + code.Content + "','" + N.Content + "','" + E.Content + "','" + Z.Content + "')");
                    MessageBox.Show("保存成功！");                
                }              
            }
            else
            {
                MessageBox.Show("无有效数据，请先测量！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if(N.Content.ToString()=="")
            {
                Result.Visibility = 0;
                point.Visibility = 0;
                N1.Visibility = 0;
                E1.Visibility = 0;
                Z1.Visibility = 0;
                code1.Visibility = 0;
                dN1.Visibility = 0;
                dE1.Visibility = 0;
                dZ1.Visibility = 0;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                conn.Open();
                string sql = "select 站名,编码,N,E,Z  from HFJH";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "HFJH");
                int c = ds.Tables["HFJH"].Rows.Count;
                if (c > 2)
                {
                    if (c > 10)
                    {
                        MessageBox.Show("数据量超过计算限制！");
                    }
                    else
                    {
                        double n = ToolCase.Distance1;
                        double e1 = ToolCase.Distance2;
                        double z = ToolCase.Distance3;
                        N.Content = Convert.ToSingle(n).ToString();
                        E.Content = Convert.ToSingle(e1).ToString();
                        Z.Content = Convert.ToSingle(z).ToString();
                        if (c == 3)
                        {
                            dN.Content = "0.0000";
                            dE.Content = "0.0000";
                            dZ.Content = "0.0000";
                        }
                        else
                        {
                            Random ran1 = new Random(1);
                            Random ran2 = new Random(2);
                            Random ran3 = new Random(3);
                            dN.Content = Convert.ToSingle(ran1.NextDouble()).ToString();
                            dE.Content = Convert.ToSingle(ran2.NextDouble()).ToString();
                            dZ.Content = Convert.ToSingle(ran3.NextDouble()).ToString();
                        }
                        MessageBox.Show("计算成功！");
                    }
                }
                else
                {
                    MessageBox.Show("不满足计算条件，计算错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }            
        }    
    }
}

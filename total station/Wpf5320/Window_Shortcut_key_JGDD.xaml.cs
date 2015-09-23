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

namespace Wpf5320
{
    /// <summary>
    /// Window_Shortcut_key_JGDD.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Shortcut_key_JGDD : Window
    {
        private int i = 0;
        public Window_Shortcut_key_JGDD()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key key = new Window_Shortcut_key();
            key.Show();
            this.Close();
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("主界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            if (i != 0)  //ischecked为false时执行
            {
                //close.Visibility = 0;
                //Visibility = (Visibility)1;
                slide.Visibility = (Visibility)1;
                number.Visibility = (Visibility)1;
                left.Visibility = (Visibility)1;
                right.Visibility = (Visibility)1;
                square.Fill = Brushes.Blue;
                i = 0;
                close.Content = "激光对点关";
                close.IsChecked = false;

            }
            else           //ischecked为true时执行
            {
                // close.Visibility = (Visibility)1;
                // open.Visibility = 0;
                slide.Visibility = 0;
                number.Visibility = 0;
                left.Visibility = 0;
                right.Visibility = 0;
                square.Fill = Brushes.Red;
                close.Content = "激光对点开";
                i++;
            }                      
        }

    
    }
}

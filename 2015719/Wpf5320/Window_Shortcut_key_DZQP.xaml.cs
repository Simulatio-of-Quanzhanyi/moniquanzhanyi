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
    /// Window_Shortcut_key_DZQP.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Shortcut_key_DZQP : Window
    {
        public Window_Shortcut_key_DZQP()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();  
        }

        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key key = new Window_Shortcut_key();
            key.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }
    }
}

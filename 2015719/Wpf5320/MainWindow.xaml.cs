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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf5320
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean IsPower=true;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point a = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && (a.X < 65 || a.X > 380 || a.Y < 76 || a.Y > 318))
            {
                DragMove();
            }
        }

        keyboard key = new keyboard();
        private void keyboard_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            key.keyboard_click(sender, e);
            string type = key.ReturnType;
            string value = key.ReturnValue;
            if (type == "function" && value == "Power")
            {
                //  跳转至播放介绍视频界面
                Window_intro_Video intro = new Window_intro_Video();
                intro.Show();
                this.Close();//关闭当前窗口

                if (IsPower)
                {
                    


                    //Window_Start window_Start1 = new Window_Start();
                    //window_Start1.Show();
                    //this.Close();//关闭当前窗口
                    IsPower = false;
                }
                else
                {
                    myMessageBox my = new myMessageBox();
                    my.show("开机界面退出！");

                }
            }
        }
    }
}

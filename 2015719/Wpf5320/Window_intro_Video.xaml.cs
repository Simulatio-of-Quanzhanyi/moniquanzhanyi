using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Window_intro_Video.xaml 的交互逻辑
    /// </summary>
    public partial class Window_intro_Video : Window
    {
        string exePath = System.Environment.CurrentDirectory;

        public Window_intro_Video()
        {
            InitializeComponent();
        }


        //窗体加载时调用视频，进行播放  
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MediaElementControl();
        }

        private void MediaElementControl()
        {
            this.video.LoadedBehavior = MediaState.Manual;

            this.video.Source = new Uri(exePath + "\\Intro.wmv");

            video.Play();
            btn_Play.Content = "暂 停";
            video.ToolTip = "Click to Pause";
        }

        //视频播放结束事件  
        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            //  播放完毕 跳转至开始菜单界面
            Window_Start start = new Window_Start();
            start.Show();
            this.Close();

        }


        //播放、暂停按钮  
        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (btn_Play.Content.ToString() == "播 放")
            {
                video.Play();
                btn_Play.Content = "暂 停";
                video.ToolTip = "Click to Pause";
            }
            else
            {
                video.Pause();
                btn_Play.Content = "播 放";
                video.ToolTip = "Click to Play";
            }
        }

        //停止播放视频  
        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            this.video.Stop();
            video_MediaEnded(sender, e);
        }

        //快进  
        private void btn_FF_Click(object sender, RoutedEventArgs e)
        {
            video.Position = video.Position + TimeSpan.FromSeconds(10);
        }

        //快退  
        private void btn_RD_Click(object sender, RoutedEventArgs e)
        {
            video.Position = video.Position - TimeSpan.FromSeconds(10);
        }




    }
}

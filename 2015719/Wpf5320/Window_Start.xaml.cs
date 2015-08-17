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
    /// Window_Start.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Start : Window
    {
        public Window_Start()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
        }


        private void OpenCalculate(object sender, RoutedEventArgs e)
        {
            Window_calculate window_calculate = new Window_calculate();
            window_calculate.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenConvention(object sender, RoutedEventArgs e)
        {
            Window_convention window_convention = new Window_convention();
            window_convention.Show();
            this.Close();//关闭当前窗口   
        }

        private void OpenFangYang(object sender, RoutedEventArgs e)
        {
            Window_FangYang window_FangYang = new Window_FangYang();
            window_FangYang.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenProject(object sender, RoutedEventArgs e)
        {
            Window_Project window_Project = new Window_Project();
            window_Project.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenDataManagement(object sender, RoutedEventArgs e)
        {
            Window_Data window_Data = new Window_Data();
            window_Data.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenSetting(object sender, RoutedEventArgs e)
        {
            Window_Setting window_Setting = new Window_Setting();
            window_Setting.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenAdjust(object sender, RoutedEventArgs e)
        {
            Window_adjust window_adjust = new Window_adjust();
            window_adjust.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenBuild(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1 window_jianzhan1 = new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void OpenCollect(object sender, RoutedEventArgs e)
        {
           /* collect window_collect = new collect();
            window_collect.Show();
            this.Close();//关闭当前窗口*/
            collect1_PointSurvey1 window_collect = new collect1_PointSurvey1();
           window_collect.Show();
           this.Close();

        }

        private void OpenRoad(object sender, RoutedEventArgs e)
        {
            Window_Road window_Road = new Window_Road();
            window_Road.Show();
            this.Close();//关闭当前窗口
        }

        private void Informa_Click(object sender, RoutedEventArgs e)
        {

            Window_Project22 window_Project22 = new Window_Project22();
            window_Project22.Show();
            this.Close();//关闭当前窗口
        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            Window_Shortcut_key window_Shortcut_key = new Window_Shortcut_key();
             window_Shortcut_key.Show();
             this.Close();//关闭当前窗口
        }




        private void Poweroff_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }
        private void LayoutRoot_Click(object sender, RoutedEventArgs e)
        {
            Button bt = e.OriginalSource as Button;
            if (bt != null)
            {

                string keyName = bt.Name.ToString();
                switch (keyName)
                {
                    case "Arfakey":

                    case "Softkey":
                        //   MessageBox.Show("显示软件盘");
                        break;
                    case "Starkey":
                        //  MessageBox.Show("快捷键");
                        Shortcuts_Click(sender, e);
                        break;
                    case "Powerkey":
                        #region
                        Poweroff_Click(sender, e);
                        break;
                        #endregion
                    case "Funckey":
                        // MessageBox.Show("Func");
                        break;
                    case "Ctrlkey":
                        break;
                    case "Altkey":
                        break;
                    case "Delkey":
                    #region case "Delkey":

                    #endregion
                    case "Tabkey":
                    #region

                    #endregion
                    case "BSkey":
                    #region case "BSkey":

                    #endregion
                    case "Shiftkey":
                        #region case "Shiftkey":
                        break; ;
                        #endregion
                    case "SPkey":
                    #region

                    #endregion
                    case "ESCkey":
                        #region

                        break;
                        #endregion
                    case "ENTkey":
                        #region case "ENTkey":

                        break;
                        #endregion

                    case "BtDnkey":
                        #region

                        break;
                        #endregion
                    case "BtUpkey":
                        #region case "BtUpkey"

                        break;
                        #endregion
                    case "BtLtkey":
                        #region


                        break;
                        #endregion
                    case "BtRtkey":
                        #region


                        break;
                        #endregion
                    default:
                        #region
                        break;
                        #endregion
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

        private void Battery_Click(object sender, RoutedEventArgs e)
        {
            Window_Setting17_Power Setting17_Power = new Window_Setting17_Power();
            Setting17_Power.Show();
            this.Close();//关闭当前窗口
        }
    }
}

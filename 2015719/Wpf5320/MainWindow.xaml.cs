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

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {

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
                        break;
                    case "Powerkey":
                        #region
                        if (IsPower)
                        {
                            Window_Start window_Start1 = new Window_Start();
                            window_Start1.Show();
                            this.Close();//关闭当前窗口
                            IsPower = false;
                        }
                        else
                        {
                            //if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                            //{
                            //    // MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                            //    Application.Current.Shutdown();
                            //}
                            myMessageBox my = new myMessageBox();
                            my.show("开机界面退出！");

                        }
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
                         break;           ;
                        #endregion
                    case "SPkey":
                        #region

                        #endregion
                    case "ESCkey":
                        #region
                        ESCkey_Click(sender, e);
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

    }
}

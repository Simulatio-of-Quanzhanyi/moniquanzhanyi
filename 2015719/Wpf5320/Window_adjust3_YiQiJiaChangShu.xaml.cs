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
    /// adjust3.xaml 的交互逻辑
    /// </summary>
    public partial class adjust3 : Window
    {

        private int selectPos;
        private bool isnumber = true;//是否数字
        private bool isupper = true;//是否大写
        private int keyNumber = 0;//字母顺序
        private string lastkey = null;
        private bool istbwulengjingchangshuFocused = false;
        private bool istbTByoulengjingchangshuFocused = false;
        private bool istimeout = false;
        private System.Windows.Threading.DispatcherTimer timer;
        private int txtfocus = 0;

        public adjust3()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = false;
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
                        #region case "Arfakey":
                        if (isupper)
                        {
                            isupper = false;
                            myMessageBox my = new myMessageBox();
                            my.show("小写字母");
                            //MessageBox.Show("小写字母");
                        }
                        else
                        {
                            isupper = true;
                            myMessageBox my = new myMessageBox();
                            my.show("大写字母");
                            //MessageBox.Show("大写字母");
                        }
                        break;
                        #endregion
                    case "Softkey":
                        //   MessageBox.Show("显示软件盘");
                        break;
                    case "Starkey":
                        //  MessageBox.Show("快捷键");
                        break;
                    case "Powerkey":
                        #region
                         Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
                         Shutdown_PowerOff.Show();
                         this.Close();//关闭当前窗口 
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
                        if (istbwulengjingchangshuFocused) tbstringfun(TBwulengjingchangshu, 3, "*");
                        if (istbTByoulengjingchangshuFocused) tbstringfun(TByoulengjingchangshu, 3, "*");                        
                        break;
                        #endregion
                    case "Tabkey":
                        #region
 /*                       switch (txtfocus)
                        {
                            case 0:
                                txtfocus = txtfocus + 1;
                                TByoulengjingchangshu.Focus();

                                break;
                            case 1:
                                txtfocus = txtfocus + 1;
                                istbTByoulengjingchangshuFocused.Focus();

                                break;
                            default:
                                txtfocus = 0;
                                tbItemName.Focus();
                                break;
                        }*/
                        break;
                        #endregion
                    case "BSkey":
                        #region case "BSkey":
                        if (istbwulengjingchangshuFocused) tbstringfun(TBwulengjingchangshu, 2, "*");
                        if (istbTByoulengjingchangshuFocused) tbstringfun(TByoulengjingchangshu, 2, "*");
                      
                        break;
                        #endregion
                    case "Shiftkey":
                        #region case "Shiftkey":
                        if (isnumber)
                        {

                            isnumber = false;

                            //                      MessageBox.Show("字母键盘");
                            Bt0key.Content = "#$%";
                            Btptkey.Content = "!&@";
                            Bt_key.Content = "+*/";
                            Bt1key.Content = "STU";
                            Bt2key.Content = "VWX";
                            Bt3key.Content = "YZ";
                            Bt4key.Content = "JKL";
                            Bt5key.Content = "MNO";
                            Bt6key.Content = "PQR";
                            Bt7key.Content = "ABC";
                            Bt8key.Content = "DEF";
                            Bt9key.Content = "GHI";
                        }
                        else
                        {
                            isnumber = true;
                            timer.IsEnabled = false;
                            //                           MessageBox.Show("数字键盘");
                            Bt0key.Content = "0";
                            Btptkey.Content = ".";
                            Bt_key.Content = "-";
                            Bt1key.Content = "1";
                            Bt2key.Content = "2";
                            Bt3key.Content = "3";
                            Bt4key.Content = "4";
                            Bt5key.Content = "5";
                            Bt6key.Content = "6";
                            Bt7key.Content = "7";
                            Bt8key.Content = "8";
                            Bt9key.Content = "9";
                        }
                        if (istbwulengjingchangshuFocused) TBwulengjingchangshu.Focus();
                        if (istbTByoulengjingchangshuFocused) TByoulengjingchangshu.Focus();
                        break;
                        #endregion
                    case "SPkey":
                        #region
                        if (istbwulengjingchangshuFocused) tbstringfun(TBwulengjingchangshu, 0, bt.Content.ToString());
                        if (istbTByoulengjingchangshuFocused) tbstringfun(TByoulengjingchangshu, 0, bt.Content.ToString());
 
                        break;
                        #endregion
                    case "ESCkey":
                        #region
                        ESC_Click(sender, e);
                        break;
                        #endregion
                    case "ENTkey":
                        #region case "ENTkey":

                        break;
                        #endregion

                    case "BtDnkey":
                        #region
                        switch (txtfocus)
                        {
                            case 0:
                                txtfocus = txtfocus + 1;
                                TByoulengjingchangshu.Focus();
                                break;
;
                            default:
                                txtfocus = 0;
                                TBwulengjingchangshu.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtUpkey":
                        #region case "BtUpkey"
                        switch (txtfocus)
                        {
                            case 1:
                                txtfocus = txtfocus - 1;
                                TBwulengjingchangshu.Focus();
                                break;
                            default:
                                txtfocus = 1;
                                TByoulengjingchangshu.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtLtkey":
                        #region
                        if (istbwulengjingchangshuFocused)
                        {
                            selectPos = this.TBwulengjingchangshu.SelectionStart;
                            TBwulengjingchangshu.Focus();
                            if (selectPos >= 1)
                            {

                                TBwulengjingchangshu.Select(selectPos - 1, 0);
                            }
                        }
                        if (istbTByoulengjingchangshuFocused)
                        {
                            selectPos = this.TByoulengjingchangshu.SelectionStart;
                            TByoulengjingchangshu.Focus();
                            if (selectPos >= 1)
                            {
                                TByoulengjingchangshu.Select(selectPos - 1, 0);
                            }
                        }
                        break;
                        #endregion
                    case "BtRtkey":
                        #region
                        istimeout = true;
                        lastkey = null;
                        if (istbTByoulengjingchangshuFocused) 
                        {
                            selectPos = this.TByoulengjingchangshu.SelectionStart;
                            TByoulengjingchangshu.Focus();
                            if (selectPos < this.TByoulengjingchangshu.Text.Length)
                            {
                                TByoulengjingchangshu.Select(selectPos + 1, 0);
                            }
                        }
                        if (istbwulengjingchangshuFocused)
                        {
                            selectPos = this.TBwulengjingchangshu.SelectionStart;
                            TBwulengjingchangshu.Focus();
                            if (selectPos < TBwulengjingchangshu.Text.Length)
                            {
                                TBwulengjingchangshu.Select(selectPos + 1, 0);
                            }
                        }
                        break;
                        #endregion
                    default:
                        #region default:
                        if (isnumber)
                        {
                            if (istbwulengjingchangshuFocused) tbstringfun(TBwulengjingchangshu, 0, bt.Content.ToString());
                            if (istbTByoulengjingchangshuFocused) tbstringfun(TByoulengjingchangshu, 0, bt.Content.ToString());                          
                        }
                        else
                        {

                            string press = bt.Name.ToString();
                            timer.Stop();
                            timer.Start();
                            if (press != lastkey)
                            {
                                lastkey = press;
                                istimeout = true;
                                keyNumber = 1;
                            }
                            else
                            {
                                keyNumber++;
                            }
                            if (istbwulengjingchangshuFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBwulengjingchangshu, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBwulengjingchangshu, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBwulengjingchangshu, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBwulengjingchangshu, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBwulengjingchangshu, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBwulengjingchangshu, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            }
#region
                            if (istbTByoulengjingchangshuFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(TByoulengjingchangshu, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TByoulengjingchangshu, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(TByoulengjingchangshu, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TByoulengjingchangshu, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(TByoulengjingchangshu, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TByoulengjingchangshu, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                 }
#endregion
                               }                           
                            }
                            istimeout = false;
                            break;
                        }
                        #endregion
                }
        }

        private void TBwulengjingchangshu_GotFocus(object sender, RoutedEventArgs e)
        {
            istbwulengjingchangshuFocused = true;
            istbTByoulengjingchangshuFocused = false;
            txtfocus = 0;

        }
        private void TByoulengjingchangshu_GotFocus(object sender, RoutedEventArgs e)
        {
            istbwulengjingchangshuFocused = false;
            istbTByoulengjingchangshuFocused = true;
            txtfocus = 1;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            istimeout = true;
        }
        //文本字符串处理
        private void tbstringfun(TextBox TB, int math, string ct)
        {
            switch (math)
            {      //插入处理
                case 0:
                    selectPos = TB.SelectionStart;
                    TB.Text = TB.Text.Substring(0, selectPos) + ct + TB.Text.Substring(selectPos);
                    selectPos += 1;
                    TB.Focus();
                    TB.Select(selectPos, 0);
                    break;
                //替换处理
                case 1:
                    selectPos = TB.SelectionStart;
                    TB.Text = TB.Text.Substring(0, selectPos - 1) + ct +TB.Text.Substring(selectPos);
                    TB.Focus();
                    TB.Select(selectPos, 0);
                    break;
                //删除一个字符
                case 2:
                    if (!string.IsNullOrEmpty(TB.Text))
                    {
                        selectPos = TB.SelectionStart;
                        if (selectPos != 0)
                        {
                            TB.Text = TB.Text.Substring(0, selectPos - 1) + TB.Text.Substring(selectPos);

                            selectPos -= 1;
                            TB.Focus();
                            TB.Select(selectPos, 0);
                        }
                    }
                    break;
                //清除文本
                case 3:
                    TB.Clear();
                    break;
            }
        }



        private void softkeyboard_Click(object sender, RoutedEventArgs e)
        {
            if (wpfkey1.Visibility == Visibility.Collapsed)
            {
                wpfkey1.Visibility = Visibility.Visible;
            }
            else
            {
                wpfkey1.Visibility = Visibility.Collapsed;
            }
        }




        private void ESC_Click(object sender, RoutedEventArgs e)
        {

            Window_adjust window_adjust = new Window_adjust();
            window_adjust.Show();
            this.Close();//关闭当前窗口
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

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}

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

namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang01_Point_New1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang01_Point_New1 : Window
    {
        private int selectPos;
        private bool isnumber = true;//是否数字
        private bool isupper = true;//是否大写
        private int keyNumber = 0;//字母顺序
        private string lastkey = null;

        private bool IsPointnameFocused = false;
        private bool IsCodeFocused = false;
        private bool IsNFocused = false;
        private bool IsEFocused = false;
        private bool IsZFocused = false;
        private bool istimeout = false;
        private System.Windows.Threading.DispatcherTimer timer;
        private int txtfocus = 0;
        
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";

        public Window_FangYang01_Point_New1()
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
                            MessageBox.Show("小写字母");
                        }
                        else
                        {
                            isupper = true;
                            MessageBox.Show("大写字母");
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
                        if (IsPointnameFocused) tbstringfun(Pointname, 3, "*");
                        //编码框具有特殊性
                        if (IsNFocused) tbstringfun(N, 3, "*");
                        if (IsEFocused) tbstringfun(E, 3, "*");
                        if (IsZFocused) tbstringfun(Z, 3, "*");
                        break;
                        #endregion
                    case "Tabkey":
                        #region                        
                        switch (txtfocus)
                          {
                            case 0:
                                txtfocus = txtfocus + 1;
                                Code.Focus();
                                break;
                            case 1:
                                txtfocus = txtfocus + 1;
                                N.Focus();
                                break;
                            case 2:
                                txtfocus = txtfocus + 1;
                                E.Focus();
                                break;
                            case 3:
                                txtfocus = txtfocus + 1;
                                Z.Focus();
                                break;
                            default:
                                txtfocus = 0;
                                Pointname.Focus();
                                break;
                           }
                        break;
                        #endregion
                    case "BSkey":
                        #region case "BSkey":

                        if (IsPointnameFocused) tbstringfun(Pointname, 2, "*");
                        //code特殊
                        if (IsNFocused) tbstringfun(N, 2, "*");
                        if (IsEFocused) tbstringfun(E, 2, "*");
                        if (IsZFocused) tbstringfun(Z, 2, "*");
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
                        if (IsPointnameFocused) Pointname.Focus();
                        if (IsCodeFocused) Code.Focus();
                        if (IsNFocused) Code.Focus();
                        if (IsEFocused) Code.Focus();
                        if (IsZFocused) Code.Focus();
                        break;
                        #endregion
                    case "SPkey":
                        #region                      
                        if (IsPointnameFocused) tbstringfun(Pointname, 0, "*");
                        //code特殊
                        if (IsNFocused) tbstringfun(N, 0, "*");
                        if (IsEFocused) tbstringfun(E, 0, "*");
                        if (IsZFocused) tbstringfun(Z, 0, "*");
                        break;
                        #endregion
                    case "ESCkey":
                        #region
                        ESC_Click(sender, e);
                        break;
                        #endregion
                    case "ENTkey":
                        #region case "ENTkey":
                        Bt_enter_Click(sender, e);
                        break;
                        #endregion

                    case "BtDnkey":
                        #region
                        switch (txtfocus)
                        {
                            case 0:
                                txtfocus = txtfocus + 1;
                                Code.Focus();                              
                                break;
                            case 1:
                                txtfocus = txtfocus + 1;
                                N.Focus();
                                break;
                            case 2:
                                txtfocus = txtfocus + 1;
                                E.Focus();
                                break;
                            case 3:
                                txtfocus = txtfocus + 1;
                                Z.Focus();
                                break;
                               
                            default:
                                txtfocus = 0;
                                Pointname.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtUpkey":
                        #region case "BtUpkey"
                        switch (txtfocus)
                        {
                            case 4:
                                txtfocus = txtfocus - 1;
                                Z.Focus();
                                break;
                            case 3:
                                txtfocus = txtfocus - 1;
                                E.Focus();
                                break;
                            case 2:
                                txtfocus = txtfocus - 1;
                                N.Focus();
                                break;
                            case 1:
                                txtfocus = txtfocus - 1;
                                Code.Focus();
                                break;
                            default:
                                txtfocus = 4;
                                Pointname.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtLtkey":
                        #region
                        if (IsPointnameFocused)
                        {
                            selectPos = this.Pointname.SelectionStart;
                            Pointname.Focus();
                            if (selectPos >= 1)
                            {

                                Pointname.Select(selectPos - 1, 0);
                            }
                        }
                        if (IsNFocused)
                        {
                            selectPos = this.N.SelectionStart;
                            N.Focus();
                            if (selectPos >= 1)
                            {

                                N.Select(selectPos - 1, 0);
                            }
                        }
                        if (IsEFocused)
                        {
                            selectPos = this.N.SelectionStart;
                            E.Focus();
                            if (selectPos >= 1)
                            {

                                E.Select(selectPos - 1, 0);
                            }
                        }
                        if (IsZFocused)
                        {
                            selectPos = this.N.SelectionStart;
                            Z.Focus();
                            if (selectPos >= 1)
                            {

                                Z.Select(selectPos - 1, 0);
                            }
                        }

                        break;
                        #endregion
                    case "BtRtkey":
                        #region
                        istimeout = true;
                        lastkey = null;
                        if (IsPointnameFocused)
                        {
                            selectPos = this.Pointname.SelectionStart;
                            Pointname.Focus();
                            if (selectPos < this.Pointname.Text.Length)
                            {
                                Pointname.Select(selectPos + 1, 0);
                            }
                        }
                        if (IsNFocused)
                        {
                            selectPos = this.N.SelectionStart;
                            N.Focus();
                            if (selectPos < N.Text.Length)
                            {
                                N.Select(selectPos + 1, 0);
                            }
                        }
                        if (IsEFocused)
                        {
                            selectPos = this.E.SelectionStart;
                            E.Focus();
                            if (selectPos < N.Text.Length)
                            {
                                E.Select(selectPos + 1, 0);
                            }
                        }
                        if (IsZFocused)
                        {
                            selectPos = this.Z.SelectionStart;
                            Z.Focus();
                            if (selectPos <Z.Text.Length)
                            {
                                Z.Select(selectPos + 1, 0);
                            }
                        }
                        break;
                        #endregion
                    default:
                        #region default:
                        if (isnumber)
                        {
                            if (IsPointnameFocused) tbstringfun(Pointname, 0, bt.Content.ToString());
                            if (IsNFocused) tbstringfun(N, 0, bt.Content.ToString());
                            if (IsEFocused) tbstringfun(E, 0, bt.Content.ToString());
                            if (IsZFocused) tbstringfun(Z, 0, bt.Content.ToString());
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
                            if (IsPointnameFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(Pointname, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Pointname, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(Pointname, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Pointname, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(Pointname, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Pointname, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            }
                            #region
                            if (IsNFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(N, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(N, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(N, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(N, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(N, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(N, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            #endregion
                            }
                            if (IsEFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(E , 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(E, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(E, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(E, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(E, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(E, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            #endregion
                            }
                            if (IsZFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(Z, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Z, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(Z, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Z, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(Z, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(Z, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }

                            }
                        }
                        istimeout = false;
                        break;
                }

            }
        }











        private void ESC_Click(object sender, RoutedEventArgs e)
        {

            Window_jianzhan2 window_Start1 = new Window_jianzhan2();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            if (Pointname.Text.Trim() == "" || N.Text.Trim() == "" || E.Text.Trim() == "" || Z.Text.Trim() == "")
            {
                MessageBox.Show("请输入点信息！", "提示");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select * from Buildstation where 测站='" + Pointname.Text.Trim() + "'";
                bool B = DBClass.Judge(sql);
                if (B)
                {
                    if (MessageBox.Show("已存在该点，是否覆盖？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DBClass.Manipulation("Update Buildstation set 编码='" + Code.Text.Trim() + "',N='" + N.Text.Trim() + "',E='" + E.Text.Trim() + "',Z='" + Z.Text.Trim() + "' where 测站='" + Pointname.Text.Trim() + "'");
                        DBClass.Manipulation("Delete from Createrearview");
                        DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                        ESC_Click(sender, e);
                    }

                }
                else
                {
                    DBClass.Manipulation("Insert into Buildstation(测站,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                    DBClass.Manipulation("Delete from Createrearview");
                    DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + Pointname.Text.Trim() + "','" + Code.Text.Trim() + "','" + N.Text.Trim() + "','" + E.Text.Trim() + "','" + Z.Text.Trim() + "')");
                    ESC_Click(sender, e);
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

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
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

        private void Pointname_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void N_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void E_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Z_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Code_GotFocus(object sender, RoutedEventArgs e)
        {

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
                    TB.Text = TB.Text.Substring(0, selectPos - 1) + ct + TB.Text.Substring(selectPos);
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

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {
            ESC_Click(sender, e);
        }




    }
}

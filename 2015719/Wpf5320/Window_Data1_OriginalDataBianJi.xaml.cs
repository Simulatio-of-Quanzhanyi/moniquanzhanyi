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
    /// Window_Data1_OriginalDataBianJi.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Data1_OriginalDataBianJi : Window
    {
        private int selectPos;
        private bool isnumber = true;//是否数字
        private bool isupper = true;//是否大写
        private int keyNumber = 0;//字母顺序
        private string lastkey = null;
        private bool IsTBPointNameFocused = false;
        private bool IsTBCodeFocused = false;
        private bool istimeout = false;
        private System.Windows.Threading.DispatcherTimer timer;
        private int txtfocus = 0;
        
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public string ID;
        public Window_Data1_OriginalDataBianJi()
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
                        if (IsTBPointNameFocused) tbstringfun(TBPointName, 3, "*");
                        if (IsTBCodeFocused) tbstringfun(TBCode, 3, "*");
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
                        if (IsTBPointNameFocused) tbstringfun(TBPointName, 2, "*");
                        if (IsTBCodeFocused) tbstringfun(TBCode, 2, "*");

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
                        if (IsTBPointNameFocused) TBPointName.Focus();
                        if (IsTBCodeFocused) TBCode.Focus();
                        break;
                        #endregion
                    case "SPkey":
                        #region
                        if (IsTBPointNameFocused) tbstringfun(TBPointName, 0, bt.Content.ToString());
                        if (IsTBCodeFocused) tbstringfun(TBCode, 0, bt.Content.ToString());

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
                                TBPointName.Focus();
                                break;
                                ;
                            default:
                                txtfocus = 0;
                                TBCode.Focus();
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
                                TBPointName.Focus();
                                break;
                            default:
                                txtfocus = 1;
                                TBCode.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtLtkey":
                        #region
                        if (IsTBPointNameFocused)
                        {
                            selectPos = this.TBPointName.SelectionStart;
                            TBPointName.Focus();
                            if (selectPos >= 1)
                            {

                                TBPointName.Select(selectPos - 1, 0);
                            }
                        }
                        if (IsTBCodeFocused)
                        {
                            selectPos = this.TBCode.SelectionStart;
                            TBCode.Focus();
                            if (selectPos >= 1)
                            {
                                TBCode.Select(selectPos - 1, 0);
                            }
                        }
                        break;
                        #endregion
                    case "BtRtkey":
                        #region
                        istimeout = true;
                        lastkey = null;
                        if (IsTBPointNameFocused)
                        {
                            selectPos = this.TBPointName.SelectionStart;
                            TBPointName.Focus();
                            if (selectPos < this.TBPointName.Text.Length)
                            {
                                TBPointName.Select(selectPos + 1, 0);
                            }
                        }
                        if (IsTBCodeFocused)
                        {
                            selectPos = this.TBCode.SelectionStart;
                            TBCode.Focus();
                            if (selectPos < TBCode.Text.Length)
                            {
                                TBCode.Select(selectPos + 1, 0);
                            }
                        }
                        break;
                        #endregion
                    default:
                        #region default:
                        if (isnumber)
                        {
                            if (IsTBPointNameFocused) tbstringfun(TBPointName, 0, bt.Content.ToString());
                            if (IsTBCodeFocused) tbstringfun(TBCode, 0, bt.Content.ToString());
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
                            if (IsTBPointNameFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBPointName, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBPointName, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBPointName, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBPointName, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBPointName, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBPointName, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            }
                            #region
                            if (IsTBCodeFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBCode, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBCode, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBCode, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBCode, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(TBCode, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(TBCode, 1, bt.Content.ToString().Substring(1, 1));
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





        private void ESC_Click(object sender, RoutedEventArgs e)
        {
            int ID1 = Convert.ToInt32(ID);
            Window_Data1_OriginalData window_Start1 = new Window_Data1_OriginalData();
            window_Start1.Show();
            window_Start1.LV.SelectedIndex = ID1 - 1;
            window_Start1.LV.ScrollIntoView(window_Start1.LV.SelectedItem);
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void Bt_enter_Click(object sender, RoutedEventArgs e)
        {
            //打开数据库
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            conn.Open();
            //定义sql语句操作数据库
            int ID1 = Convert.ToInt32(ID);
            //string sql = "UPDATE Coordinate_data SET D_NAME ='" + D_NAME.Text + "', D_CODE = '" + D_CODE.Text + "', N = '" + N.Text + "', E = '" + E.Text + "', Z = '" + Z.Text + "' Where ID='" + ID1 + "'";
            string sql = "Update Original_data set D_NAME='" + TBPointName.Text.Trim() + "',D_CODE='" + TBCode.Text + "' where ID= " + ID1 + " ";            
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("编辑成功！", "提示");
            Window_Data1_OriginalData window_Start1 = new Window_Data1_OriginalData();
            window_Start1.LV.SelectedIndex = ID1 - 1;
            window_Start1.LV.ScrollIntoView(window_Start1.LV.SelectedItem);
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


        private void TBPointName_GotFocus(object sender, RoutedEventArgs e)
        {
            IsTBPointNameFocused = true;
            IsTBCodeFocused = false;
            txtfocus = 0;
        }

        private void TBCode_GotFocus(object sender, RoutedEventArgs e)
        {
            IsTBPointNameFocused =  false;
            IsTBCodeFocused = true;
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

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

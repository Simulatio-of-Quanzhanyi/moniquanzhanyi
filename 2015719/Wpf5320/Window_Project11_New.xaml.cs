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
    /// Window_Project11.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Project11 : Window
    {
        private int selectPos;
        private bool isnumber = true;//是否数字
        private bool isupper=true;//是否大写
        private int keyNumber = 0;//字母顺序
        private string lastkey = null;
        private bool istbItmeAnnotationFocused=false;
        private bool istbItemAuthorFocused=false;
        private bool istbItemNameFocused=false;
        private bool istimeout = false;
        private System.Windows.Threading.DispatcherTimer timer;
        private int txtfocus = 0;

        public static int CurrentItemID = 1;
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        //    private enum num_english { number, english };



        public Window_Project11()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = false ;
          //  timer.Start();
        }
        private void Bt_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                // MessageBox.Show("开机界面退出！");//在全站仪界面中加载
                Application.Current.Shutdown();
            }
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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
                        if (istbItemNameFocused) tbstringfun(tbItemName, 3, "*");
                        if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 3, "*");
                        if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 3, "*");
                        break;
                        #endregion
                    case "Tabkey":
                        #region
                        switch (txtfocus)
                        {
                            case 0:
                                txtfocus = txtfocus + 1;
                                tbItemAuthor.Focus();

                                break;
                            case 1:
                                txtfocus = txtfocus + 1;
                                tbItmeAnnotation.Focus();

                                break;
                            default:
                                txtfocus = 0;
                                tbItemName.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BSkey":
                        #region case "BSkey":
                        if (istbItemNameFocused ) tbstringfun(tbItemName,2,"*");
                        if (istbItemAuthorFocused) tbstringfun(tbItemAuthor,2, "*");
                        if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 2, "*");
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
                        if (istbItemAuthorFocused) tbItemAuthor.Focus();
                        if (istbItemNameFocused) tbItemName.Focus();
                        if (istbItmeAnnotationFocused) tbItmeAnnotation.Focus();
                        break;
                     #endregion
                    case "SPkey":
                        #region
                        if (istbItemNameFocused) tbstringfun(tbItemName, 0, bt.Content.ToString());
                        if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 0, bt.Content.ToString());
                        if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 0, bt.Content.ToString());
                        break;
                       #endregion
                    case "ESCkey":
                        #region
                        ESCkey_Click(sender, e);
                        break;
                        #endregion
                    case "ENTkey":
                        #region case "ENTkey":
                        if (tbItemName.Text.Trim() != "")
                        {
                            OleDbConnection conn = new OleDbConnection(odbcConnStr);
                            conn.Open();


                            string sql = "select * from ItemInfor where ItemName='" + tbItemName.Text.Trim() + "'";
                            OleDbCommand cmd = new OleDbCommand(sql, conn);
                            if (cmd.ExecuteScalar() != null)
                            {
                                MessageBox.Show("已经存在的项目名称！", "提示");
                            }
                            else
                            {
                                sql = "insert into ItemInfor (ItemName,ItemAuthor,ItemAnnotation,ItemDate) values ('"
                                    + tbItemName.Text.Trim() + "','" + tbItemAuthor.Text.Trim() + "','" + tbItmeAnnotation.Text.Trim() + "','" + DateTime.Now.ToString() + "')";
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                GlobalVariables.OpenItem = tbItemName.Text.Trim();
                                // lb_default.Content = tbItemName.Text.Trim();
                                MessageBox.Show("项目添加成功！");
                                Window_Project Window_Project1 = new Window_Project();
                                Window_Project1.Show();
                                this.Close();

                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("项目名称不能为空！", "提示");
                        }
                        break;
                        #endregion

                    case "BtDnkey":
                        #region
                        switch (txtfocus)
                        {
                            case 0:
                                txtfocus = txtfocus + 1;
                                tbItemAuthor.Focus();

                                break;
                            case 1:
                                txtfocus = txtfocus + 1;
                                tbItmeAnnotation.Focus();

                                break;
                            default:
                                txtfocus = 0;
                                tbItemName.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtUpkey":
                        #region case "BtUpkey"
                        switch (txtfocus)
                        {
                            case 2:
                                txtfocus = txtfocus - 1;
                                tbItemAuthor.Focus();
                                break;
                            case 1:
                                txtfocus = txtfocus -1;
                                tbItemName.Focus();  
                                break;
                            default:
                                txtfocus = 2;
                                tbItmeAnnotation.Focus();
                                break;
                        }
                        break;
                        #endregion
                    case "BtLtkey":
                        #region
                        if (istbItemNameFocused)
                        {
                            selectPos = this.tbItemName.SelectionStart;
                            tbItemName.Focus();
                            if (selectPos >= 1)
                            {
                                tbItemName.Select(selectPos - 1, 0);
                            }
                        }
                        if (istbItemAuthorFocused)
                        {
                            selectPos = this.tbItemAuthor.SelectionStart;
                            tbItemAuthor.Focus();
                            if (selectPos >= 1)
                            {
                                tbItemAuthor.Select(selectPos - 1, 0);
                            }
                        }
                        if (istbItmeAnnotationFocused)
                        {
                            selectPos = this.tbItmeAnnotation.SelectionStart;
                            tbItmeAnnotation.Focus();
                            if (selectPos >= 1)
                            {
                                tbItmeAnnotation.Select(selectPos - 1, 0);
                            }
                        }

                        break;
                        #endregion
                    case "BtRtkey":
                        #region
                        istimeout = true;
                        lastkey = null;
                        if (istbItemNameFocused)
                        {
                            selectPos = this.tbItemName.SelectionStart;                           
                            tbItemName.Focus();
                            if (selectPos < this.tbItemName.Text.Length)
                            {
                                tbItemName.Select(selectPos + 1, 0);
                            }
                        }
                        if (istbItemAuthorFocused)
                        {
                            selectPos = this.tbItemAuthor.SelectionStart;
                            tbItemAuthor.Focus();
                            if (selectPos <tbItemAuthor.Text.Length)
                            {
                                tbItemAuthor.Select(selectPos + 1, 0);
                            }
                        }
                        if (istbItmeAnnotationFocused)
                        {
                            selectPos = this.tbItmeAnnotation.SelectionStart;
                            tbItmeAnnotation.Focus();
                            if (selectPos <this.tbItmeAnnotation.Text.Length)
                            {
                                tbItmeAnnotation.Select(selectPos + 1, 0);
                            }
                        }

                        break;
                        #endregion
                    default:
                        #region default:
                        if (isnumber)
                        {
                            if (istbItemNameFocused) tbstringfun(tbItemName, 0, bt.Content.ToString());
                            if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 0, bt.Content.ToString());
                            if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 0, bt.Content.ToString());

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
                                keyNumber=1;
                            }
                            else
                            {
                                keyNumber++;
                            }
                            if(istbItemNameFocused)
                            {
                              switch (keyNumber % 3)
                              {
                                    case 0:
                                       if (istimeout) 
                                           {
                                              tbstringfun(tbItemName,0, bt.Content.ToString().Substring(2, 1));
                                           }
                                           else
                                           {
                                              tbstringfun(tbItemName, 1, bt.Content.ToString().Substring(2, 1));
                                           }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItemName, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItemName, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                             tbstringfun(tbItemName, 0, bt.Content.ToString().Substring(1, 1));
                                         }
                                         else
                                        {
                                            tbstringfun(tbItemName, 1, bt.Content.ToString().Substring(1, 1));
                                         }
                                         break;
                               }
                            }
                            if(istbItemAuthorFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItemAuthor, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItemAuthor, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItemAuthor, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItemAuthor, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItemAuthor, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItemAuthor, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                            }
                            if(istbItmeAnnotationFocused)
                            {
                                switch (keyNumber % 3)
                                {
                                    case 0:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItmeAnnotation, 0, bt.Content.ToString().Substring(2, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItmeAnnotation, 1, bt.Content.ToString().Substring(2, 1));
                                        }
                                        break;
                                    case 1:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItmeAnnotation, 0, bt.Content.ToString().Substring(0, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItmeAnnotation, 1, bt.Content.ToString().Substring(0, 1));
                                        }
                                        break;
                                    case 2:
                                        if (istimeout)
                                        {
                                            tbstringfun(tbItmeAnnotation, 0, bt.Content.ToString().Substring(1, 1));
                                        }
                                        else
                                        {
                                            tbstringfun(tbItmeAnnotation, 1, bt.Content.ToString().Substring(1, 1));
                                        }
                                        break;
                                }
                             }
                           
                            istimeout = false;


                        }

                        break;
                        #endregion
                }

            }
        }

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {
            Window_Project window_Start1 = new Window_Project();
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void tbItemName_GotFocus(object sender, RoutedEventArgs e)
        {
            istbItemNameFocused = true;
            istbItemAuthorFocused = false;
            istbItmeAnnotationFocused = false;
            txtfocus = 0;

        }

        private void tbItemAuthor_GotFocus(object sender, RoutedEventArgs e)
        {
            istbItemNameFocused = false;
            istbItemAuthorFocused = true;
            istbItmeAnnotationFocused = false;
            txtfocus =1;

        }

        private void tbItmeAnnotation_GotFocus(object sender, RoutedEventArgs e)
        {
            istbItemNameFocused = false;
            istbItemAuthorFocused = false;
            istbItmeAnnotationFocused = true;
            txtfocus =2;

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            istimeout = true;
        }
        //文本字符串处理
        private void tbstringfun(TextBox TB,int math,string ct)
        {
            switch(math)
            {      //插入处理
                case 0:
                    selectPos = TB.SelectionStart;
                    TB.Text = TB.Text.Substring(0, selectPos) +ct+ TB.Text.Substring(selectPos);
                    selectPos += 1;
                    TB.Focus();
                    TB.Select(selectPos, 0);
                    break;
                    //替换处理
                case 1:
                    selectPos = TB.SelectionStart;
                    TB.Text = TB.Text.Substring(0, selectPos - 1) + ct + tbItemName.Text.Substring(selectPos);
                    TB.Focus();
                    TB.Select(selectPos, 0);
                    break;
                    //删除一个字符
                case 2:
                    if (!string.IsNullOrEmpty(tbItemName.Text))
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




    }
}

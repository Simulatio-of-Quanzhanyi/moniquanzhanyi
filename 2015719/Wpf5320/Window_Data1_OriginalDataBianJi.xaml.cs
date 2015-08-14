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
        private bool IsTBPointNameFocused = false;
        private bool IsTBCodeFocused = false;
        private int txtfocus = 0;
        
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        public string ID;

        public Window_Data1_OriginalDataBianJi()
        {
            InitializeComponent();
        }

        private void ESC_Click()
        {
            int ID1 = Convert.ToInt32(ID);
            Window_Data1_OriginalData window_Start1 = new Window_Data1_OriginalData();
            window_Start1.Show();
            window_Start1.LV.SelectedIndex = ID1 - 1;
            window_Start1.LV.ScrollIntoView(window_Start1.LV.SelectedItem);
            window_Start1.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click()
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


        private void focusUnchanged()
        {
            if (IsTBPointNameFocused) TBPointName.Focus();
            else if (IsTBCodeFocused) TBCode.Focus();
        }

        private void toggleSoftKeyboard()
        {
            if (softKey.Visibility == Visibility.Collapsed)
            {
                softKey.Visibility = Visibility.Visible;
            }
            else
            {
                softKey.Visibility = Visibility.Collapsed;
            }
        }

        private void softkeyboard_Click(object sender, RoutedEventArgs e)
        {
            toggleSoftKeyboard();
        }
        private void keyboardInfoProce(string type, string value)
        {
            //  返回值类型为 null，不做任何改变（保持焦点不变） 。 结束调用此次事件处理函数

            if (type == "null")
            {
                focusUnchanged();
                return;
            }

            else if (type == "number" || type == "character" || type == "symbol")
            {
                //  返回值类型为 数字(number) 字母(character) 字符(other)  直接调用插入函数
                if (IsTBPointNameFocused) tbstringfun(TBPointName, 0, value);
                if (IsTBCodeFocused) tbstringfun(TBCode, 0, value);
                return;
            }

            else if (type == "character_replace")
            {
                if (IsTBPointNameFocused) tbstringfun(TBPointName, 1, value);
                if (IsTBCodeFocused) tbstringfun(TBCode, 1, value);
                return;
            }

            //  返回值类型为 功能键(function)
            else if (type == "function")
            {
                switch (value)
                {
                    case "Soft":
                        #region "显示软键盘"
                        toggleSoftKeyboard();
                        //   MessageBox.Show("显示软件盘");
                        break;
                        #endregion

                    case "Starkey":
                        //  MessageBox.Show("快捷键");
                        break;

                    case "Power":
                        #region  "关机界面"
                        Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
                        Shutdown_PowerOff.Show();
                        this.Close();//关闭当前窗口 
                        break;
                        #endregion

                    case "Func":
                        // MessageBox.Show("Func");
                        break;

                    case "Ctrl":
                        break;

                    case "Alt":
                        break;

                    case "Del":
                        #region "删除字符"
                        if (IsTBPointNameFocused) tbstringfun(TBPointName, 3, "*");
                        if (IsTBCodeFocused) tbstringfun(TBCode, 3, "*");
                        break;
                        #endregion

                    case "Tab":
                        #region  "切换焦点"
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

                    case "B.S":
                        #region "删除字符"
                        if (IsTBPointNameFocused) tbstringfun(TBPointName, 2, "*");
                        if (IsTBCodeFocused) tbstringfun(TBCode, 2, "*");
                        break;
                        #endregion


                    case "ESCkey":
                        #region "返回上一界面"
                        ESC_Click();
                        break;
                        #endregion

                    case "ENT":
                        #region "确认"
                        ENT_Click();
                        break;
                        #endregion

                    case "Dn":
                        #region "切换焦点"
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

                    case "Up":
                        #region "切换焦点"
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

                    case "Lt":
                        #region "移动光标"
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

                    case "Rt":
                        #region "移动光标"
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
                        #region
                        focusUnchanged();

                        break;
                        #endregion
                }
            }
            else
            {
                //  返回值为其他键 不做任何改变（焦点保持不变）
                focusUnchanged();
            }
            return;
        }

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {
            ESC_Click();
        }

        private keyboard key = new keyboard();

        private void keyboard_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //  对用户控件 键盘 绑定 PreviewMouseLeftButtonUp 事件

            //  调用键盘的单击函数（模拟对用户控件的单击事件）
            key.keyboard_click(sender, e);

            //  读取从软键盘获得的 返回值类型 信息
            string type = key.ReturnType;

            //  读取从键盘获得的 返回值
            string value = key.ReturnValue;

            keyboardInfoProce(type, value);
        }




    }
}

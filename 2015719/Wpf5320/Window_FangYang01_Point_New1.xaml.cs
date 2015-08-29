﻿using System;
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
using System.Reflection;

namespace Wpf5320
{
    /// <summary>
    /// Window_FangYang01_Point_New1.xaml 的交互逻辑
    /// </summary>
    public partial class Window_FangYang01_Point_New1 : Window
    {
        private int selectPos;
        private bool isTBPointnameFocused = false;
        private bool isTBNFocused = false;
        private bool isTBEFocused = false;
        private bool isTBZFocused = false;
//        private bool isTBCodeFocused = false;
        private int txtfocus = 0;
        public string ID;

        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        
        private TextBox[] TB = new TextBox[4];

        public Window_FangYang01_Point_New1()
        {         
            InitializeComponent();

            initTBArray();
        }

        private void initTBArray()
        {

            TB[0] = TBPointname;
            TB[1] = TBN;
            TB[2] = TBE;
            TB[3] = TBZ;
        }

        private void TBPointname_GotFocus(object sender, RoutedEventArgs e)
        {
            txtfocus = 0;
            isTBPointnameFocused = true; ;
            isTBNFocused = false;
            isTBEFocused = false;
            isTBZFocused = false;
        }

        private void TBN_GotFocus(object sender, RoutedEventArgs e)
        {
            txtfocus = 1;
            isTBPointnameFocused = false; ;
            isTBNFocused = true;
            isTBEFocused = false;
            isTBZFocused = false;
        }

        private void TBE_GotFocus(object sender, RoutedEventArgs e)
        {
            txtfocus = 2;
            isTBPointnameFocused = false; ;
            isTBNFocused = false;
            isTBEFocused = true;
            isTBZFocused = false;
        }

        private void TBZ_GotFocus(object sender, RoutedEventArgs e)
        {
            txtfocus = 3;
            isTBPointnameFocused = false; ;
            isTBNFocused = false;
            isTBEFocused = false;
            isTBZFocused = true;

        }

        private void TBCode_GotFocus(object sender, RoutedEventArgs e)
        {

        }


        private void ENT_Click()
        {
            if (TBPointname.Text.Trim() == "" || TBN.Text.Trim() == "" || TBE.Text.Trim() == "" || TBZ.Text.Trim() == "")
            {
                MessageBox.Show("请输入点信息！", "提示");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select * from Buildstation where 测站='" + TBPointname.Text.Trim() + "'";
                bool B = DBClass.Judge(sql);
                if (B)
                {
                    if (MessageBox.Show("已存在该点，是否覆盖？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DBClass.Manipulation("Update Buildstation set 编码='" + TBCode.Text.Trim() + "',N='" + TBN.Text.Trim() + "',E='" + TBE.Text.Trim() + "',Z='" + TBZ.Text.Trim() + "' where 测站='" + TBPointname.Text.Trim() + "'");
                        DBClass.Manipulation("Delete from Createrearview");
                        DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + TBPointname.Text.Trim() + "','" + TBCode.Text.Trim() + "','" + TBN.Text.Trim() + "','" + TBE.Text.Trim() + "','" + TBZ.Text.Trim() + "')");
                        ESC_Click();
                    }

                }
                else
                {
                    DBClass.Manipulation("Insert into Buildstation(测站,编码,N,E,Z) Values('" + TBPointname.Text.Trim() + "','" + TBCode.Text.Trim() + "','" + TBN.Text.Trim() + "','" + TBE.Text.Trim() + "','" + TBZ.Text.Trim() + "')");
                    DBClass.Manipulation("Delete from Createrearview");
                    DBClass.Manipulation("Insert into Createrearview (点名,编码,N,E,Z) Values('" + TBPointname.Text.Trim() + "','" + TBCode.Text.Trim() + "','" + TBN.Text.Trim() + "','" + TBE.Text.Trim() + "','" + TBZ.Text.Trim() + "')");
                    ESC_Click();
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



        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {
            ESC_Click();
        }

        private void ENTkey_Click(object sender, RoutedEventArgs e)
        {
            ENT_Click();
        }

        //  声明一个 软键盘 对象
        private softKey softkey = new softKey();

        private void softKey_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //  对用户控件 软键盘 绑定 PreviewMouseLeftButtonUp 事件

            //  调用软键盘的单击函数（模拟对用户控件的单击事件）
            softkey.softKey_Click(sender, e);

            //  读取从软键盘获得的 返回值类型 信息
            string type = softkey.ReturnType;

            //  读取从软键盘获得的 返回值
            string value = softkey.ReturnValue;

            keyboardInfoProce(type, value);

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


        private void softkeyboard_Click(object sender, RoutedEventArgs e)
        {
            toggleSoftKeyboard();
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

        private bool getIsTBFocused(string TBName)
        {
            string TBfocusedName = "is" + TBName + "Focused";
            BindingFlags bf = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
            return (bool)this.GetType().GetField(TBfocusedName, bf).GetValue(this);
        }

        private void focusUnchanged()
        {
            for (int i = 0; i < TB.Length; i++)
            {
                if (getIsTBFocused(TB[i].Name))
                {
                    TB[i].Focus();
                }
            }
        }

        public void keyboardInfoProce(string type, string value)
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
                for (int i = 0; i < TB.Length; i++)
                {
                    if (getIsTBFocused(TB[i].Name))
                    {
                        tbstringfun(TB[i], 0, value);
                    }
                }
                return;
            }

            else if (type == "character_replace")
            {
                for (int i = 0; i < TB.Length; i++)
                {
                    if (getIsTBFocused(TB[i].Name))
                    {
                        tbstringfun(TB[i], 1, value);
                    }
                }
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
                        for (int i = 0; i < TB.Length; i++)
                        {
                            if (getIsTBFocused(TB[i].Name))
                            {
                                tbstringfun(TB[i], 3, "*");
                            }
                        }
                        break;
                        #endregion

                    case "Tab":
                        #region  "切换焦点"
                        txtfocus = (txtfocus + 1) % (TB.Length);
                        TB[txtfocus].Focus();
                        break;
                        #endregion

                    case "B.S":
                        #region "删除字符"
                        for (int i = 0; i < TB.Length; i++)
                        {
                            if (getIsTBFocused(TB[i].Name))
                            {
                                tbstringfun(TB[i], 2, "*");
                            }
                        }
                        break;
                        #endregion

                    case "ESC":
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
                        txtfocus = (txtfocus + 1) % (TB.Length);
                        TB[txtfocus].Focus();
                        break;
                        #endregion

                    case "Up":
                        #region "切换焦点"
                        if (txtfocus - 1 < 0)
                        {
                            txtfocus = TB.Length - 1;
                        }
                        else
                        {
                            txtfocus = (txtfocus - 1) % (TB.Length);
                        }

                        TB[txtfocus].Focus();
                        break;
                        #endregion

                    case "Lt":
                        #region "移动光标"
                        for (int i = 0; i < TB.Length; i++)
                        {
                            if (getIsTBFocused(TB[i].Name))
                            {
                                selectPos = TB[i].SelectionStart;
                                TB[i].Focus();
                                if (selectPos >= 1)
                                {
                                    TB[i].Select(selectPos - 1, 0);
                                }
                            }
                        }
                        break;
                        #endregion

                    case "Rt":
                        #region "移动光标"
                        for (int i = 0; i < TB.Length; i++)
                        {
                            if (getIsTBFocused(TB[i].Name))
                            {
                                selectPos = TB[i].SelectionStart;
                                TB[i].Focus();
                                if (selectPos < this.TB[i].Text.Length)
                                {
                                    TB[i].Select(selectPos + 1, 0);
                                }
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






    }
}

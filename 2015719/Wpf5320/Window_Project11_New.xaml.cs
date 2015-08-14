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
        private bool istbItmeAnnotationFocused=false;
        private bool istbItemAuthorFocused=false;
        private bool istbItemNameFocused=false;
        private int txtfocus = 0;

        public static int CurrentItemID = 1;
        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";


        public Window_Project11()
        {
            InitializeComponent();
        }

        private void exitApp()
        {
            Window_Shutdown_PowerOff Shutdown_PowerOff = new Window_Shutdown_PowerOff();
            Shutdown_PowerOff.Show();
            this.Close();//关闭当前窗口 
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void focusUnchanged(){
            if (istbItemNameFocused) tbItemName.Focus();
            else if (istbItemAuthorFocused) tbItemAuthor.Focus();
            else if (istbItmeAnnotationFocused) tbItmeAnnotation.Focus();
        }

        private void ENT_Click()
        {
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

        }

        private void ESC_Click()
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

        //  声明一个 键盘 对象
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

            keyboardInfoProce(type,value);
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
                if (istbItemNameFocused) tbstringfun(tbItemName, 0, value);
                if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 0, value);
                if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 0, value);
                return;
            }

            else if (type == "character_replace")
            {
                if (istbItemNameFocused) tbstringfun(tbItemName, 1, value);
                if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 1, value);
                if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 1, value);
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
                        exitApp();
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
                        if (istbItemNameFocused) tbstringfun(tbItemName, 3, "*");
                        if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 3, "*");
                        if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 3, "*");
                        break;
                        #endregion

                    case "Tab":
                        #region  "切换焦点"
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

                    case "B.S":
                        #region "删除字符"
                        if (istbItemNameFocused) tbstringfun(tbItemName, 2, "*");
                        if (istbItemAuthorFocused) tbstringfun(tbItemAuthor, 2, "*");
                        if (istbItmeAnnotationFocused) tbstringfun(tbItmeAnnotation, 2, "*");
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

                    case "Up":
                        #region "切换焦点"
                        switch (txtfocus)
                        {
                            case 2:
                                txtfocus = txtfocus - 1;
                                tbItemAuthor.Focus();
                                break;
                            case 1:
                                txtfocus = txtfocus - 1;
                                tbItemName.Focus();
                                break;
                            default:
                                txtfocus = 2;
                                tbItmeAnnotation.Focus();
                                break;
                        }
                        break;
                        #endregion

                    case "Lt":
                        #region "移动光标"
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

                    case "Rt":
                        #region "移动光标"
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
                            if (selectPos < tbItemAuthor.Text.Length)
                            {
                                tbItemAuthor.Select(selectPos + 1, 0);
                            }
                        }
                        if (istbItmeAnnotationFocused)
                        {
                            selectPos = this.tbItmeAnnotation.SelectionStart;
                            tbItmeAnnotation.Focus();
                            if (selectPos < this.tbItmeAnnotation.Text.Length)
                            {
                                tbItmeAnnotation.Select(selectPos + 1, 0);
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







    }
}

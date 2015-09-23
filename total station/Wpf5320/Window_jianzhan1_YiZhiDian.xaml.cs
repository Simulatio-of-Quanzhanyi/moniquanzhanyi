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
using System.Reflection;

namespace Wpf5320
{
    /// <summary>
    /// Window_jianzhan2.xaml 的交互逻辑
    /// </summary>
    public partial class Window_jianzhan2 : Window
    {
        private int selectPos;
        private bool isstationtextFocused = false;
        private bool isYHFocused = false;
        private bool isJHFocused = false;
        private bool isrearviewpoint_textboxFocused = false;
        private int txtfocus = 0;

        public static int CurrentItemID = 1;
       
        private TextBox[] TB = new TextBox[4];

        private string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
       
        public Window_jianzhan2()
        {
            InitializeComponent();
            systime.Content = DateTime.Now.ToShortTimeString();
            Random ran = new Random();    //随机产生度分秒数值
            string angle1 = ran.Next(0,180).ToString();
            string angle2 = ran.Next(0, 60).ToString();
            string angle3 = ran.Next(0, 60).ToString();
            string ha = angle1 + "." + angle2 + angle3;
            HA.Content = ha;
            if(DBClass.Judge("select 点名 from CreatePoint"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from CreatePoint";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stationtext.Text = dr.GetString(0).ToString();
                }
                conn.Close();     
            }
            if (DBClass.Judge("select 点名 from Createrearview"))
            {
                OleDbDataReader dr;
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = "select 点名 from Createrearview";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   rearviewpoint_textbox.Text = dr.GetString(0).ToString();
                }
                conn.Close();
            }

            initTBArray();
                 
        }

        private void initTBArray()
        {

            TB[0] = stationtext;
            TB[1] = YH;
            TB[2] = JH;
            TB[3] = rearviewpoint_textbox;
        }

        private void stationtext_GotFocus(object sender, RoutedEventArgs e)
        {
            isstationtextFocused = true;
            isYHFocused = false;
            isJHFocused = false;
            isrearviewpoint_textboxFocused = false; 
            txtfocus = 0;
        }

        private void YH_GotFocus(object sender, RoutedEventArgs e)
        {
            isstationtextFocused = false;
            isYHFocused = true;
            isJHFocused = false;
            isrearviewpoint_textboxFocused = false;
            txtfocus = 1;
        }

        private void JH_GotFocus(object sender, RoutedEventArgs e)
        {
            isstationtextFocused = false;
            isYHFocused = false;
            isJHFocused = true;
            isrearviewpoint_textboxFocused = false;
            txtfocus = 2;
        }

        private void rearviewpoint_textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            isstationtextFocused = false;
            isYHFocused = false;
            isJHFocused = false;
            isrearviewpoint_textboxFocused = true;
            txtfocus = 3;
        }



        private void ESC_Click()
        {
            Window_jianzhan1 window_jianzhan1= new Window_jianzhan1();
            window_jianzhan1.Show();
            this.Close();//关闭当前窗口
        }

        private void ENT_Click()
        {
           
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {
            if (stationtext.Text==""||YH.Text==""||JH.Text=="")
            {
                MessageBox.Show("请输入（选择）相关数据！", "提示");
            }
            else
            {
                if(rearview_point.Visibility==0)
                {
                    if (rearviewpoint_textbox.Text == "")
                        MessageBox.Show("后视点不能为空！");
                    else
                    {
                        OleDbConnection conn = new OleDbConnection(odbcConnStr);
                        conn.Open();
                        string sql = "select * from Buildstation where 测站='" + stationtext.Text.Trim() + "'";
                        OleDbCommand cmd = new OleDbCommand(sql, conn);                       
                        if (cmd.ExecuteScalar() != null)
                        {                          
                                sql = "Insert into Buildstation (测站,仪高,镜高,后视点,后视角,HA) Values('" + stationtext.Text.Trim() + "','" + YH.Text.Trim() + "','" + JH.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "','" + HA.Content + "')";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                sql = "Delete from rearview_checking";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                sql = "Insert into rearview_checking (测站点名,后视点名,BS) Values('" + stationtext.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + HA.Content + "')";
                                cmd = new OleDbCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("设置成功！", "提示");
                                conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("该已知点不存在！","提示");
                        }
                    }                       
                }
                else
                {                   
                        if (rearview_angle.Visibility == 0)
                        {
                            if (rearviewangle_textbox.Text == "")
                                MessageBox.Show("请输入后视角！");
                            else
                            {
                                string sql = "select * from Buildstation where 测站='" + stationtext.Text.Trim() + "'";
                                if (DBClass.Judge(sql))
                                {
                                    if (MessageBox.Show("已经存在的测站点，是否覆盖？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        DBClass.Manipulation("Update Buildstation set 仪高='" + YH.Text.Trim() + "',镜高='" + JH.Text.Trim() + "',后视点='" + rearviewpoint_textbox.Text.Trim() + "',后视角='" + rearviewangle_textbox.Text.Trim() + "' where测站='" + stationtext.Text.Trim() + "'");
                                        ESC_Click();
                                    }
                                }
                                else
                                {
                                    sql = "Insert into Buildstation (测站,仪高,镜高,后视点,后视角,HA) Values('" + stationtext.Text.Trim() + "','" + YH.Text.Trim() + "','" + JH.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "','" + HA.Content + "')";
                                    DBClass.Manipulation(sql);
                                    sql = "Delete from rearview_checking";
                                    DBClass.Manipulation(sql);
                                    sql = "Insert into rearview_checking (测站点名,后视点名,BS) Values('" + stationtext.Text.Trim() + "','" + rearviewpoint_textbox.Text.Trim() + "','" + rearviewangle_textbox.Text.Trim() + "')";
                                    DBClass.Manipulation(sql);           
                                    MessageBox.Show("设置成功！", "提示");
                                }
                            }                          
                        }                     
                    }
                }                          
            }

        private void rearview_point_Click(object sender, RoutedEventArgs e)
        {
            rearview_combox.Visibility = (Visibility)1;
            rearview_point.Visibility = (Visibility)1;
            rearviewpoint_textbox.Visibility = (Visibility)1;
            rearview_angle.Visibility = 0;
            DMS.Visibility =0;
            rearviewangle_textbox.Visibility = 0;
        }

        private void rearview_angle_Click(object sender, RoutedEventArgs e)
        {          
            rearview_angle.Visibility = (Visibility)1;
            DMS.Visibility = (Visibility)1;
            rearviewangle_textbox.Visibility = (Visibility)1;
            rearview_combox.Visibility = 0;
            rearview_point.Visibility = 0;
            rearviewpoint_textbox.Visibility = 0;
        }
       
        private void diaoyong1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_diaoyong diaoyong =new Window_jianzhan2_YiZhiDian_diaoyong();
            diaoyong.Show();
            this.Close();

        }

        private void diaoyong2_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan2_YiZhiDian_DY DY =new Window_jianzhan2_YiZhiDian_DY();
            DY.Show();
            this.Close();
        }

        private void xinjian1_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1_YiZhiDian_new jianzhan_new = new Window_jianzhan1_YiZhiDian_new();
            jianzhan_new.Show();
            this.Close();
        }

        private void xinjian2_Click(object sender, RoutedEventArgs e)
        {
            Window_jianzhan1_YiZhiDian_new jianzhan_new = new Window_jianzhan1_YiZhiDian_new();
            jianzhan_new.Show();
            this.Close();
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

            keyboardInfoProce(type, value);
        }

        private void ESCkey_Click(object sender, RoutedEventArgs e)
        {
            ESC_Click();
        }
        private void ENTkey_Click(object sender, RoutedEventArgs e)
        {
            ENT_Click();
        }

        private void softkeyboard_Click(object sender, RoutedEventArgs e)
        {
            toggleSoftKeyboard();
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

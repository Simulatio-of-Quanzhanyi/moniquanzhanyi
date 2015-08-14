using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// keyboard.xaml 的交互逻辑
    /// </summary>
    public partial class keyboard : UserControl
    {
        public keyboard()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = false;
        }

        private string returnType = null;
        private string returnValue = null;

        private System.Windows.Threading.DispatcherTimer timer;
        private bool isUpper = false;
        private bool isCharacter = false;
        private bool isTimeout = true;
        private string lastKey = null;
        private int lastKey_Click_Num = 0;

        //  接口 ReturnType（类型） ReturnValue （值）
        //  返回类型种类为  null,  number,   character, character_replace,  symbol,  function
        //  返回值相应为    null,  对应数字,  对应字母,   对应替换字母，  对应符号, 键名称

        public string ReturnType
        {
            get { return returnType; }
        }
        public string ReturnValue
        {
            get { return returnValue; }
        }

        public void keyboard_click(object sender, RoutedEventArgs e)
        {
            Button bt = e.OriginalSource as Button;
            if (bt == null)
            {
                this.returnType = null;
                this.returnValue = null;
                return;
            }
            
            string keyName = bt.Name.ToString();

            if (keyName == "")
            {
                this.returnType = null;
                this.returnValue = null;
                return;
            }

            string type = keyName.Substring(0, 3);

            string name = keyName.Substring(4);

            if (type == "cha")
            {
                if (!isCharacter)
                {
                    returnValue = bt.Content.ToString();
                    returnType = "number";
                }
                else
                {
                    string currentKey = bt.Name.ToString();
                    timer.Stop();
                    timer.Start();
                    if (currentKey != lastKey)
                    {
                        lastKey = currentKey;
                        isTimeout = false;
                        lastKey_Click_Num = 1;
                    }
                    else
                    {
                        lastKey_Click_Num++;
                    }
                    object o = this.GetType().GetField(currentKey, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    Button btn = (Button) o;
                    string currentContent = btn.Content.ToString();
                    
                    switch (lastKey_Click_Num % 3)
                    {
                        case 0:
                            returnValue = currentContent.Substring(2, 1);
                            break;
                        case 1:
                            returnValue = currentContent.Substring(0, 1);
                            break;
                        case 2:
                            returnValue = currentContent.Substring(1, 1);
                            break;
                    }

                    if (!isUpper)
                    {
                        returnValue = returnValue.ToLower();
                    }

                    if (isTimeout)
                    {
                        returnType = "character";
                    }
                    else
                    {
                        returnType = "character_replace";
                    }

                    if (lastKey_Click_Num == 1)
                    {
                        returnType = "character";
                    }

                    isTimeout = false;

                }
            }
            else if(type == "fun"){
                switch (name)
                {
                    case "Alpha":      
                        #region "大小写切换"
                        if (isCharacter)
                        {
                            isUpper = !isUpper;
                            //if (isUpper)
                            //{
                            //    isUpper = false;
                            //    MessageBox.Show("小写字母");
                            //}
                            //else
                            //{
                            //    isUpper = true;
                            //    MessageBox.Show("大写字母");
                            //}
                        }
                        returnValue = null;
                        break;
                        #endregion 

                    case "Shift":
                        #region "字母数字键盘切换"
                        if (!isCharacter)
                        {
                            isCharacter = !isCharacter;
                            cha_0.Content = "#$%";
                            cha_Dot.Content = "!&@";
                            cha_Hyphen.Content = "+*/";
                            cha_1.Content = "STU";
                            cha_2.Content = "VWX";
                            cha_3.Content = "YZY";
                            cha_4.Content = "JKL";
                            cha_5.Content = "MNO";
                            cha_6.Content = "PQR";
                            cha_7.Content = "ABC";
                            cha_8.Content = "DEF";
                            cha_9.Content = "GHI";
                        }
                        else
                        {
                            isCharacter = !isCharacter;
                            timer.IsEnabled = false;
                            cha_0.Content = "0";
                            cha_Dot.Content = ".";
                            cha_Hyphen.Content = "-";
                            cha_1.Content = "1";
                            cha_2.Content = "2";
                            cha_3.Content = "3";
                            cha_4.Content = "4";
                            cha_5.Content = "5";
                            cha_6.Content = "6";
                            cha_7.Content = "7";
                            cha_8.Content = "8";
                            cha_9.Content = "9";
                        }
                        this.returnType = null;
                        this.returnValue = null;
                        break;
                        #endregion

                    case "SP":
                        #region  "返回空白字符"
                        returnValue = " ";
                        returnType = "character";
                        break;
                       #endregion

                    case "BS":
                        #region  "返回B.S"
                        returnValue = "B.S";
                        returnType = "function";
                        break;
                       #endregion

                    default:
                        #region "返回按键名称"
                        returnType = "function";
                        returnValue = name;


                        break;
                        #endregion
                }

            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            isTimeout = true;
        }
    }
}

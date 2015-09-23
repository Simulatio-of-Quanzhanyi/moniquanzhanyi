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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf5320
{
    /// <summary>
    /// sofyKeyboard.xaml 的交互逻辑
    /// </summary>
    public partial class softKey : UserControl
    {
        private bool isCap = false;     //  是否大写

        private string returnValue;     //  按键返回值

        private string returnType;      //  按键返回值类型

        public softKey()
        {
            InitializeComponent();
        }

        public string ReturnValue
        {
            get{ return returnValue; }
        }
        public string ReturnType
        {
            get { return returnType; }
        }

        //  接口 ReturnType（类型） ReturnValue （值）
        //  返回类型种类为  null,  number,   character,  symbol,  function
        //  返回值相应为    null,  对应数字,  对应字母,  对应符号, 键名称


        public void softKey_Click(object sender, MouseButtonEventArgs e)
        {
            //  软键盘单击事件函数 （未绑定任何控件）
            Button bt = e.OriginalSource as Button;

            if (bt == null)
            {
                //  单击按钮为空按钮  设置返回值类型，结束函数调用
                returnType = "null";
                return;
            }

            //  获取按钮名称
            string keyName = bt.Name.ToString();

            if (keyName == "")
            {
                //  按钮名为空，直接返回
                returnType = "null";
                returnValue = "null";
                return;
            }
            string type = "null";

            if (keyName.Length > 4)
            {
                //  按钮名长度大于4   （说明有前缀（num_ cha_ func_））
                type = keyName.Substring(0, 3);
            }


            if (type == "num")
            {
                //  按钮类型为数字
                returnValue = bt.Content.ToString();
                returnType = "number";
                return;
            }
            else if (type == "cha")
            {
                //  按钮类型为字母，判断大小写
                if (isCap)
                {
                    returnValue = bt.Content.ToString().ToUpper();
                }
                else
                {
                    returnValue = bt.Content.ToString();
                }
                returnType = "character";
                return;
            }
            else if (type == "fun")
            {
                //  按钮类型为功能键
                returnType = "function";
                string funType = keyName.Substring(4, 3);
                switch (funType)
                {
                    case "Cap":     //  大小写切换键
                        isCap = !isCap;
                        returnType = "null";
                        returnValue = "null";
                        break;
                   case "S_P": //  空格键 作为字母返回
                        returnValue = " ";
                        returnType = "character";
                        break;
                    case "B_S":
                        returnValue = "B.S";
                        break;
                    case "Ctr":
                        returnValue = "Ctrl";
                        break;
                    default:
                        returnValue = funType;
                        break;
                }
            }
            else if(type == "sym")
            {
                //  其他即符号按钮
                returnValue = bt.Content.ToString();
                returnType = "symbol";
            }
            else
            {
                returnType = null;
                returnValue = null;
            }
        }


    }
}

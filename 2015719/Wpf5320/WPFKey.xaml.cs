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
    /// WPFKey.xaml 的交互逻辑
    /// </summary>
    public partial class WPFKey : UserControl
    {
        private bool isCap = false;     //  是否大写

        private string returnValue;     //  按键返回值

        private string returnType;      //  按键返回值类型
       
        public WPFKey()
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

        public void layoutRoot_Click(object sender, MouseButtonEventArgs e)
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
                return;
            }
            string keyType = "other";

            if (keyName.Length > 4)
            {
                //  按钮名长度大于4   （说明有前缀（num_ cha_ func_））
                keyType = keyName.Substring(0, 4);
            }


            if (keyType == "num_")
            {
                //  按钮类型为数字
                returnValue = bt.Content.ToString();
                returnType = "number";
                return;
            }
            else if (keyType == "cha_")
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
            else if (keyType == "fun_")
            {
                //  按钮类型为功能键
                returnType = "function";
                string funType = keyName.Substring(4, 3);
                switch (funType)
                {
                    case "Cap":     //  大小写切换键
                        isCap = !isCap;
                        returnType = "null";
                        break;
                        case "Spa": //  空格键 作为字母返回
                        returnValue = " ";
                        returnType = "character";
                        break;
                    default:
                        returnValue = funType;
                        break;
                }
            }
            else
            {
                //  其他即符号按钮
                returnValue = bt.Content.ToString();
                returnType = "other";
            }
        }


    }
}

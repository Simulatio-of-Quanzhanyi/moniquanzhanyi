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
    /// selectUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class UC_Select : UserControl
    {
        string btn_result;
 
        public string getBtn_result()
        {
            return btn_result;
        }
        public UC_Select()
        {
            InitializeComponent();
        }

        public void btn_Click(object sender, MouseButtonEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            if (btn == null)
            {
               btn_result = null;
               return;
            }
            String btn_name = btn.Name.ToString();
            if(btn_name == "")
            {
                btn_result = null;
                return;
            }

            if(btn_name == "btn_OK")
            {
                btn_result = "OK";
                return;
            }

            if (btn_name == "btn_Cancel")
            {
                btn_result = "Cancel";
                return;
            }
        }


    }
}

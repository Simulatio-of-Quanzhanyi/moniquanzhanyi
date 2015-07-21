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
       
        public WPFKey()
        {
            InitializeComponent();
        }
        private void LayoutRoot_Click(object sender, RoutedEventArgs e)
        {
            Button bt = e.OriginalSource as Button;
            if (bt != null)
            {
                    //  TextMaxLenth = bt.Content.ToString();
 

            }
        }
       /* public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value", typeof(string), typeof(WPFKey), new UIPropertyMetadata(10000));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }*/
        /*public string TextMaxLenth
        {
            get { return (string)GetValue(TextMaxLenthProperty); }
            set { SetValue(TextMaxLenthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextMaxLenth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextMaxLenthProperty =
            DependencyProperty.Register("TextMaxLenth", typeof(string), typeof(WPFKey), new UIPropertyMetadata(10000));
       private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //TextMaxLenth=1;
           
        }  */
    }
}

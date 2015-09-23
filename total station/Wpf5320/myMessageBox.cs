using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf5320
{
    class myMessageBox
    {

        public void show(string txt)
        {
            MessageboxModel mmb = new MessageboxModel();
            mmb.Message.Content = txt;
            double screenwidth = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double screenheight = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            double x = (screenwidth - 640) / 2+64+159.5-90;//获取界面中心坐标
            double y = (screenheight - 388) / 2+75+106-60;

            mmb.WindowStartupLocation = WindowStartupLocation.Manual;

            mmb.Top = y;
            mmb.Left = x;
            mmb.Show();
        }
    }
}

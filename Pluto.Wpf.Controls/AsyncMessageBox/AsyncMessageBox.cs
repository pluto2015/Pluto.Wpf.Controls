using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pluto.Wpf.Controls.AsyncMessageBox
{
    /// <summary>
    /// 异步置顶消息弹框
    /// </summary>
    public class AsyncMessageBox
    {
        public static void Show(string msg,string title="提示",string btnYes="确定")
        {
            Thread thread = new Thread(() =>
            {
                var dlg = new MessageBoxForm(msg, title, btnYes);
                dlg.ShowDialog();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}

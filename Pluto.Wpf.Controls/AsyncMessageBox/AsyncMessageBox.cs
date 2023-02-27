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
        /// <summary>
        /// 显示消息弹窗
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="title">弹窗标题</param>
        /// <param name="btnYes">按钮文本</param>
        public static void Show(string msg,string title="提示",string btnYes="确定")
        {
            var dlg = new MessageBoxForm(msg, title, btnYes);
            dlg.Show();
        }
    }
}

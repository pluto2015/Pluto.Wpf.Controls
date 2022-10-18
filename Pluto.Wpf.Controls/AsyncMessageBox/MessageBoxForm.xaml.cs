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

namespace Pluto.Wpf.Controls.AsyncMessageBox
{
    /// <summary>
    /// MessageBoxForm.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxForm : Window
    {
        public MessageBoxForm(string msg, string title = "提示", string btnYes = "确定")
        {
            InitializeComponent();

            this.Title = title;
            this.TB_Msg.Text = msg;
            this.Btn_Yes.Content = btnYes;
        }

        private void Btn_Yes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

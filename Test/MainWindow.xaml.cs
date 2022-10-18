using Pluto.Wpf.Controls.AsyncMessageBox;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AsyncMessageBox.Show("1111111111\n222222222222222\n333333333333333\n4444444444444444444444\n55555555555555555\n6666666666666"
                , "出错了","确定");
            AsyncMessageBox.Show("您确定吗？"
                , "提示", "确定");
        }
    }
}

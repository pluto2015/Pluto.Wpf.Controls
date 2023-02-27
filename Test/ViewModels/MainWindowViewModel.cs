using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pluto.Wpf.Controls.AsyncMessageBox;
using Pluto.Wpf.Controls.Tab;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ViewModels
{
    public class MainWindowViewModel:ObservableObject
    {
        #region props
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Tab> Tabs { get; set; }= new ObservableCollection<Tab>();
        #endregion
        #region commands
        public RelayCommand MessageCMD { set; get; }
        public RelayCommand AddTabCMD { set; get; }
        #endregion
        #region methods
        public MainWindowViewModel()
        {
            InitCommand();
        }

        private void InitCommand()
        {
            MessageCMD = new RelayCommand(OnMessageCMD);
            AddTabCMD = new RelayCommand(OnAddTabCMD);
        }

        private void OnAddTabCMD()
        {
            Tabs.Add(new Tab
            {
                ContentPage = new System.Windows.Controls.Page(),
                Header =$"tab{Tabs.Count+1}",
                TabWidth = 200
            });
        }

        private void OnMessageCMD()
        {
            AsyncMessageBox.Show("1111111111\n222222222222222\n333333333333333\n4444444444444444444444\n55555555555555555\n6666666666666"
                , "出错了", "确定");
            AsyncMessageBox.Show("您确定吗？"
                , "提示", "确定");
        }
        #endregion
    }
}

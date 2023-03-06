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
using System.Windows;
using System.Windows.Controls;
using Test.Views;

namespace Test.ViewModels
{
    public class MainWindowViewModel:ObservableObject
    {
        #region props
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Tab> Tabs { get; set; }= new ObservableCollection<Tab>();

        private Tab _SelectedTab;
        /// <summary>
        /// 选中的tab
        /// </summary>
        public Tab SelectedTab { set => SetProperty(ref _SelectedTab, value); get => _SelectedTab; }

        #endregion
        #region commands
        public RelayCommand MessageCMD { set; get; }
        public RelayCommand AddTabCMD { set; get; }
        public RelayCommand<string> SelectTabCMD { set; get; }
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
            SelectTabCMD = new RelayCommand<string>(OnSelectTabCMD);
        }

        private void OnSelectTabCMD(string? obj)
        {
            if(!Tabs.Any(x=>x.Header == obj))
            {
                MessageBox.Show($"名称为:{obj}的tab不存在");
                return;
            }

            SelectedTab = Tabs.FirstOrDefault(x => x.Header == obj);
        }

        private void OnAddTabCMD()
        {
            var list = new List<Page>
            {
                new Page1(),
                new Page2(),
            };

            var random = new Random();

            Tabs.Add(new Tab
            {
                ContentPage = list[random.Next(0,2)],
                Header =$"tab{Tabs.Count+1}",
                TabWidth = 100
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

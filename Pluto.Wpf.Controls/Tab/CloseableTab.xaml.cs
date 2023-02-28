using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pluto.Wpf.Controls.Tab
{
    /// <summary>
    /// CloseableTab.xaml 的交互逻辑
    /// </summary>
    public partial class CloseableTab : UserControl,INotifyPropertyChanged,INotifyPropertyChanging
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion
        #region 依赖属性

        /// <summary>
        /// Tab高度
        /// </summary>
        public double TabHeight
        {
            get { return (double)GetValue(TabHeightProperty); }
            set { 
                SetValue(TabHeightProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for TabHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabHeightProperty =
            DependencyProperty.Register("TabHeight", typeof(double), typeof(CloseableTab), new PropertyMetadata((double)30));


        /// <summary>
        /// 页面
        /// </summary>
        public ObservableCollection<Tab> Tabs
        {
            get { return (ObservableCollection<Tab>)GetValue(TabsProperty); }
            set { SetValue(TabsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabsProperty =
            DependencyProperty.Register("Tabs", typeof(ObservableCollection<Tab>), typeof(CloseableTab), 
                new PropertyMetadata(new ObservableCollection<Tab>()));

        public Tab Selected
        {
            get { return (Tab)GetValue(SelectedProperty); }
            set { 
                SetValue(SelectedProperty, value);
                Tabs.Where(x => x == value).ToList().ForEach(x => x.Background = new SolidColorBrush(Colors.LightSkyBlue));
                Tabs.Where(x => x != value).ToList().ForEach(x => x.Background = new SolidColorBrush(Colors.Transparent));
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(Tab), typeof(CloseableTab), new PropertyMetadata(new Tab()));


        #endregion
        #region props
        private Page _SubPage;
        public Page SubPage { set => SetProperty(ref _SubPage, value); get => _SubPage; }
        #endregion
        #region commands
        public RelayCommand<Tab> CloseTab { set; get; }
        public RelayCommand<Tab> ClickTab { set; get; }
        #endregion
        public CloseableTab()
        {
            InitializeComponent();

            CloseTab = new RelayCommand<Tab>(OnCloseTab);
            ClickTab = new RelayCommand<Tab>(OnClickTab);
        }

        private void OnClickTab(Tab obj)
        {
            if(obj == null)
            {
                return;
            }
            SubPage = obj.ContentPage;
            Selected = obj;
        }

        private void OnCloseTab(Tab obj)
        {
            if(obj == null)
            {
                return;
            }

            Tabs.Remove(obj);
            if(Tabs.Count > 0)
            {
                OnClickTab(Tabs[0]);
            }
            else
            {
                SubPage = null;
            }
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            var frame  = sender as Frame;
            if(frame != null && frame.CanGoBack)
            {
                //释放资源
                frame.RemoveBackEntry();
                GC.Collect();
            }
        }

        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var frame = sender as Frame;
            if (frame != null )
            {
                var page = frame.Content as Page;
                if(page != null)
                {
                    var vm = page.DataContext as IDisposable;
                    if(vm == null)
                    {
                        throw new Exception("页面DataContext未实现IDisposable接口");
                    }

                    vm.Dispose();
                }
            }
        }

        private bool SetProperty<T>(ref T field,T newValue)
        {
            if(EqualityComparer<T>.Default.Equals(field,newValue))
            {
                return false;
            }

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(T)));
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(T)));

            return true;
        }

        private void LeftScroll(object sender, RoutedEventArgs e)
        {
            tab_Scroll.LineLeft();
        }

        private void RightScroll(object sender, RoutedEventArgs e)
        {
            tab_Scroll.LineRight();
        }
    }
}

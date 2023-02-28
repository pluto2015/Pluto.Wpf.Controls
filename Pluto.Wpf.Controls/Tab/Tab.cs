using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace Pluto.Wpf.Controls.Tab
{
    public class Tab:ObservableObject
    {
        private double _TabWidth = 100;
        /// <summary>
        /// tab宽度
        /// </summary>
        public double TabWidth { set => SetProperty(ref _TabWidth, value); get => _TabWidth; }

        private string _Header;
        /// <summary>
        /// tab标题
        /// </summary>
        public string Header { get => _Header; set => SetProperty(ref _Header, value); }

        private Page _ContentPage;
        /// <summary>
        /// 页面
        /// </summary>
        public Page ContentPage { set => SetProperty(ref _ContentPage, value); get => _ContentPage; }

        private Brush _Background;
        /// <summary>
        /// 按钮背景
        /// </summary>
        public Brush Background { set=>SetProperty(ref _Background,value); get => _Background; }
    }
}

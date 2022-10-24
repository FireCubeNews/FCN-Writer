using FCN.Core.ViewModels;
using Fluent.Icons;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using FCN.Services;
using FCN.Pages;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class TabItemControl : TabViewItem
    {
        public ArticleViewModel ViewModel
        {
            get => (ArticleViewModel)GetValue(ViewModelProperty);
            set
            {
                SetValue(ViewModelProperty, value);
                ((NavigationService)ViewModel.NavigationService).View = FrameView; // cursed?
                ViewModel.Home();
            }
        }

        public static readonly DependencyProperty ViewModelProperty =
                   DependencyProperty.Register("ViewModel", typeof(ArticleViewModel), typeof(TabItemControl), null);

        public TabItemControl()
        {
            this.InitializeComponent();
        }

        private FluentSymbol SetIcon(string Title) => Icon.Symbol = Title == "Home" ? FluentSymbol.Home20 : FluentSymbol.Document20;
    }
}

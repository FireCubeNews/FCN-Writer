using FCN.Core.Interfaces;
using FCN.Services;
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
using Microsoft.Extensions.DependencyInjection;
using FCN.Core.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class ProfileControl : UserControl
    {
        public HomeViewModel ViewModel
        {
            get => (HomeViewModel)GetValue(ViewModelProperty);
            set
            {
                SetValue(ViewModelProperty, value);
                ProfileService = ViewModel.Profile as ProfileService;
                if (ProfileService.IsLoggedIn)
                    Profile = ProfileService.GetUserMe();
            }
        }

        public static readonly DependencyProperty ViewModelProperty =
                   DependencyProperty.Register("ViewModel", typeof(HomeViewModel), typeof(ProfileControl), null);
        private ProfileService ProfileService;
        private IAuthor Profile;

        public ProfileControl() => this.InitializeComponent();
    }
}

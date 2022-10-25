using FCN.Core.ViewModels;
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
using FCN.Core.Interfaces;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FCN.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        HomeViewModel HomeManager;
        public HomePage()
        {
            HomeManager = App.Current.Services.GetService<HomeViewModel>();
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HomeManager.Token = (int)e.Parameter; // Truly cursed
         //   await HomeManager.LoadArticlesCommand.ExecuteAsync(this);
        }

        private void ArticlesView_ItemClick(object sender, ItemClickEventArgs e) => HomeManager.OpenArticle(e.ClickedItem as IPublishedArticle);
    }
}

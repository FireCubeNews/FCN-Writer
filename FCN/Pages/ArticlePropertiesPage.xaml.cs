using FCN.Core.ViewModels;
using FCN.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FCN.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticlePropertiesPage : Page
    {
        ArticlePropertyViewModel ArticleProperties;
        ImageHelper ImgHelper = new();
        private BitmapImage Preview = new();
        public ArticlePropertiesPage()
        {
            ArticleProperties = new();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ArticleProperties.Token = (int)e.Parameter; // Truly cursed
            if(ArticleProperties.Article.tags is not null)
                foreach(var tag in ArticleProperties.Article.tags)
                    Tags.AddTokenItem(tag);
            try
            {
                if (!String.IsNullOrEmpty(ArticleProperties.Article.headerImage))
                    Preview.UriSource = new Uri(ArticleProperties.Article.headerImage);
            }
            catch { } // truly cursed
            /*  try// Most cursed yet
              {
                  ImageControl.Image.SetSource(ImgHelper.Base64ToImageStream(ArticleProperties.Article.headerImage));
              }
              catch { }*/
        }

        private void Exit_Click(object sender, RoutedEventArgs e) // top cursed
        {
           // ArticleProperties.Article.headerImage = await ImgHelper.ImageToBase64(ImageControl.ImageStream);
        }

        private void ImageLink_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ImageLink.Text))
                    Preview.UriSource = new Uri(ImageLink.Text);
            }
            catch { } // truly cursed
        }

        private void Tags_TokenItemAdded(Microsoft.Toolkit.Uwp.UI.Controls.TokenizingTextBox sender, object args)
        {
            if (ArticleProperties.Article.tags is null)
                ArticleProperties.Article.tags = new();
            if(!ArticleProperties.Article.tags.Contains((string)args))
                ArticleProperties.Article.tags.Add((string)args);
        }

        private void Tag_Click(object sender, RoutedEventArgs e) => Tags.AddTokenItem((string)((sender as Button).Content));
    }
}

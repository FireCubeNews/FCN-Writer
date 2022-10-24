using Windows.UI.Xaml.Controls;
using FCN.Core.Classes;
using Windows.UI.Xaml;
using FCN.Core.Interfaces;
using Windows.UI.Xaml.Media.Imaging;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FCN.Controls
{
    public sealed partial class ImageEditor : UserControl, IEditor
    {
        private double TextBoxWidth;
        private BitmapImage Preview = new();
        public IArticleElement ArticleElement
        {
            get => (ImageElement)GetValue(ArticleElementProperty);
            set
            {
                SetValue(ArticleElementProperty, value);
                if ((ArticleElement as ImageElement).Caption is not null) // ,most cursed
                    Caption.Text = (ArticleElement as ImageElement).Caption;
                if ((ArticleElement as ImageElement).AltText is not null)
                    AltText.Text = (ArticleElement as ImageElement).AltText;
                if ((ArticleElement as ImageElement).ImageLink is not null)
                    ImageLink.Text = (ArticleElement as ImageElement).ImageLink;
            }
        }

        public static readonly DependencyProperty ArticleElementProperty =
                   DependencyProperty.Register("ArticleElement", typeof(ImageElement), typeof(ImageEditor), null);

        public ImageEditor()
        {
            this.InitializeComponent();
            TextBoxWidth = ((Frame)Window.Current.Content).ActualWidth - 280;
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ImageElement img = ArticleElement as ImageElement;
            img.Caption = Caption.Text;
            img.ImageLink = ImageLink.Text;
            img.AltText = AltText.Text;
            try
            {
                if(!String.IsNullOrEmpty(ImageLink.Text))
                    Preview.UriSource = new Uri(ImageLink.Text);
            }
            catch { } // truly cursed
        }

    }
}

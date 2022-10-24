using System;
using Windows.UI.Xaml.Controls;
using FCN.Core.Classes;
using Windows.UI.Xaml;
using FCN.Core.Interfaces;
using FCN.Core.Enums;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class HeaderEditor : UserControl, IEditor
    {
        public IArticleElement ArticleElement
        {
            get => (HeaderElement)GetValue(ArticleElementProperty);
            set
            {
                SetValue(ArticleElementProperty, value);
                if ((ArticleElement as HeaderElement).Header is not null)
                {
                    HeaderBox.Text = ((HeaderElement)ArticleElement).Header;
                    Size.SelectedIndex = (int)((HeaderElement)ArticleElement).Type;
                }
            }
        }

        public static readonly DependencyProperty ArticleElementProperty =
                   DependencyProperty.Register("ArticleElement", typeof(HeaderElement), typeof(ImageEditor), null);

        public HeaderEditor() => this.InitializeComponent();

        private void HeaderBox_TextChanged(object sender, TextChangedEventArgs e) => ((HeaderElement)ArticleElement).Header = HeaderBox.Text;

        private void SizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (Size.SelectedIndex)
                {
                    case 0:
                        HeaderBox.FontSize = 28;
                        ((HeaderElement)ArticleElement).Type = HeaderEnum.Header;
                        break;
                    case 1:
                        HeaderBox.FontSize = 24;
                        ((HeaderElement)ArticleElement).Type = HeaderEnum.SubHeader;
                        break;
                    case 2:
                        HeaderBox.FontSize = 20;
                        ((HeaderElement)ArticleElement).Type = HeaderEnum.AltHeader;
                        break;
                }
            }
            catch { }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class ImageUploaderControl : UserControl
    {
        public IRandomAccessStreamReference ImageStream;
        public BitmapImage Image
        {
            get => (BitmapImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
                   DependencyProperty.Register("Image", typeof(BitmapImage), typeof(ImageUploaderControl), null);

        public ImageUploaderControl()
        {
            this.InitializeComponent();
            Image = new BitmapImage();
        }

        private async void Paste(object sender, RoutedEventArgs e)
        {
            var dataPackageView = Clipboard.GetContent();
            if (dataPackageView.Contains(StandardDataFormats.Bitmap))
            {
                ImageStream = await dataPackageView.GetBitmapAsync();
                if (ImageStream != null)
                {
                    using (var iStream = await ImageStream.OpenReadAsync())
                    {
                        Image.SetSource(iStream);
                    }
                }
            }
        }
    }
}

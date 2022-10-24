using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Helpers
{
    class LinkToImageConverter : IValueConverter
    {
        BitmapImage Bitmap = new();
        public object Convert(object value, Type targetType, object parameter, string language) => Bitmap.UriSource = !String.IsNullOrEmpty((string)value) ? new Uri((string)value) : new Uri("e");

        public object ConvertBack(object value, Type targetType, object parameter, string language) => Bitmap.UriSource.ToString();
    }
}

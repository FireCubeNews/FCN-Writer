using FCN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Helpers
{
    public class Base64ToImageConverter : IValueConverter
    {
        IImageHelper Imghelper = new ImageHelper();
        public object Convert(object value, Type targetType, object parameter, string language) => Imghelper.Base64ToImage((string)value);

        public object ConvertBack(object value, Type targetType, object parameter, string language) => Imghelper.ImageToBase64((BitmapImage)value);
    }
}

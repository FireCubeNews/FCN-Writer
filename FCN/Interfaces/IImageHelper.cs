using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Interfaces
{
    public interface IImageHelper
    {
        public BitmapImage Base64ToImage(string Base64);

        public Task<string> ImageToBase64(BitmapImage Image);
    }
}

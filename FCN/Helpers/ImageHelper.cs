using FCN.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public BitmapImage Base64ToImage(string Base64)
        {
            if (String.IsNullOrEmpty(Base64))
                return new BitmapImage();
            byte[] imageBytes = Convert.FromBase64String(Base64);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                BitmapImage Bitmap = new();
                Bitmap.SetSource(ms.AsRandomAccessStream());
                return Bitmap;
            }
        }

        public IRandomAccessStream Base64ToImageStream(string Base64)
        {
            if (String.IsNullOrEmpty(Base64))
                return null;
            byte[] imageBytes = Convert.FromBase64String(Base64);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                BitmapImage Bitmap = new();
                return ms.AsRandomAccessStream();
            }
        }

        public async Task<string> ImageToBase64(BitmapImage Image)
        {
            if (Image is null)
                return "";
            IRandomAccessStream Stream = await RandomAccessStreamReference.CreateFromUri(Image.UriSour‌​ce).OpenReadAsync();
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(Stream);
            PixelDataProvider pixelData = await decoder.GetPixelDataAsync();
            byte[] Bytes = pixelData.DetachPixelData();
            return Convert.ToBase64String(Bytes);
        }

        public async Task<string> ImageToBase64(IRandomAccessStreamReference Stream)
        {
            if (Stream is null)
                return "";
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                IRandomAccessStream IStream = await Stream.OpenReadAsync();
                IStream.AsStream().CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            return Convert.ToBase64String(bytes);
        }
    }
}

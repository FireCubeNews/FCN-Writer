using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Helpers
{
    public class UIHelper
    {
        public static bool Invert(bool boolean) => !boolean;

        public static string FormatTime(long ms)  =>  new DateTime(1970, 1, 1).AddMilliseconds(ms).ToString("MMM dd, yyyy"); // ms is milliseconds from 1st jan 1970

        public static BitmapImage SanitizeUri(string Uri)
        {
            BitmapImage Bitmap = new();
            try
            {
                Bitmap.UriSource = !String.IsNullOrEmpty(Uri) ? new Uri(Uri) : new Uri("https://media.discordapp.net/attachments/1033808146533187674/1034177366055976990/unknown.png"); // e cursed
            }
            catch
            {
                Bitmap.UriSource = new Uri("https://media.discordapp.net/attachments/1033808146533187674/1034177366055976990/unknown.png"); // e cursed
            }
            return Bitmap;
        }
    }
}

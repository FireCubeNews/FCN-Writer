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
using Windows.System;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.Controls
{
    public sealed partial class SettingsControl : UserControl
    {
        public SettingsControl() => this.InitializeComponent();

        private IAsyncOperation<bool> OpenLink(string linkUrl) => Launcher.LaunchUriAsync(new Uri(linkUrl));

        private async void GitHub_Click(object sender, RoutedEventArgs e) => await OpenLink("https://github.com/FireCubeNews/FCN-Writer");

        private async void Discord_Click(object sender, RoutedEventArgs e) => await OpenLink("https://discord.com/invite/cj4gM8VdeF");

        private async void Twitter_Click(object sender, RoutedEventArgs e) => await OpenLink("https://twitter.com/FireCubeNews");
    }
}

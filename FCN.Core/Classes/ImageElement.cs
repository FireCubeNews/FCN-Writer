using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class ImageElement : IArticleElement
    {
        private const string Start = "<figure class=\"margin - bottom\"> \n";
        private const string End = "</figcaption> \n</figure>";
        private const string Base64 = "data:image/png;base64,";
        public string ImageLink;
        public string Caption;
        public string AltText;

        public string GetRawText() => $"{Start}<img src=\"{ImageLink}\" alt=\"{AltText}\"> \n <figcaption>{Caption}{End}";
    }
}

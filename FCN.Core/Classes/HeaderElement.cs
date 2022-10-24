using FCN.Core.Enums;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class HeaderElement : IArticleElement
    {
        public string Header;
        public HeaderEnum Type = HeaderEnum.Header;

        public string GetRawText() => new string('#', (int)Type + 1) + Header;
    }
}

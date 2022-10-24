using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class MarkdownElement : IArticleElement
    {
        public string MarkdownText;

        public string GetRawText() => MarkdownText;
    }
}

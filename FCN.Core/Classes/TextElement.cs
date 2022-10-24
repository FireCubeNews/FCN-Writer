using FCN.Core.Helpers;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class TextElement : IArticleElement
    {
        public string RtfText;

        public string GetRawText() => MarkdownHelper.RtfToMarkdown(RtfText);
    }
}

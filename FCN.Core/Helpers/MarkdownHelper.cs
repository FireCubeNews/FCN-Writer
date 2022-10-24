using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BracketPipe;
using RtfPipe;

namespace FCN.Core.Helpers
{
    public class MarkdownHelper
    {
        public static string RtfToMarkdown(string source)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var w = new StringWriter())
            using (var md = new MarkdownWriter(w))
            {
                Rtf.ToHtml(source, md);
                md.Flush();
                return w.ToString();
            }
        }
    }
}

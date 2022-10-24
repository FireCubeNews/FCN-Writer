using FCN.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace FCN.Helpers
{
    public class EditorTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Text { get; set; } // WYSIWYGEditor
        public DataTemplate Image { get; set; }   // Image Editor
        public DataTemplate Header { get; set; }   // Header Editor
        public DataTemplate Markdown { get; set; }   // Markdown Editor

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is TextElement)
                return Text;
            else if (item is HeaderElement)
                return Header;
            else if (item is MarkdownElement)
                return Markdown;
            else
                return Image;
        }
    }
}

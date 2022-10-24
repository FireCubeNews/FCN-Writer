using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class PublishedPreviewArticle : IPublishedArticle
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public string headerImage { get; set; }
        public long time { get; set; }
        public List<string> tags { get; set; }
        public bool published { get; set; }
    }
}

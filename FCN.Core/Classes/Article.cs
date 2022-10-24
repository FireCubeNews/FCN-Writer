using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class Article : IArticle
    {
        public string title { get; set; }
        public string description { get; set; }
        public string headerImage { get; set; }
        public string content { get; set; }
        public List<string> tags { get; set; }
        public bool published { get; set; }
    }
}

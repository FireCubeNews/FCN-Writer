using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Classes
{
    public class Author : IAuthor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string iconURL { get; set; }
    }
}

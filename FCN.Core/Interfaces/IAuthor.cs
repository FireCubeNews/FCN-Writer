using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Interfaces
{
    public interface IAuthor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string iconURL { get; set; }
    }
}

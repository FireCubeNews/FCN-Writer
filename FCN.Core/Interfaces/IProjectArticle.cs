using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace FCN.Core.Interfaces
{
    public interface IProjectArticle : IArticle
    {
        public bool IsUploaded { get; set; } // If the article is already uploaded
        public string ProjectId { get; set; }
        public ObservableCollection<IArticleElement> ArticleContents { get; set; }
    }
}

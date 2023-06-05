using CommunityToolkit.Mvvm.ComponentModel;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace FCN.Core.Classes
{
    [ObservableObject]
    public partial class ProjectArticle : IProjectArticle
    {
        public string title { get; set; }
        public string description { get; set; }
        public string headerImage { get; set; }
        public string content { get; set; }
        public List<string> tags { get; set; }
        public bool published { get; set; }
        public string ProjectId { get; set; }
        public bool IsUploaded { get; set; }
        public ObservableCollection<IArticleElement> ArticleContents { get; set; }
    }
}

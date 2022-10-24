using FCN.Core.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Core.Interfaces
{
    public interface IArticlesService
    {
        public ObservableCollection<PublishedPreviewArticle> UserArticles { get; set; }
        Task RefreshAsync();
    }
}

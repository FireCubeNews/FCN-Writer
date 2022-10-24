using FCN.Core.Classes;
using FCN.Core.Helpers;
using FCN.Core.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Core.Services
{
    public class ArticlesService : IArticlesService
    {
        public ObservableCollection<PublishedPreviewArticle> UserArticles { get; set; }

        public IProfileService Profile;

        public ArticlesService(IProfileService profile)
        {
            Profile = profile;
            LoadArticlesAsync();
        }

        public async Task RefreshAsync() => await LoadArticlesAsync();

        private async Task LoadArticlesAsync()
        {
            await Task.Run(() =>
            {
                if (Profile.IsLoggedIn)
                {
                    var client = new RestClient(baseUrl: UriHelper.GetPostsUri);
                    var request = new RestRequest();
                    request.Method = Method.Get;
                    request.AddHeader("x-api-key", Profile.GetKey());
                    RestResponse response = client.Execute(request);
                    if (response.IsSuccessful)
                        UserArticles = JsonConvert.DeserializeObject<ObservableCollection<PublishedPreviewArticle>>(response.Content);
                }
            });
        }
    }
}

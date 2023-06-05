using FCN.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using FCN.Core.Classes;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FCN.Core.Helpers
{
    public class PublisherHelper
    {
        static Uri ApiUrl = new Uri("https://firecube.news/api/v1/posts/create");
        static Uri EditApiUrl = new Uri("https://firecube.news/api/v1/posts/");

        public static async Task<bool> PublishAsync(IProjectArticle Article, string ApiKey)
        {
            RestResponse response = new();
            await Task.Run(() => { // Cursed
                ProjectArticle article = Article as ProjectArticle;
                Article a = new();
                a.title = article.title;
                a.description = article.description;
                a.headerImage = article.headerImage;
                StringBuilder content = new();
                foreach (IArticleElement Element in article.ArticleContents)
                {
                    content.AppendLine(Element.GetRawText());
                }
                a.content = content.ToString();
                a.published = article.published;
                a.tags = Article.tags;
                Debug.WriteLine(Article.ProjectId);
                RestClient client = Article.IsUploaded ? new RestClient(baseUrl: EditApiUrl + Article.ProjectId) : new RestClient(baseUrl: ApiUrl);
                var request = new RestRequest();
                request.Method = Article.IsUploaded ? Method.Patch : Method.Post;
                request.AddHeader("x-api-key", ApiKey);
                request.AddParameter("application/json", JsonConvert.SerializeObject(a), ParameterType.RequestBody);
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    Debug.WriteLine("error msg: " + response.ErrorMessage);
                    Debug.WriteLine("status code: " + response.StatusCode);
                    Debug.WriteLine("status description: " + response.StatusDescription);
                    Debug.WriteLine("response: " + response.Content);
                    Debug.WriteLine(response.ErrorMessage);
                }
            });
            return response.IsSuccessful;
        }
    }
}

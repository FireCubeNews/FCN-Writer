using FCN.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using FCN.Core.Classes;
using System.Diagnostics;

namespace FCN.Core.Helpers
{
    public class PublisherHelper
    {
        static readonly string ApiKey = "2rhiF+hTCwiksglq";
        static Uri ApiUrl = new Uri("https://fcn.technobiscuit.uk/api/v1/posts/create");

        public static PublishedArticle? Publish(IProjectArticle Article)
        {
            ProjectArticle article = Article as ProjectArticle;
            Article a = new();
            a.title = article.title;
            a.description = article.description;
            a.headerImage = article.headerImage;
            StringBuilder content = new();
            foreach(IArticleElement Element in article.ArticleContents)
            {
                content.AppendLine(Element.GetRawText());
            }
            a.content = content.ToString();
            a.published = article.published;
            a.tags = Article.tags;
            var client = new RestClient(baseUrl: ApiUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("x-api-key", ApiKey);
            request.AddParameter("application/json", JsonConvert.SerializeObject(a), ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                PublishedArticle p = JsonConvert.DeserializeObject<PublishedArticle>(response.Content);
                article.ProjectId = p.id;
                return p;
            }
            else
            {
                Debug.WriteLine("error msg: " + response.ErrorMessage);
                Debug.WriteLine("status code: " + response.StatusCode);
                Debug.WriteLine("status description: " + response.StatusDescription);
                Debug.WriteLine("response: " + response.Content);
                Debug.WriteLine(response.ErrorMessage);
                return null;
            }
        }
    }
}

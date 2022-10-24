using FCN.Core.Classes;
using FCN.Core.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Helpers
{
    public class ArticleHelper
    {
        public static ProjectArticle ConvertToProject(IPublishedArticle article, string key)
        {
            ProjectArticle Project = new();
            Project.IsUploaded = true;
            Project.title = article.title;
            Project.description = article.description;
            Project.headerImage = article.headerImage;
            Project.tags = article.tags;
            Project.ProjectId = article.id;
            Project.content = GetArticleContent(Project.ProjectId, key);
            MarkdownElement Markdown = new();
            Markdown.MarkdownText = Project.content;
            Project.ArticleContents = new();
            Project.ArticleContents.Add(Markdown);
            return Project;
        }
        public static string GetArticleContent(string id, string key)
        {
            var client = new RestClient(baseUrl: UriHelper.GetPostUri + id);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("x-api-key", key);
            RestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<PublishedArticle>(response.Content).content;
            else
                return "";
        }
    }
}

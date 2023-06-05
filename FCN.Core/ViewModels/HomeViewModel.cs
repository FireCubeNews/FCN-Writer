using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using FCN.Core.Enums;
using FCN.Core.Messages;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using FCN.Core.Classes;
using RestSharp;
using FCN.Core.Helpers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FCN.Core.ViewModels
{
    public class HomeViewModel : ObservableRecipient
    {
        private int token; // Messenger communication
        public int Token
        {
            get => token;
            set => SetProperty(ref token, value);
        }

        public IProfileService Profile;

        public ObservableCollection<PublishedPreviewArticle> PublishedUserArticles = new();

        public ObservableCollection<PublishedPreviewArticle> UnpublishedUserArticles = new();

        public HomeViewModel(IProfileService ProfileService)
        {
            Profile = ProfileService;
            if (Profile.IsLoggedIn)
            {
                var client = new RestClient(baseUrl: UriHelper.GetPostsUri);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("x-api-key", Profile.GetKey());
                RestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    foreach(var article in JsonConvert.DeserializeObject<ObservableCollection<PublishedPreviewArticle>>(response.Content))
                    {
                        if (article.published)
                            PublishedUserArticles.Add(article);
                        else
                            UnpublishedUserArticles.Add(article);
                    }
                }
                else
                {
                    Debug.WriteLine("error msg: " + response.ErrorMessage);
                    Debug.WriteLine("status code: " + response.StatusCode);
                    Debug.WriteLine("status description: " + response.StatusDescription);
                    Debug.WriteLine("response: " + response.Content);
                    Debug.WriteLine(response.ErrorMessage);
                }
            }
        }

        private RelayCommand? newArticleCommand;
        public IRelayCommand NewArticleCommand => newArticleCommand ??= new RelayCommand(NewArticle);
        private void NewArticle() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Create), Token);

        private RelayCommand? logInCommand;
        public IRelayCommand LogInCommand => logInCommand ??= new RelayCommand(LogIn);
        private void LogIn() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.LogIn), Token);

        public void OpenArticle(IPublishedArticle Article)
        {
            if (Profile.IsLoggedIn)
            {
                ProjectArticle Project = ArticleHelper.ConvertToProject(Article, Profile.GetKey());
                WeakReferenceMessenger.Default.Send(new ArticleUpdatedMessage(Project), Token);
                WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Open), Token);
            }
        }

        private AsyncRelayCommand? loadArticlesCommand;
        public IAsyncRelayCommand LoadArticlesCommand => loadArticlesCommand ??= new AsyncRelayCommand(LoadArticlesAsync);
        public async Task LoadArticlesAsync()
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
                    {
                        foreach (var article in JsonConvert.DeserializeObject<ObservableCollection<PublishedPreviewArticle>>(response.Content))
                        {
                            if (article.published)
                                PublishedUserArticles.Add(article);
                            else
                                UnpublishedUserArticles.Add(article);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("error msg: " + response.ErrorMessage);
                        Debug.WriteLine("status code: " + response.StatusCode);
                        Debug.WriteLine("status description: " + response.StatusDescription);
                        Debug.WriteLine("response: " + response.Content);
                        Debug.WriteLine(response.ErrorMessage);
                    }
                }
            });
        }
    }
}

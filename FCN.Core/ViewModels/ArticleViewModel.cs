using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using FCN.Core.Classes;
using FCN.Core.Interfaces;
using FCN.Core.Enums;
using FCN.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.ViewModels
{
    public class ArticleViewModel : ObservableRecipient
    {
        private int token = new Random().Next(0, 10000); // Messenger communication
        public int Token
        {
            get => token;
            set => SetProperty(ref token, value);
        }

        private string? title = "Home";
        public string? Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private IProjectArticle? article;
        public IProjectArticle? Article
        {
            get => article;
            set => SetProperty(ref article, value);
        }

        public INavigationService NavigationService;

        public ArticleViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            WeakReferenceMessenger.Default.Register<ArticleViewModel, RequestArticleMessage, int>(this, Token, (r, m) =>
            {
               m.Reply(r.Article); // Requests the article
            });
            Messenger.Register<ArticleViewModel, RequestArticleMessage>(this, (r, m) =>
            {
                m.Reply(r.Article); // Requests the article
            });
            Messenger.Register<ArticleViewModel, NavigateMessage, int>(this, Token, (r, m) => r.Receive(m));

            Messenger.Register<ArticleViewModel, ArticleUpdatedMessage, int>(this, Token, (r, m) => r.Article = m.Value); // Set article to new
        }

        private void Receive(NavigateMessage message)
        {
            switch(message.Value)
            {
                case NavigationEnum.Create: // cursed
                    Article = new ProjectArticle();
                    Article.ArticleContents = new();
                    Article.tags = new();
                    Article.IsUploaded = false;
                    Article.published = false;
                    NavigationService.NavigateTo<ArticlePropertyViewModel>(Token);
                    Title = "New Article";
                    break;
                case NavigationEnum.Properties: // cursed
                    NavigationService.NavigateTo<ArticlePropertyViewModel>(Token);
                    Title = Article.title;
                    break;
                case NavigationEnum.Edit: // cursed
                    NavigationService.NavigateTo<EditorViewModel>(Token);
                    Title = Article.title;
                    break;
                case NavigationEnum.Publish: // cursed
                    NavigationService.NavigateTo<PublisherViewModel>(Token);
                    Title = Article.title;
                    break;
                case NavigationEnum.Open: // cursed
                    NavigationService.NavigateTo<EditorViewModel>(Token);
                    Title = Article.title;
                    break;
                case NavigationEnum.LogIn: // cursed
                    NavigationService.NavigateTo<LogInViewModel>(Token);
                    Title = "Log In";
                    break;
                case NavigationEnum.Home: // cursed
                    NavigationService.NavigateTo<HomeViewModel>(Token);
                    Title = "Home";
                    break;
            }
        }

        public void Home()
        {
            NavigationService.NavigateTo<HomeViewModel>(Token);
            Title = "Home";
        }
    }
}

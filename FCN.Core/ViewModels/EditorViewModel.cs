using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FCN.Core.Classes;
using FCN.Core.Interfaces;
using System;
using FCN.Core.Enums;
using FCN.Core.Messages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Specialized;

namespace FCN.Core.ViewModels
{
    public class EditorViewModel : ObservableObject
    {
        private int token; // Messenger communication
        public int Token
        {
            get => token;
            set
            {
                SetProperty(ref token, value);
                Article = WeakReferenceMessenger.Default.Send(new RequestArticleMessage(), token).Response; // cursed
            }
        }

        private IProjectArticle? article;
        public IProjectArticle? Article
        {
            get => article;
            set => SetProperty(ref article, value);
        }

        public IProfileService Profile;

        public EditorViewModel(IProfileService ProfileService)
        {
            Profile = ProfileService;
        }

        private RelayCommand? addTextCommand;
        public IRelayCommand AddTextCommand => addTextCommand ??= new RelayCommand(AddText);
        private void AddText() => Article.ArticleContents.Add(new TextElement());

        private RelayCommand? addImageCommand;
        public IRelayCommand AddImageCommand => addImageCommand ??= new RelayCommand(AddImage);
        private void AddImage() => Article.ArticleContents.Add(new ImageElement());

        private RelayCommand? addMarkdownCommand;
        public IRelayCommand AddMarkdownCommand => addMarkdownCommand ??= new RelayCommand(AddMarkdown);
        private void AddMarkdown() => Article.ArticleContents.Add(new MarkdownElement());

        private RelayCommand? addHeaderCommand;
        public IRelayCommand AddHeaderCommand => addHeaderCommand ??= new RelayCommand(AddHeader);
        private void AddHeader() => Article.ArticleContents.Add(new HeaderElement());

        private RelayCommand? editPropertiesCommand;
        public IRelayCommand EditPropertiesCommand => editPropertiesCommand ??= new RelayCommand(EditProperties);
        private void EditProperties() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Properties), Token);

        private RelayCommand? editPublishCommand;
        public IRelayCommand EditPublishCommand => editPublishCommand ??= new RelayCommand(EditPublish);
        private void EditPublish() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Publish), Token);

        private RelayCommand? logInCommand;
        public IRelayCommand LogInCommand => logInCommand ??= new RelayCommand(LogIn);
        private void LogIn() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.LogIn), Token);
    }
}

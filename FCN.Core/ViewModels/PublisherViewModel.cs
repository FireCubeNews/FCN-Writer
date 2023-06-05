using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FCN.Core.Classes;
using FCN.Core.Enums;
using FCN.Core.Messages;
using FCN.Core.Helpers;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Core.ViewModels
{
    public class PublisherViewModel : ObservableObject
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

        public IProfileService Profile;

        public PublisherViewModel(IProfileService ProfileService)
        {
            Profile = ProfileService;
        }

        private IProjectArticle? article;
        public IProjectArticle? Article
        {
            get => article;
            set => SetProperty(ref article, value);
        }

        private RelayCommand? editArticleCommand;
        public IRelayCommand EditArticleCommand => editArticleCommand ??= new RelayCommand(EditArticle);
        private void EditArticle() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Edit), Token);

        private AsyncRelayCommand? uploadArticleCommand;
        public IAsyncRelayCommand UploadArticleCommand => uploadArticleCommand ??= new AsyncRelayCommand(UploadArticleAsync);
        private async Task UploadArticleAsync()
        {
            if(await PublisherHelper.PublishAsync(Article, Profile.GetKey()))
                WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Home), Token);
        }
    }
}

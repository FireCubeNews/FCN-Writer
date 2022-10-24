using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using FCN.Core.Classes;
using FCN.Core.Interfaces;
using System;
using System.Collections.Generic;
using FCN.Core.Enums;
using FCN.Core.Messages;
using System.Diagnostics;
using System.Text;

namespace FCN.Core.ViewModels
{
    public class ArticlePropertyViewModel : ObservableObject
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

        private RelayCommand? editArticleCommand;
        public IRelayCommand EditArticleCommand => editArticleCommand ??= new RelayCommand(EditArticle);
        private void EditArticle() => WeakReferenceMessenger.Default.Send(new NavigateMessage(NavigationEnum.Edit), Token);
    }
}

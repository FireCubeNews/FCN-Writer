using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FCN.Core.Enums;
using FCN.Core.Interfaces;
using FCN.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCN.Core.ViewModels
{
    public class LogInViewModel : ObservableObject
    {
        private int token; // Messenger communication
        public int Token
        {
            get => token;
            set
            {
                SetProperty(ref token, value);
                EditingArticle = !(WeakReferenceMessenger.Default.Send(new RequestArticleMessage(), token).Response is null); // cursed
            }
        }

        public event EventHandler LogInFailed;

        private bool editingArticle;
        public bool EditingArticle
        {
            get => editingArticle;
            set => SetProperty(ref editingArticle, value);
        }

        private string key;
        public string Key
        {
            get => key;
            set => SetProperty(ref key, value);
        }

        public IProfileService Profile;

        public LogInViewModel(IProfileService ProfileService)
        {
            Profile = ProfileService;
        }

        private AsyncRelayCommand? logInCommand;
        public IAsyncRelayCommand LogInCommand => logInCommand ??= new AsyncRelayCommand(LogInAsync);
        private async Task LogInAsync()
        {
            if (await Profile.LogInWithKeyAsync(Key))
                WeakReferenceMessenger.Default.Send(new NavigateMessage(EditingArticle ? NavigationEnum.Edit : NavigationEnum.Home), Token);
            else
            {
                EventHandler handler = LogInFailed;
                handler.Invoke(this, new EventArgs());
            }
        }

        private RelayCommand? exitCommand;
        public IRelayCommand ExitCommand => exitCommand ??= new RelayCommand(Exit);
        private void Exit() => WeakReferenceMessenger.Default.Send(new NavigateMessage(EditingArticle ? NavigationEnum.Edit : NavigationEnum.Home), Token);
    }
}

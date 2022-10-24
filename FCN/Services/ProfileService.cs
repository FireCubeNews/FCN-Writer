using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FCN.Core.Classes;
using FCN.Core.Helpers;
using FCN.Core.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace FCN.Services
{
    public class ProfileService : ObservableObject, IProfileService // All cursed
    {
        private const string resource = "FCN";
        private const string profile = "Profile";
        private PasswordVault Vault = new PasswordVault();
        private bool isLoggedIn; // Messenger communication
        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set
            {
                SetProperty(ref isLoggedIn, value);
                Settings.IsLoggedIn = (bool)value;
            }
        }
        private SettingsService Settings;

        public ProfileService(SettingsService settings)
        {
            Settings = settings;
            IsLoggedIn = Settings.IsLoggedIn;
        }
        public string GetKey() => Vault.Retrieve(resource, profile).Password;

        public async Task<bool> LogInWithKeyAsync(string key)
        {
           RestResponse response = new();
           await Task.Run(() =>
           {
               var client = new RestClient(baseUrl: UriHelper.GetUserMeUri);
               var request = new RestRequest();
               request.Method = Method.Get;
               request.AddHeader("x-api-key", key);
               response = client.Execute(request);
           });
            if (response.IsSuccessful)
            {
                IsLoggedIn = true;
                Vault.Add(new PasswordCredential(resource, profile, key));
            }
            return response.IsSuccessful;
        }

        public IAuthor GetUserMe()
        {
            var client = new RestClient(baseUrl: UriHelper.GetUserMeUri);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("x-api-key", GetKey());
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Author>(response.Content);
        }

        public void LogOut()
        {
            Vault.Remove(Vault.Retrieve(resource, profile));
            IsLoggedIn = false;
        }

        private RelayCommand? logOutCommand;
        public IRelayCommand LogOutCommand => logOutCommand ??= new RelayCommand(LogOut);
    }
}

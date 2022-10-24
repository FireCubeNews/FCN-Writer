﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FCN.Services
{
    public class SettingsService : ObservableObject
    {
        private static ApplicationDataContainer Settings = ApplicationData.Current.LocalSettings;

        private bool isLoggedIn = (bool)(Settings.Values["IsLoggedIn"] ?? false);
        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set
            {
                Settings.Values["IsLoggedIn"] = value;
                SetProperty(ref isLoggedIn, value);
            }
        }
    }
}

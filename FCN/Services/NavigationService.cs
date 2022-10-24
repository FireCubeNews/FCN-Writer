using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCN.Core.Interfaces;
using FCN.Core.ViewModels;
using FCN.Pages;
using Windows.UI.Xaml.Controls;

namespace FCN.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> viewModelsToViews = new();
        public Frame View;

        public NavigationService()
        {
            RegisterViewForViewModel(typeof(HomeViewModel), typeof(HomePage));
            RegisterViewForViewModel(typeof(EditorViewModel), typeof(EditorPage));
            RegisterViewForViewModel(typeof(ArticlePropertyViewModel), typeof(ArticlePropertiesPage));
            RegisterViewForViewModel(typeof(PublisherViewModel), typeof(PublisherPage));
            RegisterViewForViewModel(typeof(LogInViewModel), typeof(LogInPage));
        }

        public void RegisterViewForViewModel(Type viewmodel, Type view) => viewModelsToViews[viewmodel] = view;

        public void NavigateTo<T>(int Token) => View.Navigate(viewModelsToViews[typeof(T)], Token);
        public void NavigateTo<T>() => View.Navigate(viewModelsToViews[typeof(T)]);
    }
}

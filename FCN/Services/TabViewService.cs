using CommunityToolkit.Mvvm.Input;
using FCN.Core.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FCN.Services
{
    public class TabViewService
    {
        public ObservableCollection<ArticleViewModel> Tabs = new();

        private RelayCommand? addCommand;
        public IRelayCommand AddCommand => addCommand ??= new RelayCommand(Add);
        private void Add() => Tabs.Add(App.Current.Services.GetService<ArticleViewModel>());

        public void RemoveRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            Tabs.Remove((ArticleViewModel)args.Item);
            if (Tabs.Count == 0)
                Add();
        }
    }
}

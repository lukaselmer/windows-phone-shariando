using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Phone.Tasks;
using Shariando.Gui.WP7.Helpers;
using Shariando.Services;
using Shariando.Services.Interfaces;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Gui.WP7.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {

        public ItemViewModel(IShop shop, ShariandoService shariandoService)
        {
            _shariandoService = shariandoService;
            Shop = shop;
            UpdateAttributes();
            InitCommands();
        }

        private void InitCommands()
        {
            OpenShopCommand = new Command(OpenShop);
        }

        private void OpenShop(object obj)
        {
            _shariandoService.UrlForShop(_shariandoService.Email, Shop, OpenShopSuccess, OpenShopError);
        }

        private void OpenShopSuccess(string url)
        {
            ExecuteOnUIThread(() =>
            {
                var webBrowserTask = new WebBrowserTask { Uri = new Uri(url, UriKind.Absolute) };
                webBrowserTask.Show();
                ErrorMessage = "";
                Loading = false;
            });
        }

        private void OpenShopError(ShariandoException ex)
        {
            ExecuteOnUIThread(() =>
            {
                Loading = false;
                ErrorMessage = ex.ErrorMessage;
            });
        }

        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set { _loading = value; NotifyPropertyChanged("Loading"); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            private set { _errorMessage = value; NotifyPropertyChanged("ErrorMessage"); NotifyPropertyChanged("DisplayMessage"); }
        }

        public bool DisplayMessage { get { return !String.IsNullOrEmpty(ErrorMessage); } }

        private void UpdateAttributes()
        {
            Id = Shop.Id;
            NotifyPropertyChanged("Id");
            Name = Shop.Name;
            NotifyPropertyChanged("Name");
            Description = Shop.Description;
            NotifyPropertyChanged("Description");
            Cashback = Shop.Cashback;
            NotifyPropertyChanged("Cashback");
            ImageUrl = Shop.ImageUrl;
            NotifyPropertyChanged("ImageUrl");
        }

        public ICommand OpenShopCommand { get; private set; }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Cashback { get; private set; }
        public string ImageUrl { get; private set; }

        private IShop _shop;
        private ShariandoService _shariandoService;

        public IShop Shop
        {
            get { return _shop; }
            set
            {
                if (value == _shop) return;
                _shop = value;
                UpdateAttributes();
                NotifyPropertyChanged("Shop");
            }
        }
    }
}
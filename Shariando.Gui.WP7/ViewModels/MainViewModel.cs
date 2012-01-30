using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Collections.ObjectModel;
using Shariando.Services;
using Shariando.Services.Interfaces;

namespace Shariando.Gui.WP7.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ServerFacade _serverFacade = new ServerFacade();

        public MainViewModel()
        {
            _serverFacade.CheckEmail("lukas.elmer@renuo.ch", UpdateItems, exception => { });
            _loading = false;
            Items = new ObservableCollection<ItemViewModel>();
        }

        private void UpdateItems(IList<IShop> shops)
        {
            ExecuteOnUIThread(() =>
            {
                Items.Clear();
                foreach (var shop in shops)
                {
                    Items.Add(new ItemViewModel(shop));
                }
            });
        }

        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set { _loading = value; NotifyPropertyChanged("Loading"); }
        }

        private bool _enterEmail;
        public bool EnterEmail
        {
            get { return _enterEmail; }
            set { _enterEmail = value; NotifyPropertyChanged("EnterEmail"); }
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded { get; private set; }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            Items.Add(new ItemViewModel(new Shop { Id = 12, Name = "DeinDeal.ch", ImageName = "a1d0c6e83f027327d8461063f4ac58a6.gif" }));
            IsDataLoaded = true;
        }
    }
}
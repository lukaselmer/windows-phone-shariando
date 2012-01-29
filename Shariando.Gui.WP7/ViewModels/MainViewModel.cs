using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using Shariando.Services;
using Shariando.Services.Interfaces;

namespace Shariando.Gui.WP7.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ServerFacade _serverFacade = new ServerFacade();

        public MainViewModel()
        {
            _serverFacade.CheckEmail("lukas.elmer@renuo.ch", UpdateItems, exception => { });
            Items = new ObservableCollection<ItemViewModel>();
        }

        private void UpdateItems(IList<IShop> shops)
        {

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                Items.Clear();
                foreach (var shop in shops)
                {
                    Items.Add(new ItemViewModel(shop));
                }
            });
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            Items.Add(new ItemViewModel(new Shop { Id = 12, Name = "DeinDeal.ch", ImageName = "a1d0c6e83f027327d8461063f4ac58a6.gif" }));
            IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
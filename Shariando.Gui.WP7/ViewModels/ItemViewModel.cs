using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Shariando.Services.Interfaces;

namespace Shariando.Gui.WP7
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        public ItemViewModel(IShop shop)
        {
            Shop = shop;
            UpdateAttributes();
        }

        private void UpdateAttributes()
        {
            Id = Shop.Id;
            Name = Shop.Name;
            Description = Shop.Description;
            Cashback = Shop.Cashback;
            ImageUrl = Shop.ImageUrl;
            NotifyPropertyChanged("Id");
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Description");
            NotifyPropertyChanged("Cashback");
            NotifyPropertyChanged("ImageUrl");
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Cashback { get; private set; }
        public string ImageUrl { get; private set; }

        private IShop _shop;
        public IShop Shop
        {
            get
            {
                return _shop;
            }
            set
            {
                if (value != _shop)
                {
                    _shop = value;
                    UpdateAttributes();
                    NotifyPropertyChanged("Shop");
                }
            }
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
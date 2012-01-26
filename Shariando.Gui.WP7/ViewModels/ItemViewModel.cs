using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            Name = Shop.Name;
            ImageUrl = Shop.ImageUrl;
            Image = Shop.Image;
            Id = Shop.Id;
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("ImageUrl");
            NotifyPropertyChanged("Image");
            NotifyPropertyChanged("Id");
        }

        public int Id { get; private set; }
        public string ImageUrl { get; private set; }
        public BitmapImage Image { get; private set; }
        public string Name { get; private set; }

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
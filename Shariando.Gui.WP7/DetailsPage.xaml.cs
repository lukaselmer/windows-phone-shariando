﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace Shariando.Gui.WP7
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex;
            if (!NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex)) return;
            var index = int.Parse(selectedIndex);
            DataContext = App.ViewModel.Items[index];
        }

        /*private void OpenShariandoShop(object sender, RoutedEventArgs e)
        {
            var webBrowserTask = new WebBrowserTask { Uri = new Uri("https://ch.shariando.com/users/new?locale=de", UriKind.Absolute) };
            webBrowserTask.Show();
        }*/

    }
}
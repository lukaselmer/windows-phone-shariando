using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Shariando.Gui.WP7.ViewModels
{
    public class LoadingOverlayViewModel : ViewModelBase
    {
        private bool _loading = true;
        public Boolean Loading
        {
            get { return _loading; }
            set { _loading = value; NotifyPropertyChanged("Loading"); }
        }
    }
}

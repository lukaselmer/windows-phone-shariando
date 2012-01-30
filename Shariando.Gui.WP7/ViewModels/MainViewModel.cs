using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Shariando.Gui.WP7.Helpers;
using Shariando.Services;
using Shariando.Services.Interfaces;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Gui.WP7.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ServerFacade _serverFacade = new ServerFacade();

        public MainViewModel()
        {
            //_serverFacade.CheckEmail("lukas.elmer@renuo.ch", CheckEmailSuccess, exception => { });
            Items = new ObservableCollection<ItemViewModel>();
            InitCommands();
        }

        private void InitCommands()
        {
            LoginCommand = new Command(CheckEmail, o => EnterEmail);
        }

        private void CheckEmail(object obj)
        {
            Loading = true;
            EnterEmail = false;
            _serverFacade.CheckEmail(Email, CheckEmailSuccess, CheckEmailError);
        }

        private void CheckEmailError(ShariandoException ex)
        {
            ExecuteOnUIThread(() =>
            {
                Loading = false;
                EnterEmail = true;
                ErrorMessage = ex.ErrorMessage;
            });
        }

        public ICommand LoginCommand { get; private set; }

        private void CheckEmailSuccess(IList<IShop> shops)
        {
            ExecuteOnUIThread(() =>
            {
                Loading = false;
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

        private bool _enterEmail = true;
        public bool EnterEmail
        {
            get { return _enterEmail; }
            set { _enterEmail = value; NotifyPropertyChanged("EnterEmail"); }
        }

        private string _email = "lukas.elmer@renuo.c";
        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged("Email"); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; NotifyPropertyChanged("ErrorMessage"); }
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
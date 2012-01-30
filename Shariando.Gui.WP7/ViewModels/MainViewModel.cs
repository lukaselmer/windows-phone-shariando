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
        private readonly ShariandoService _shariandoService = new ShariandoService();
        private string _email = "lukas.elmer@renuo.c";
        private bool _enterEmail = true;
        private string _errorMessage;
        private bool _loading;

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            Email = _shariandoService.Email;
            if (Email != ShariandoService.DefaultEmail)
            {
                _shariandoService.CheckEmail(Email, CheckEmailSuccess, CheckEmailError);
                EnterEmail = false;
                Loading = true;
            }
            InitCommands();
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                NotifyPropertyChanged("Loading");
            }
        }

        public bool EnterEmail
        {
            get { return _enterEmail; }
            set
            {
                _enterEmail = value;
                NotifyPropertyChanged("EnterEmail");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded { get; private set; }

        private void InitCommands()
        {
            LoginCommand = new Command(CheckEmail);
            LogoutCommand = new Command(Logout);
        }

        private void Logout(object obj)
        {
            _shariandoService.Logout();
            Items.Clear();
            EnterEmail = true;
            Email = _shariandoService.Email;
        }

        private void CheckEmail(object obj)
        {
            Loading = true;
            EnterEmail = false;
            _shariandoService.CheckEmail(Email, CheckEmailSuccess, CheckEmailError);
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

        private void CheckEmailSuccess(IList<IShop> shops)
        {
            ExecuteOnUIThread(() =>
                                  {
                                      ErrorMessage = "";
                                      Loading = false;
                                      Items.Clear();
                                      foreach (var shop in shops)
                                      {
                                          Items.Add(new ItemViewModel(shop, _shariandoService));
                                      }
                                  });
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            IsDataLoaded = true;
        }
    }
}
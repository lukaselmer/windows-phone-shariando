using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Shariando.Services.Interfaces;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Services
{
    public class ShariandoService : IShariandoService
    {
        public static readonly string DefaultEmail = "Email";
        private readonly ServerFacade _serverFacade = new ServerFacade();
        private IsolatedStorageSettings _settings;

        #region Implementation of IShariandoService

        public ShariandoService()
        {
            _settings = IsolatedStorageSettings.ApplicationSettings;
            Email = LoadEmail();
        }

        public string Email { get; set; }

        protected IServerFacade ServerFacade
        {
            get { return _serverFacade; }
        }

        protected void SaveEmail(string email)
        {
            Email = email;
            if (_settings.Contains("email")) _settings.Remove("email");
            _settings.Add("email", email);
            _settings.Save();
        }

        protected string LoadEmail()
        {
            return _settings.Contains("email") ? _settings["email"].ToString() : DefaultEmail;
        }

        #endregion

        public void CheckEmail(string email, Action<IList<IShop>> onSuccess, Action<ShariandoException> onError)
        {
            _serverFacade.CheckEmail(email, list =>
                                                {
                                                    SaveEmail(email);
                                                    onSuccess(list);
                                                }, onError);
        }

        public void UrlForShop(string email, IShop shop, Action<string> onSuccess, Action<ShariandoException> onError)
        {
            _serverFacade.UrlForShop(email, shop, onSuccess, onError);
        }

        public void Logout()
        {
            Email = DefaultEmail;
            _settings.Clear();
        }
    }
}
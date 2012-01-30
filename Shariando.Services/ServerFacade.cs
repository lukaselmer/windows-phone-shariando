using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Shariando.Services.Interfaces;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Services
{
    public class ServerFacade : IServerFacade
    {
        #region IServerFacade Members

        public void CheckEmail(string email, Action<IList<IShop>> shopsChanged, Action<ShariandoException> onError)
        {
            string url = string.Format("https://shariando.com/shops.json?email={0}", HttpUtility.UrlEncode(email));
            SendRequest<IList<Shop>>(url, list => shopsChanged(list.Cast<IShop>().ToList()), onError);
        }

        #endregion

        protected void SendRequest<T>(string url, Action<T> onSuccess, Action<ShariandoException> onError)
        {
            new JsonWebRequest<T>(url, onSuccess, onError);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Shariando.Services.Interfaces;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Services
{
    public class ServerFacade : IServerFacade
    {
        #region IServerFacade Members

        public void CheckEmail(string email, Action<IList<IShop>> shopsChanged, Action<ShariandoException> onError)
        {
            var url = string.Format("https://shariando.com/shops.json?email={0}", HttpUtility.UrlEncode(email));
            SendRequest<IList<Shop>>(url, list => shopsChanged(list.Cast<IShop>().ToList()), onError);
        }

        #endregion

        protected void SendRequest<T>(string url, Action<T> onSuccess, Action<ShariandoException> onError)
        {
            new JsonWebRequest<T>(url, onSuccess, onError);
        }

        public void UrlForShop(string email, IShop shop, Action<string> onSuccess, Action<ShariandoException> onError)
        {
            var url = string.Format("http://shariando.com/shops/{1}.json?email={0}&to_shop=1", HttpUtility.UrlEncode(email), shop.Id);
            SendRequest<RedirectTo>(url, redirectTo => onSuccess(redirectTo.Url), onError);
        }
    }
    [DataContract]
    public class RedirectTo
    {
        [DataMember(Name = "redirect_to")]
        public string Url { get; set; }
    }
}
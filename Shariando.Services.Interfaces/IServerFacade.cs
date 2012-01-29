using System;
using System.Collections.Generic;

namespace Shariando.Services.Interfaces
{
    public interface IServerFacade
    {
        void CheckEmail(string email, Action<IList<IShop>> shopsChanged, Action<Exception> onError);
        //IList<IShop> LoadList(string email);
        //string LinkForShop(IShop shop);
    }
}
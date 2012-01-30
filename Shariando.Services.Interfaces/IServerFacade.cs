using System;
using System.Collections.Generic;
using Shariando.Services.Interfaces.Exceptions;

namespace Shariando.Services.Interfaces
{
    public interface IServerFacade
    {
        void CheckEmail(string email, Action<IList<IShop>> shopsChanged, Action<ShariandoException> onError);
        //IList<IShop> LoadList(string email);
        //string LinkForShop(IShop shop);
    }
}
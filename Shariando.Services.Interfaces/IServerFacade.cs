using System.Collections.Generic;

namespace Shariando.Services.Interfaces
{
    public interface IServerFacade
    {
        bool CheckEmail(string email);
        IList<IShop> LoadList(string email);
        string LinkForShop(IShop shop);
    }
}
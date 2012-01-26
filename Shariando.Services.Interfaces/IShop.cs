using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Shariando.Services.Interfaces
{
    public interface IShop
    {
        int Id { get; }

        string Name { get; }

        string Description { get; }

        string Cashback { get; }

        string ImageName { get; }

        string ImageUrl { get; }
    }
}
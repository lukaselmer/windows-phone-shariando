using System.Runtime.Serialization;

namespace Shariando.Services.Interfaces
{
    public interface IShop
    {
         int Id { get; set; }

         string Name { get; set; }

         string ImageName { get; set; }
    }
}
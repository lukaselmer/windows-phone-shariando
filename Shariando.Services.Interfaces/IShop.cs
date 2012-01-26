using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Shariando.Services.Interfaces
{
    public interface IShop
    {
        int Id { get; set; }

        string Name { get; set; }

        string ImageName { get; set; }

        string ImageUrl { get; }

        BitmapImage Image { get; }
    }
}
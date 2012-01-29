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
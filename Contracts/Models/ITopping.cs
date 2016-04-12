using System;
namespace Contracts
{
    public interface ITopping
    {
        string ImageUrl { get; set; }
        decimal Price { get; set; }
        string ToppingDescription { get; set; }
        int ToppingID { get; set; }
    }
}

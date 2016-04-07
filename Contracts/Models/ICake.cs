using System;
namespace Contracts
{
    public interface ICake
    {
        string CakeDescription { get; set; }
        int CakeID { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
    }
}

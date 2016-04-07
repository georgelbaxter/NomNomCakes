using System;
namespace Contracts
{
    public interface IBasketItem
    {
        Guid BasketID { get; set; }
        int BasketItemID { get; set; }
        int CakeID { get; set; }
        ICake ICake { get; set; }
        int Quantity { get; set; }
    }
}

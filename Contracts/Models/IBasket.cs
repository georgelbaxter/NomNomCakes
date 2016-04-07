using System;
using System.Collections.Generic;
namespace Contracts
{
    public interface IBasket
    {
        Guid BasketID { get; set; }
        ICollection<IBasketCoupon> IBasketCoupons { get; }
        ICollection<IBasketItem> IBasketItems { get; }
        DateTime OrderDate { get; set; }

        void AddBasketCoupon(IBasketCoupon coupon);
        void AddBasketItem(IBasketItem item);

        decimal BasketTotal();
        decimal BasketItemCount();
    }
}

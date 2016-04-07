using System;
namespace Contracts.Modules
{
    public interface IeCoupon
    {
        void ProcessVoucher(Contracts.ICoupon coupon, Contracts.IBasket basket, Contracts.IBasketCoupon basketCoupon);
    }
}

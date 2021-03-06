using Contracts;
using Contracts.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Coupons.MoneyOff
{
    public class eCoupon : IeCoupon
    {
        public void ProcessVoucher(ICoupon coupon, IBasket basket, IBasketCoupon basketCoupon)
        {
            if (coupon.MinSpend < basket.BasketTotal())
            {
                basketCoupon.Value = coupon.Value;
                basketCoupon.CouponCode = coupon.CouponCode;
                basketCoupon.CouponDescription = coupon.CouponDescription;
                basketCoupon.CouponId = coupon.CouponId;
                basket.AddBasketCoupon(basketCoupon);
            }
        }
    }
}

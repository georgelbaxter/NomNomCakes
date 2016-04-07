using Contracts;
using Contracts.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Coupons.PercentOff
{
    public class eCoupon : IeCoupon
    {

        public void ProcessCoupon(ICoupon coupon, IBasket basket, IBasketCoupon basketCoupon)
        {
            if (coupon.MinSpend < basket.BasketTotal())
            {
                basketCoupon.Value = coupon.Value * (basket.BasketTotal() / 100);
                basketCoupon.CouponCode = coupon.CouponCode;
                basketCoupon.CouponDescription = coupon.CouponDescription;
                basketCoupon.CouponId = coupon.CouponId;
                basket.AddBasketCoupon(basketCoupon);
            }


        }
    }
}

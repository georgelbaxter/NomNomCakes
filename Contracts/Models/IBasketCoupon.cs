using System;
namespace Contracts
{
    public interface IBasketCoupon
    {
        int AppliesToProductId { get; set; }
        int BasketCouponID { get; set; }
        Guid BasketID { get; set; }
        string CouponCode { get; set; }
        string CouponDescription { get; set; }
        int CouponId { get; set; }
        string CouponType { get; set; }
        decimal Value { get; set; }
    }
}

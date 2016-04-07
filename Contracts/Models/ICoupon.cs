using System;
namespace Contracts
{
    public interface ICoupon
    {
        int AppliesToProductId { get; set; }
        string AssignedTo { get; set; }
        string CouponCode { get; set; }
        string CouponDescription { get; set; }
        int CouponId { get; set; }
        int CouponTypeId { get; set; }
        decimal MinSpend { get; set; }
        bool MultipleUse { get; set; }
        decimal Value { get; set; }
    }
}

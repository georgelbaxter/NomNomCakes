using System;
namespace Contracts
{
    public interface ICouponType
    {
        string CouponModule { get; set; }
        int CouponTypeId { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}

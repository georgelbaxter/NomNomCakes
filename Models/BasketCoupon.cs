using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketCoupon
    {
        public int BasketCouponID { get; set; }
        public int CouponID { get; set; }
        public Guid BasketID { get; set; }

        [MaxLength(10)]
        public string CouponCode { get; set; }
        [MaxLength(100)]
        public string CouponType { get; set; }
        public decimal Value { get; set; }
        [MaxLength(150)]
        public string CouponDescription { get; set; }
        public int AppliesToProductId { get; set; }
    }
}
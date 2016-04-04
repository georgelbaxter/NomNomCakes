using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public DbSet<Cake> Cake { get; set; }
        public DbSet<Icing> Icing { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<BasketCoupon> CouponVouchers { get; set; }
        public DbSet<CouponType> CouponTypes { get; set; }
    }
}

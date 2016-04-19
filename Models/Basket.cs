using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Basket : IBasket
    {

        private List<BasketItem> _basketItems;
        private List<BasketCoupon> _basketCoupons;

        public Guid BasketID { get; set; }
        public DateTime OrderDate { get; set; }

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
            this.BasketCoupons = new List<BasketCoupon>();
        }

        public decimal BasketTotal()
        {
            decimal total = (from item in BasketItems
                              select (int?)item.Quantity * (item.Cake.Price + item.Icing.Price + item.Topping.Price)).Sum() ?? 0;
            total += (from item in BasketCoupons
                      select item.Value).Sum();
            return total;
        }

        public decimal BasketItemCount()
        {
            return _basketItems.Count();
        }

        public virtual ICollection<IBasketItem> IBasketItems { get { return _basketItems.ConvertAll(i => (IBasketItem)i); } }
        public virtual ICollection<BasketItem> BasketItems { get { return _basketItems; } set { _basketItems = value.ToList(); } }
        public virtual ICollection<IBasketCoupon> IBasketCoupons { get { return _basketCoupons.ConvertAll(i => (IBasketCoupon)i); } }
        public virtual ICollection<BasketCoupon> BasketCoupons { get { return _basketCoupons; } set { _basketCoupons = value.ToList(); } }


        public void AddBasketItem(IBasketItem item)
        {
            _basketItems.Add((BasketItem)item);
        }
        public void AddBasketCoupon(IBasketCoupon coupon)
        {
            _basketCoupons.Add((BasketCoupon)coupon);
        }
    }
}

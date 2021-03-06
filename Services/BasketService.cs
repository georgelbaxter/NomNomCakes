using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Models;

namespace Services
{
    public class BasketService
    {
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketItems;
        private IRepositoryBase<Coupon> coupons;
        private IRepositoryBase<CouponType> couponTypes;
        private IRepositoryBase<BasketCoupon> basketCoupons;

        public const string BasketSessionName = "eShoppingBasket";

        public BasketService(IRepositoryBase<BasketItem> basketItems, IRepositoryBase<Basket> baskets, IRepositoryBase<Coupon> coupons, IRepositoryBase<BasketCoupon> basketCoupons, IRepositoryBase<CouponType> couponTypes)
        {
            this.baskets = baskets;
            this.coupons = coupons;
            this.basketCoupons = basketCoupons;
            this.couponTypes = couponTypes;
            this.basketItems = basketItems;
        }

        #region Basket methods
        private Basket createNewBasket(HttpContextBase httpContext)
        {
            //create a new basket.

            //first create a new cookie.
            HttpCookie cookie = new HttpCookie(BasketSessionName);
            //now create a new basket and set the creation date.
            Basket basket = new Basket();
            basket.OrderDate = DateTime.Now;
            basket.BasketID = Guid.NewGuid();

            //add and persist in the dabase.
            baskets.Insert(basket);
            baskets.Commit();

            //add the basket id to a cookie
            cookie.Value = basket.BasketID.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public bool AddToBasket(HttpContextBase httpContext, int cakeID, int icingID, int toppingID, int quantity = 1)
        {
            bool success = true;
            Basket basket = GetBasket(httpContext);

            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.CakeID == cakeID && i.IcingID == icingID && i.ToppingID == toppingID);
            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketID = basket.BasketID,
                    CakeID = cakeID,
                    IcingID = icingID,
                    ToppingID = toppingID,
                    Quantity = quantity
                };
                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + quantity;
            }
            baskets.Commit();
            return success;
        }

        public Basket GetBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket = null;
            Guid basketId;
            if (cookie != null && Guid.TryParse(cookie.Value, out basketId))
            {
                basket = baskets.GetById(basketId);
            }
            return basket ?? createNewBasket(httpContext);
        }

        public bool DeleteFromBasket(HttpContextBase httpContext, int basketItemId)
        {
            bool success = true;
            Basket basket = GetBasket(httpContext);

            if (!basket.BasketItems.Select(i => i.BasketItemID).Contains(basketItemId))
            {
                success = false;
            }
            else
            {
                basketItems.Delete(basketItemId);
                basketItems.Commit();
            }
            return success;
        }

        public void Clear(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext);

            foreach (BasketItem item in basket.BasketItems)
            {
                basketItems.Delete(item.BasketItemID);
            }
            foreach (BasketCoupon coupon in basket.BasketCoupons)
            {
                basketCoupons.Delete(coupon.BasketCouponID);
            }
            baskets.Delete(basket.BasketID);
            baskets.Commit();
        }

        public bool SetQuantity(HttpContextBase httpContext, int basketItemID, int quantity)
        {
            bool success = true;
            Basket basket = GetBasket(httpContext);

            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.BasketItemID == basketItemID);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    basketItems.Delete(item.BasketItemID);
                    basketItems.Commit();
                }
                baskets.Commit();
            }
            else
                success = false;

            return success;
        }

        #endregion

        #region Coupon Methods
        public void AddCoupon(string couponCode, HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext);
            Coupon coupon = coupons.GetAll().FirstOrDefault(c=>c.CouponCode==couponCode);
            if (coupon!=null)
            {
                CouponType couponType = couponTypes.GetById(coupon.CouponTypeId);
                if (couponType!=null)
                {
                    BasketCoupon basketCoupon = new BasketCoupon();
                    if (couponType.Type=="MoneyOff")
                    {
                        MoneyOff(coupon, basket, basketCoupon);
                    }
                    if (couponType.Type=="PercentOff")
                    {
                        PercentOff(coupon, basket, basketCoupon);
                    }
                    baskets.Commit();
                }//end couponType if
            }//end coupon if
        }//end addCoupon

        private void MoneyOff(Coupon coupon, Basket basket, BasketCoupon basketCoupon)
        {
            decimal basketTotal = basket.BasketTotal();
            if (coupon.MinSpend <= basketTotal)
            {
                basketCoupon.Value = coupon.Value * -1;
                basketCoupon.CouponCode = coupon.CouponCode;
                basketCoupon.CouponDescription = coupon.CouponDescription;
                basketCoupon.CouponId = coupon.CouponId;
                basket.AddBasketCoupon(basketCoupon);
            }
        }

        private void PercentOff(Coupon coupon, Basket basket, BasketCoupon basketCoupon)
        {
            if (coupon.MinSpend <= basket.BasketTotal())
            {
                basketCoupon.Value = (coupon.Value * (basket.BasketTotal() / 100)) * -1;
                basketCoupon.CouponCode = coupon.CouponCode;
                basketCoupon.CouponDescription = coupon.CouponDescription;
                basketCoupon.CouponId = coupon.CouponId;
                basket.AddBasketCoupon(basketCoupon);
            }
        }
        #endregion
    }
}

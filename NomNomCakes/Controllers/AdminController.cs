using Contracts;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNomCakes.Controllers
{
    public class AdminController : Controller
    {
        public class HomeController : Controller
        {
            IRepositoryBase<Cake> cakes;
            IRepositoryBase<Icing> icings;
            IRepositoryBase<Topping> toppings;
            IRepositoryBase<Basket> baskets;
            IRepositoryBase<BasketItem> basketItem;
            IRepositoryBase<Coupon> coupons;
            IRepositoryBase<CouponType> couponTypes;
            IRepositoryBase<BasketCoupon> basketCoupons;
            BasketService basketService;
            public HomeController(IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings, IRepositoryBase<BasketItem> basketItem, IRepositoryBase<Basket> baskets, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<BasketCoupon> basketCoupons)
            {
                this.cakes = cakes;
                this.icings = icings;
                this.toppings = toppings;
                this.baskets = baskets;
                this.basketItem = basketItem;
                this.coupons = coupons;
                this.couponTypes = couponTypes;
                this.basketCoupons = basketCoupons;
                basketService = new BasketService(this.baskets, this.coupons, this.basketCoupons, this.couponTypes);
            }

            // GET: Admin
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult CakeList()
            {
                var model = cakes.GetAll();
                return View(model);
            }
            public ActionResult ToppingList()
            {
                var model = toppings.GetAll();
                return View(model);
            }
            public ActionResult IcingList()
            {
                var model = icings.GetAll();
                return View(model);
            }

        }
    }
}

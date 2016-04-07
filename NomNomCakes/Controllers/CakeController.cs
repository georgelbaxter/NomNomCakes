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
    public class ProductsController : Controller
    {
        IRepositoryBase<Cake> cakes;
        IRepositoryBase<Icing> icings;
        IRepositoryBase<Topping> toppings;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<Coupon> coupons;
        IRepositoryBase<CouponType> couponTypes;
        IRepositoryBase<BasketCoupon> basketCoupons;
        BasketService basketService;
        public ProductsController(IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings, IRepositoryBase<Basket> baskets, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<BasketCoupon> basketCoupons)
        {
            this.cakes = cakes;
            this.icings = icings;
            this.toppings = toppings;
            this.baskets = baskets;
            this.coupons = coupons;
            this.couponTypes = couponTypes;
            this.basketCoupons = basketCoupons;
            basketService = new BasketService(this.baskets, this.coupons, this.basketCoupons, this.couponTypes);
        }


        // GET: Cake
        public ActionResult Index()
        {
            return View();
        }
    }
}

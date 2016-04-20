using Contracts;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NomNomCakes.Extensions;

namespace NomNomCakes.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Cake> cakes;
        IRepositoryBase<Icing> icings;
        IRepositoryBase<Topping> toppings;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketItems;
        IRepositoryBase<Coupon> coupons;
        IRepositoryBase<CouponType> couponTypes;
        IRepositoryBase<BasketCoupon> basketCoupons;
        BasketService basketService;
        CakeBuilder cakeBuilder;
        public HomeController(IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings, IRepositoryBase<BasketItem> basketItems, IRepositoryBase<Basket> baskets, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<BasketCoupon> basketCoupons)
        {
            this.cakes = cakes;
            this.icings = icings;
            this.toppings = toppings;
            this.baskets = baskets;
            this.basketItems = basketItems;
            this.coupons = coupons;
            this.couponTypes = couponTypes;
            this.basketCoupons = basketCoupons;
            basketService = new BasketService(this.basketItems, this.baskets, this.coupons, this.basketCoupons, this.couponTypes);
            cakeBuilder = new CakeBuilder(System.Web.HttpContext.Current.Session, cakes, icings, toppings);
        }


        // GET: Cake
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CakeBase()
        {
            var model = cakes.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult PickCake(Cake cake)
        {
            cakeBuilder.CakeID = cake.CakeID;
            return RedirectToAction("Icing");
        }

        [HttpPost]
        public ActionResult PickIcing(Icing icing)
        {
            cakeBuilder.IcingID = icing.IcingID;
            return RedirectToAction("Topping");
        }

        [HttpPost]
        public ActionResult PickTopping(Topping topping)
        {
            cakeBuilder.ToppingID = topping.ToppingID;
            return RedirectToAction("YourCake");
        }

        public ActionResult AddToCart()
        {
            if (cakeBuilder.Ready())
            {
                basketService.AddToBasket(this.HttpContext, cakeBuilder.CakeID ?? 0, cakeBuilder.IcingID ?? 0, cakeBuilder.ToppingID ?? 0);
                cakeBuilder.Clear();
            }
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult SetQuantity(BasketItem item)
        {
            basketService.SetQuantity(this.HttpContext, item.BasketItemID, item.Quantity);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult DeleteBasketItem(int id)
        {
            basketService.DeleteFromBasket(this.HttpContext, id);
            return RedirectToAction("Cart");
        }

        public ActionResult ClearBasket()
        {
            basketService.Clear(this.HttpContext);
            return RedirectToAction("Cart");
        }


        public ActionResult YourCake()
        {
            ActionResult result;
            // If user hasn't picked all 3, send them back to the start
            if (cakeBuilder.Ready())
                result = View(cakeBuilder.CurrentItem());
            else
                result = RedirectToAction("CakeBase");
            return result;
        }

        public ActionResult Icing()
        {
            var model = icings.GetAll();
            return View(model);
        }

        public ActionResult Topping()
        {
            var model = toppings.GetAll();
            return View(model);
        }

        public ActionResult Cart()
        {
            var model = basketService.GetBasket(this.HttpContext);
            return View(model);
        }

        public ActionResult CakeStyle()
        {
            string model = cakeBuilder.BuildCakeImage();
            return View(model: model);
        }
        //add coupons
        public ActionResult AddBasketCoupon(string couponCode)
        {
            basketService.AddCoupon(couponCode, this.HttpContext);

            return RedirectToAction("Cart");
        }
    }
}

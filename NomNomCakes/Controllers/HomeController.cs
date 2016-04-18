using Contracts;
using MidTermSolution.Services;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNomCakes.Controllers
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
        CakeBuilder cakeBuilder;
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
            cakeBuilder = new CakeBuilder(Session, cakes, icings, toppings);
            cakeBuilder.CakeID = cake.CakeID;
            return RedirectToAction("Icing");
        }
        public ActionResult PickCake(int id)
        {
            return RedirectToAction("Icing");
        }

        public ActionResult Icing()
        {
            cakeBuilder = new CakeBuilder(Session, cakes, icings, toppings);
            ViewBag.CakeBackground = buildCakeImage(cakeBuilder);
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
            var model = basketItem.GetAll();
            return View(model);
        }

        private string buildCakeImage(CakeBuilder cakeBuilder)
        {
            string imageURL = string.Empty;
            if (cakeBuilder.Cake != null)
                imageURL += "url(/Content/Images/" + cakeBuilder.Cake.ImageUrl + ")";
            if (cakeBuilder.Icing != null)
                imageURL += (imageURL == string.Empty ? "" : ", ") + "url(/Content/Images/" + cakeBuilder.Icing.ImageUrl + ")";
            if (cakeBuilder.Topping != null)
                imageURL += (imageURL == string.Empty ? "" : ", ") + "url(/Content/Images/" + cakeBuilder.Topping.ImageUrl + ")";
            return imageURL;
        }
    }
}

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

        IRepositoryBase<Cake> cakes;
        IRepositoryBase<Icing> icings;
        IRepositoryBase<Topping> toppings;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketItem;
        IRepositoryBase<Coupon> coupons;
        IRepositoryBase<CouponType> couponTypes;
        IRepositoryBase<BasketCoupon> basketCoupons;
        BasketService basketService;
        public AdminController(IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings, IRepositoryBase<BasketItem> basketItem, IRepositoryBase<Basket> baskets, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<BasketCoupon> basketCoupons)
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

        #region Cake CRUD
        public ActionResult CakeList()
        {
            var model = cakes.GetAll();
            return View(model);
        }

        public ActionResult CakeCreate()
        {
            var model = new Cake();
            return View(model);
        }

        [HttpPost]
        public ActionResult CakeCreate(Cake cake)
        {
            cakes.Insert(cake);
            cakes.Commit();
            return RedirectToAction("CakeList");
        }
        public ActionResult CakeEdit(int id)
        {
            Cake cake = cakes.GetById(id);
            return View(cake);
        }
        [HttpPost]
        public ActionResult CakeEdit(Cake cake)
        {
            cakes.Update(cake);
            cakes.Commit();
            return View(cake);
        }

        public ActionResult CakeDetails(int id)
        {
            var cake = cakes.GetById(id);
            return View(cake);
        }

        public ActionResult CakeDelete(int id)
        {
            Cake cake = cakes.GetById(id);
            if (cakes == null)
            {
                return HttpNotFound();
            }
            return View(cake);
        }

        [HttpPost, ActionName("CakeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCakeConfirm(int id)
        {
            cakes.Delete(cakes.GetById(id));
            cakes.Commit();
            return RedirectToAction("CakeList");
        }
        #endregion

        #region Icing CRUD
        public ActionResult IcingList()
        {
            var model = icings.GetAll();
            return View(model);
        }

        public ActionResult IcingCreate()
        {
            var model = new Icing();
            return View(model);
        }

        [HttpPost]
        public ActionResult IcingCreate(Icing icing)
        {
            icings.Insert(icing);
            icings.Commit();
            return RedirectToAction("IcingList");
        }
        public ActionResult IcingEdit(int id)
        {
            Icing icing = icings.GetById(id);
            return View(icing);
        }
        [HttpPost]
        public ActionResult IcingEdit(Icing icing)
        {
            icings.Update(icing);
            icings.Commit();
            return View(icing);
        }

        public ActionResult IcingDetails(int id)
        {
            var icing = icings.GetById(id);
            return View(icing);
        }

        public ActionResult IcingDelete(int id)
        {
            Icing icing = icings.GetById(id);
            if (icings == null)
            {
                return HttpNotFound();
            }
            return View(icing);
        }

        [HttpPost, ActionName("IcingDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIcingConfirm(int id)
        {
            icings.Delete(icings.GetById(id));
            icings.Commit();
            return RedirectToAction("IcingList");
        }
        #endregion

        #region Topping CRUD
        public ActionResult ToppingList()
        {
            var model = toppings.GetAll();
            return View(model);
        }

        public ActionResult ToppingCreate()
        {
            var model = new Topping();
            return View(model);
        }

        [HttpPost]
        public ActionResult ToppingCreate(Topping topping)
        {
            toppings.Insert(topping);
            toppings.Commit();
            return RedirectToAction("ToppingList");
        }
        public ActionResult ToppingEdit(int id)
        {
            Topping topping = toppings.GetById(id);
            return View(topping);
        }
        [HttpPost]
        public ActionResult ToppingEdit(Topping topping)
        {
            toppings.Update(topping);
            toppings.Commit();
            return View(topping);
        }

        public ActionResult ToppingDetails(int id)
        {
            var topping = toppings.GetById(id);
            return View(topping);
        }

        public ActionResult ToppingDelete(int id)
        {
            Topping topping = toppings.GetById(id);
            if (toppings == null)
            {
                return HttpNotFound();
            }
            return View(topping);
        }
        [HttpPost, ActionName("ToppingDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteToppingConfirm(int id)
        {
            toppings.Delete(toppings.GetById(id));
            toppings.Commit();
            return RedirectToAction("ToppingList");
        }
        #endregion

    }
}

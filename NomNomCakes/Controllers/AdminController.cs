using Contracts;
using Models;
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
        public AdminController(IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings)
        {
            this.cakes = cakes;
            this.icings = icings;
            this.toppings = toppings;
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNomCakes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cake()
        {
            ViewBag.Message = "Your application cake page.";

            return View();
        }
        public ActionResult Icing()
        {
            ViewBag.Message = "Your application icing page.";

            return View();
        }
        public ActionResult Topping()
        {
            ViewBag.Message = "Your application toppings page.";

            return View();
        }       
    }
}
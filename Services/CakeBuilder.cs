using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Models;

namespace MidTermSolution.Services
{
    public class CakeBuilder
    {
        IRepositoryBase<Cake> cakes;
        IRepositoryBase<Icing> icings;
        IRepositoryBase<Topping> toppings;
        HttpSessionStateBase session;
        private int? cakeID;
        public int? CakeID
        {
            get { return cakeID; }
            set
            {
                cakeID = value;
                session["cakeID"] = value;
            }
        }
        private int? icingID;

        public int? IcingID
        {
            get { return icingID; }
            set
            {
                icingID = value;
                session["icingID"] = value;
            }
        }
        private int? toppingID;

        public int? ToppingID
        {
            get { return toppingID; }
            set
            {
                toppingID = value;
                session["toppingID"] = value;
            }
        }
        public Cake Cake { get; set; }
        public Icing Icing { get; set; }
        public Topping Topping { get; set; }

        public CakeBuilder(HttpContextBase httpContext, IRepositoryBase<Cake> cakes, IRepositoryBase<Icing> icings, IRepositoryBase<Topping> toppings)
        {
            this.cakes = cakes;
            this.icings = icings;
            this.toppings = toppings;
            session = httpContext.Session;

            if (session["cakeID"] != null)
            {
                cakeID = (int)session["cakeID"];
                Cake = cakes.GetById(cakeID);
            }
            if (session["icingID"] != null)
            {
                icingID = (int)session["icingID"];
                Icing = icings.GetById(icingID);
            }
            if (session["toppingID"] != null)
            {
                toppingID = (int)session["toppingID"];
                Topping = toppings.GetById(toppingID);
            }
        }

        public bool Ready()
        {
            return (cakeID != null && icingID != null && toppingID != null);
        }

        public BasketItem CurrentItem(int quantity = 1)
        {
            BasketItem item = new BasketItem();
            if (Ready())
            {
                item.CakeID = cakeID ?? 0;
                item.IcingID = icingID ?? 0;
                item.ToppingID = toppingID ?? 0;
                item.Cake = Cake ?? cakes.GetById(cakeID);
                item.Icing = Icing ?? icings.GetById(icingID);
                item.Topping = Topping ?? toppings.GetById(toppingID);
                item.Quantity = quantity;
            }

            return item;
        }

        public void Clear()
        {
            session.Remove("cakeID");
            session.Remove("icingID");
            session.Remove("toppingID");
            cakeID = null;
            icingID = null;
            toppingID = null;
        }

    }
}

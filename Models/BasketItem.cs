using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketItem : IBasketItem
    {
        private Cake _cake;
        private Icing _icing;
        private Topping _topping;
        public int BasketItemID { get; set; }
        public Guid BasketID { get; set; }
        public int CakeID { get; set; }
        public int IcingID { get; set; }
        public int ToppingID { get; set; }
        public int Quantity { get; set; }

        public virtual ICake ICake { get { return _cake as ICake; } set { _cake = value as Cake; } }
        public virtual Cake Cake { get { return _cake; } set { _cake = value; } }
        public virtual IIcing IIcing { get { return _icing as IIcing; } set { _icing = value as Icing; } }
        public virtual Icing Icing { get { return _icing; } set { _icing = value; } }
        public virtual ITopping ITopping { get { return _topping as ITopping; } set { _topping = value as Topping; } }
        public virtual Topping Topping { get { return _topping; } set { _topping = value; } }


    }
}

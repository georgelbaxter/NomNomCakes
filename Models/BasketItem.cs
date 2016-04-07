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
        public int BasketItemID { get; set; }
        public Guid BasketID { get; set; }
        public int CakeID { get; set; }
        public int Quantity { get; set; }

        public virtual ICake ICake { get { return _cake as ICake; } set { _cake = value as Cake; } }
        public virtual Cake Cake { get { return _cake; } set { _cake = value; } }

    }
}

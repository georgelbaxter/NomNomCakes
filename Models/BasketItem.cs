using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasketItem
    {
        public int BasketItemID { get; set; }
        public Guid BasketID { get; set; }
        public int CakeID { get; set; }
        public virtual Cake Cake { get; set; }
        public int Quantity { get; set; }
    }
}

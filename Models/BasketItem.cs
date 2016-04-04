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
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}

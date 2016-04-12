using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Topping : ITopping
    {
        public int ToppingID { get; set; }
        public string ToppingDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}

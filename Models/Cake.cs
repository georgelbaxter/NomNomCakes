using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cake : ICake
    {
        public int CakeID { get; set;}
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string CakeDescription { get; set;}

        Basket basket;
        BasketItem basketItem;
    }
}

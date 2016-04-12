using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Icing : IIcing
    {
        public int IcingID { get; set; }
        public string IcingDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}

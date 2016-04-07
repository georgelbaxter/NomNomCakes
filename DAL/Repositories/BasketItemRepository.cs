using DAL.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem>
    {
        public BasketItemRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}

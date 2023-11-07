using MyFirstWebApiSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal class OrderRepository : IOrderRepository
    {

        public Order addOrder(Order order)
        {
            using (var context = new ClothesShop326023306Context())
            {
                context.Orders.AddAsync(order);
                context.SaveChangesAsync();
            }
            return order;
        }
    }
}

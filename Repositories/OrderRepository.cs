using MyFirstWebApiSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ClothesShop326023306Context _clothesShop326023306Context;

        public OrderRepository(ClothesShop326023306Context clothesShop326023306Context)
        {
            _clothesShop326023306Context = clothesShop326023306Context;
        }

        async public Task<Order> addOrder(Order order)
        {
            await _clothesShop326023306Context.Orders.AddAsync(order);
            await _clothesShop326023306Context.SaveChangesAsync();
            return order;
        }

        async public Task<double> getItemPrice(OrderItem orderItem)
        {
            Product product= _clothesShop326023306Context.Products.Where(item => item.Id == orderItem.ProductId).FirstOrDefault();
            return product.Price;

        }
    }
}

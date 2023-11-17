using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ClothesShop326023306Context _clothesShop326023306Context;

        public ProductRepository(ClothesShop326023306Context clothesShop326023306Context)
        {
            _clothesShop326023306Context = clothesShop326023306Context;
        }

        async public Task<IEnumerable<Product>> GetAllProducts( string? desc, int? minPrice, int? maxPrice, int?[]categoryIds)
        {
            var query = _clothesShop326023306Context.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            List<Product> products = await query.ToListAsync();
            return products;
        }
    }
}

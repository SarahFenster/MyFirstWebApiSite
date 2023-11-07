using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ClothesShop326023306Context _clothesShop326023306Context;

        public CategoryRepository(ClothesShop326023306Context clothesShop326023306Context)
        {
            _clothesShop326023306Context = clothesShop326023306Context;
        }

        async public Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _clothesShop326023306Context.Categories.ToListAsync();
        }
    }
}

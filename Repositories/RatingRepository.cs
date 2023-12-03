using MyFirstWebApiSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ClothesShop326023306Context _clothesShop326023306Context;
        public RatingRepository(ClothesShop326023306Context clothesShop326023306Context)
        {
            _clothesShop326023306Context = clothesShop326023306Context;
        }
        async public Task<Rating> addRating(Rating rating)
        {
            await _clothesShop326023306Context.Rating.AddAsync(rating);
            await _clothesShop326023306Context.SaveChangesAsync();
            return rating;
        }
    }
}

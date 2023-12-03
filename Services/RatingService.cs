using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MyFirstWebApiSite;
using Repositories;

namespace Services
{
    public class RatingService : IRatingService
    {
        IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        async public Task<Rating> addRating(Rating rating)
        {
            return await _ratingRepository.addRating(rating);
        }

    }
}

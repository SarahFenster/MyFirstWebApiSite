using MyFirstWebApiSite;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        async public Task<IEnumerable<Product>> GetAllProducts( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.GetAllProducts(desc,minPrice,maxPrice,categoryIds);
        }
    }
}

using MyFirstWebApiSite;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}
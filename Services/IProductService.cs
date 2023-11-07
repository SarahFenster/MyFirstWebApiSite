using MyFirstWebApiSite;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
using MyFirstWebApiSite;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<double> getItemPrice(OrderItem orderItem);
    }
}
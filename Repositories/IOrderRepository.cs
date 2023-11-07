using MyFirstWebApiSite;

namespace Repositories
{
    internal interface IOrderRepository
    {
        Order addOrder(Order order);
    }
}
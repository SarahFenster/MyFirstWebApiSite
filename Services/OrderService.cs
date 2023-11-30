using Microsoft.Extensions.Logging;
using MyFirstWebApiSite;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        async public Task<Order> addOrder(Order order)
        {
            double orderSum = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                double sum = await _orderRepository.getItemPrice(item);
                sum *= item.Quantity;
                orderSum += sum;
            }
            if(order.OrderSum!=orderSum)
            {
                _logger.LogError($"Important warning, your attention is required: user {order.UserId} tried to steal you! he changed order price from {orderSum} to {order.OrderSum}");
                order.OrderSum = orderSum;
            }
            return await _orderRepository.addOrder(order); 
        }
    }
}

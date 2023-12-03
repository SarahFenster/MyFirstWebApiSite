using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
{
         IOrderService _orderServices;
        IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
    {
            _orderServices = orderService;
            _mapper = mapper;
    }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<OrdersController>
        [HttpPost]
        
            async public Task<ActionResult<User>> Post([FromBody] OrderDTO orderDTO)
            {
                try
                {
                    Order order = _mapper.Map<OrderDTO,Order>(orderDTO);
                    Order createdOrder = await _orderServices.addOrder(order);
                if (createdOrder != null)
                {
                    orderDTO.Id=createdOrder.Id;
                    return CreatedAtAction(nameof(Get), new {id = orderDTO.Id }, orderDTO);
                }   
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

    }
}

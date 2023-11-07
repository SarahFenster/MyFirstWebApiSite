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
    public OrdersController(IOrderService orderService)
    {
            _orderServices = orderService;
    }
    
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        
            async public Task<ActionResult<User>> Post([FromBody] Order order)
            {
                try
                {
                    Order createdOrder = await _orderServices.addOrder(order);
                    if (createdOrder != null)
                        return CreatedAtAction(nameof(Get), new {id = createdOrder.Id }, order);
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

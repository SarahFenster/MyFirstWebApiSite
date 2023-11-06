using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices userServices ;

        public UsersController(IUserServices iuserServices)
        {
            this.userServices = iuserServices;
        }

        // GET: api/<UsersController>
        [HttpGet("{id}")]
        async public Task<ActionResult> Get(int id)
        {

            User user = await userServices.getUserById(id);
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpPost("checkYourPass")]
        public ActionResult checkYourPass([FromBody] string password)
        {
            int result = userServices.validatePassword(password);
            return Ok(result);
        }

        // GET api/<UsersController>/
        [HttpGet]
        async public Task<ActionResult> Get([FromQuery] string email, [FromQuery] string password)
        {
            User user = await userServices.getUserByEmailAndPassword(email, password);
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
         public ActionResult Post([FromBody] User user)
        {
            try
            {
                user =  userServices.addUserToDB(user);
                if (user != null)
                    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            int result = await userServices.updateUserDetails(id, userToUpdate);
            if (result == 0)
                return Ok(User);
            if (result == 1)
                return NoContent();//which status should I return for easy password?
            return BadRequest();
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}

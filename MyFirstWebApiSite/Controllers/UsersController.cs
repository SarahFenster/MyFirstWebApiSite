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
        IUserServices _userServices ;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/<UsersController>
        [HttpGet("{id}")]
        async public Task<ActionResult<User>> Get(int id)
        {
            User user = await _userServices.getUserById(id);
             return user == null ? NoContent() : Ok(user);
        }

        [HttpPost("checkYourPass")]
         public ActionResult checkYourPass([FromBody] string password)
        {
            int result = _userServices.validatePassword(password);
            return Ok(result);
        }

        // GET api/<UsersController>/
        [HttpGet]
        async public Task<ActionResult> Get([FromQuery] string email, [FromQuery] string password)
        {
            User user = await _userServices.getUserByEmailAndPassword(email, password);
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
         async public Task<ActionResult<User>> Post([FromBody] User user)
        {
            try
            {
               User createdUser = await _userServices.addUserToDB(user);
                if (user != null)
                    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            var result = await _userServices.updateUserDetails(id, userToUpdate);
            return result != null ? Ok(User) : BadRequest();
        }

    }
}

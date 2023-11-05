using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices userServices;//_userService - convention 

        public UsersController(IUserServices iuserServices)
        {
            //IuserService userService (instead of  iuserService)
            this.userServices = iuserServices;
            //The this keyword is unnecessary.
        }

        // GET: api/<UsersController>
        [HttpGet("{id}")]
        async public Task<ActionResult> Get(int id)
        {
            //The function should return Task<ActionResult<User!!!>, You return the user- Ok(user)
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
            //suggestion for shorter and nicer code- user== null ? NoContent() : Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
         public ActionResult Post([FromBody] User user)
        {
            //async await??? The fuction should return Task<ActionResult<User>
            try
            {
                user =  userServices.addUserToDB(user);
                if (user != null)
                    //user.Id (User in Entity doesn't contain a definition for usreId)
                    return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
                return BadRequest();
            }
            catch (Exception ex)
            {   
                //error code 400 (BadRequest) is not suitable for server exceptions; use the 500 error code for internal server Error. 
                //return Status code 500 or throw an exception. 
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            // The fuction should return Task<ActionResult<User> 
            int result = await userServices.updateUserDetails(id, userToUpdate);
            //if updatedUser==null return BadRequest("easy password") else return Ok(updatedUser)
            if (result == 0)
                return Ok(User);
            if (result == 1)
                return NoContent();//which status should I return for easy password?
            return BadRequest();
        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}

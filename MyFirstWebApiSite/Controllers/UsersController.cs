using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json;
using Services;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices ;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserServices userServices, IMapper mapper, ILogger<UsersController> logger)
        {
            _userServices = userServices;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet("{id}")]
        async public Task<ActionResult<User>> Get(int id)
        {
            User user = await _userServices.getUserById(id);
            UserDTO userDTO= _mapper.Map< User, UserDTO>(user);
            return user == null ? NoContent() : Ok(userDTO);
        }

        [HttpPost("checkYourPass")]
         public ActionResult checkYourPass([FromBody] string password)
        {
            int result = _userServices.validatePassword(password);
            return Ok(result);
        }

        // POST api/<UsersController>/login
        [HttpPost("login")]
        async public Task<ActionResult> login([FromBody] UserLoginDTO userLoginDTO)
        {
                User user = await _userServices.getUserByEmailAndPassword(userLoginDTO.UserName, userLoginDTO.Password);
            if (user != null)
            {
                UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
                _logger.LogInformation($"Login attempted with User Name {userDTO.UserName} and password {userDTO.Password}");
                return Ok(userDTO);
            }   
            return NoContent();
            }
            

        // POST api/<UsersController>
        [HttpPost]
         async public Task<ActionResult<User>> Post([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            User createdUser = await _userServices.addUserToDB(user);
                if (createdUser != null)
            {
                userDTO.Id=createdUser.Id;
                return CreatedAtAction(nameof(Get), new { id = user.Id }, userDTO);
            }    
                return BadRequest(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<ActionResult<User>> Put(int id, [FromBody] UserDTO userToUpdate)
        {
            User user= _mapper.Map<UserDTO,User>(userToUpdate);
            user.Id=id;
            var result = await _userServices.updateUserDetails(id, user);
            if (result!=null)
                return Ok(userToUpdate);
            return BadRequest("Password is not strong enough");
        }

    }
}

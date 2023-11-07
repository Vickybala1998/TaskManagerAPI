using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;
using TaskManagerAPI.Repository;

namespace TaskManagerAPI.Controllers
{
    [Route("api/v1.0/TaskManager")]
    [ApiController]

    public class UserController :ControllerBase
    {
       public IUserRepository _userRepository { get; set; }
       public ILogger<UserController> _logger { get; set; }


        public UserController(IUserRepository userRepository,ILogger<UserController> logger) 
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet("user/all")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                
                return Ok(await _userRepository.GetAllUsers()) ;
                
            }
            catch(Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                if (ex is InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The Bad Request occur, please try after sometimes");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The error occur, please try after sometimes");
                }
               
            }
            
        }

        [HttpGet("user/search/{UserName}")]
        public async Task<ActionResult<User?>> GetUserById(string UserName)
        {
            try
            {
                return await _userRepository.GetUserById(UserName);
            }

            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                if (ex is InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The Bad Request occur, please try after sometimes");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The error occur, please try after sometimes");
                }

            }

        }

        [HttpPost("user/register")]
        public async Task<ActionResult> AddUser([FromForm] UserModel user)
        {
            //user.ImageFile = file;
            try
            {
                await _userRepository.AddUser(user);
                return Ok("User Added Successfully");
            }
            
            catch(Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                if (ex is InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The Bad Request occur, please try after sometimes");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The error occur, please try after sometimes");
                }

            }
        }

        [HttpDelete("user/remove")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            try
            {
                await _userRepository.RemoveUser(id);
                return Ok("User Removed Successfully");
            }
            
            catch(Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                if (ex is InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The Bad Request occur, please try after sometimes");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The error occur, please try after sometimes");
                }

            }
        }

        [HttpPut("user/update")]
        public async Task<ActionResult> UpdateUser([FromForm] UserModel user)
        {
            try
            {
                await _userRepository.UpdateUser(user);
                return Ok("User Added Successfully");
            }
            

            catch(Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                if (ex is InvalidOperationException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The Bad Request occur, please try after sometimes");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The error occur, please try after sometimes");
                }

            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> loginUser([FromBody]UserModel user)
        {
            bool isUserAvailable= await _userRepository.loginUser(user);
            if (isUserAvailable)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

    }
}

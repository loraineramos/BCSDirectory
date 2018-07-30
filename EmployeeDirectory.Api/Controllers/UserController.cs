using System;
using EmployeeDirectoryProcessor.Model;
using EmployeeDirectory.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]UserModel user)
        {
            try
            {
                //to do: add validation
                if (false)
                    return BadRequest();
                var userResponse = _userManager.CreateUser(user);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{username}")]
        public IActionResult Get(string userName)
        {
            try
            {
                //to do: add validation
                if (false)
                    return BadRequest();
                var userResponse = _userManager.GetUser(userName);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{usertype}")]
        [Route("api/User/usertype")]
        public IActionResult GetUserType(UserType userType)
        {
            try
            {
                //to do: add validation
                if (false)
                    return BadRequest();
                var userResponse = _userManager.GetUserByUserType(userType);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //to do: add validation
                var userResponse = _userManager.GetAllUsers();
                if(userResponse.IsFaulted)
                    return BadRequest();
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]UserModel user)
        {
            try
            {
                //to do: add validation
                if (false)
                    return BadRequest();
                var userResponse = _userManager.UpdateUser(user);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string userName)
        {
            try
            {
                //to do: add validation
                if (false)
                    return BadRequest();
                var userResponse = _userManager.DeleteUser(userName);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
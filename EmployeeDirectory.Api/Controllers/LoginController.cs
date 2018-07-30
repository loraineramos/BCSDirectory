using System;
using EmployeeDirectoryProcessor.Model;
using EmployeeDirectory.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectory.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;
        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }
        

        [HttpGet]
        public IActionResult Get(string userName, string password)
        {
            try
            {
                var userResponse = _loginManager.ValidateLogin(userName, password);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
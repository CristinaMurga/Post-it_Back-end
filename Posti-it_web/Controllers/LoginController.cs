using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Posti_it_web.Repository.Models;

namespace Posti_it_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController :Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/login")]
        public  IActionResult Login(UserCheck user)
        {
            var result = _authenticationService.AuthenticateAsync(HttpContext, "BasicAuthentication").Result;

            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Login failed");
            }
        }
    }


    public class UserCheck
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}


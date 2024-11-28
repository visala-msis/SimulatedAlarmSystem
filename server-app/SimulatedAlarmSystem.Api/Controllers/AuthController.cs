using Microsoft.AspNetCore.Mvc;
using SimulatedAlarmSystem.BL.Interfaces;
using SimulatedAlarmSystem.Models.Models;

namespace SimulatedAlarmSystem.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly ITokenService _tokenService;

        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
    

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Validate the user (this should be replaced with a real user validation against a database)
            if (user == null || string.IsNullOrEmpty(user.UserName)  || string.IsNullOrEmpty(user.Password))
                return Unauthorized("Invalid credentials");

            var result = _userService.LoginUser(user);
            return Ok("user logged in successfully");
        }

        [HttpGet("getUsers")]
        public IActionResult getUsers()
        {
            var result = _userService.LoadUsers();
            return Ok(result);
        }

        [HttpPost("validate")]
		public IActionResult Validate(string token)
		{
			var isValid = _tokenService.ValidateToken(token);
			if (isValid)
			{
				return Ok("Token is valid.");
			}
			else
			{
				return Unauthorized("Invalid token.");
			}
		}
       

        [HttpPost("register")]
        public  ActionResult Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid user data.");
            }

            // Use your service layer or database logic to create the user
            var result =  _userService.RegisterUser(user);

            if (result.IsSuccess)
            {
                return Ok(new { message = "User registered successfully!" });
            }

            return BadRequest(result.ErrorMessage);
        }
    }

}

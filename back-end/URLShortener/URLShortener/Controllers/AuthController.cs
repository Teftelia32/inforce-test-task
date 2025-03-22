using Microsoft.AspNetCore.Mvc;
using URLShortener.DTOs;
using URLShortener.Managers.Interfaces;
using URLShortener.Models;
using URLShortener.Services.Interfaces;

namespace URLShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(IUserManager userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var createdUser = await _userManager.RegisterUserAsync(model.Username, model.Email, model.Password);
            if (createdUser == null)
                return BadRequest("Failed to register user");

            var token = _tokenService.GenerateJwtToken(createdUser);

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.AuthenticateUserAsync(model.Email, model.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Enums;
using URLShortener.Managers.Interfaces;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userManager.GetAllUsersAsync();
            return Ok(users);
        }
    }
}

using GameDatabase.Helpers;
using GameDatabase.Interfaces;
using GameDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDatabase.APIControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async System.Threading.Tasks.Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async System.Threading.Tasks.Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _userService.RegisterUserAsync(model);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}

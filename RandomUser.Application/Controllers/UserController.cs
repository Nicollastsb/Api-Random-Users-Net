using Microsoft.AspNetCore.Mvc;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Interfaces;

namespace RandomUser.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRandomicUserService _randomicUserService;
        private readonly IUserService _userService;

        public UserController(IRandomicUserService randomicUserService, IUserService userService)
        {
            _randomicUserService = randomicUserService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.GetUsers();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser()
        {
            try
            {
                var newUser = await _randomicUserService.GenerateNewRandomUser();

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            try
            {
                var updatedUser = await _userService.Update(user);

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <example>
        ///     {
        ///        "name": "person",
        ///     }
        /// </example>
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now;
            _userAppService.Create(user);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> ReadUser(int userId)
        {
            var user = _userAppService.Read(userId);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            _userAppService.Update(user);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            _userAppService.Delete(userId);
            return Ok();
        }


    }
}

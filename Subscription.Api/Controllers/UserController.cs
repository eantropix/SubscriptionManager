using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Domain.Models;

namespace SubscriptionManager.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
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
            _userAppService.Publish(user, "createUser");
            return Ok();
        }
    }
}

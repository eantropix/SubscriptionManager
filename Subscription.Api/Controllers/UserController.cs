using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Domain.Models;

namespace SubscriptionManager.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class UserController : ControllerBase
    {

        public UserController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            return Ok();
        }
    }
}

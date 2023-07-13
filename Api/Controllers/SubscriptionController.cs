using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.DTO;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionAppService _subscriptionAppService;

        public SubscriptionController(ISubscriptionAppService subscriptionAppService)
        {
            _subscriptionAppService = subscriptionAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionDTO subscriptionDTO)
        {
            _subscriptionAppService.Create(subscriptionDTO);
            return Ok();
        }

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> ReadSubscription(int subscriptionId)
        {
            var subscription = _subscriptionAppService.Read(subscriptionId);
            return Ok(subscription);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscription([FromBody] SubscriptionDTO subscriptionDTO)
        {
            _subscriptionAppService.Update(subscriptionDTO);
            return Ok();
        }

        [HttpDelete("{subscriptionId}")]
        public async Task<IActionResult> DeleteSubscription(int subscriptionId)
        {
            _subscriptionAppService.Delete(subscriptionId);
            return Ok();
        }
    }
}

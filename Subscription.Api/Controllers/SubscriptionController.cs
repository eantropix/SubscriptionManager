using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Domain.Models;

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
        public async Task<IActionResult> CreateSubscription([FromBody] Subscription subscription)
        {
            _subscriptionAppService.Create(subscription);
            return Ok();
        }

        [HttpGet("{subscriptionId}")]
        public async Task<IActionResult> ReadSubscription(int subscriptionId)
        {
            _subscriptionAppService.Read(subscriptionId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscription([FromBody] Subscription subscription)
        {
            _subscriptionAppService.Update(subscription);
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

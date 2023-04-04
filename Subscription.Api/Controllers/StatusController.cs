using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Domain.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusAppService _statusAppService;

        public StatusController(IStatusAppService statusAppService)
        {
            _statusAppService = statusAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] Status status)
        {
            _statusAppService.Create(status);
            return Ok();
        }

        [HttpGet("{statusId}")]
        public async Task<IActionResult> ReadStatus(int statusId)
        {
            _statusAppService.Read(statusId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody] Status status)
        {
            _statusAppService.Update(status);
            return Ok();
        }

        [HttpDelete("{statusId}")]
        public async Task<IActionResult> DeleteStatus(int statusId)
        {
            _statusAppService.Delete(statusId);
            return Ok();
        }
    }
}

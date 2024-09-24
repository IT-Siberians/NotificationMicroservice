using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Services;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventController(EventControlService controlService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> TestEmailAsync([FromBody] ConfirmationEmailEvent emailEvent)
        {
            return await controlService.Process(emailEvent) is true ? NoContent() : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> TestCreateUserAsync([FromBody] CreateUserEvent userEvent)
        {
            return await controlService.Process(userEvent) is true ? NoContent() : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> TestUpdateUserAsync([FromBody] UpdateUserEvent userEvent)
        {
            return await controlService.Process(userEvent) is true ? NoContent() : BadRequest();
        }
    }
}

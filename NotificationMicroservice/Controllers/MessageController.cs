using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Services;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController(IMessageApplicationService messageService, IMapper mapper, SendService send) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync()
        {
            var messages = await messageService.GetAllAsync();

            return Ok(messages.Select(mapper.Map<MessageResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id)
        {
            var message = await messageService.GetByIdAsync(id);

            return message is null
                ? NotFound($"Message id:{id} not found!")
                : Ok(mapper.Map<MessageResponse>(message));
        }

        [HttpPost]
        public async Task<ActionResult> TestAsync([FromBody] EventRequest eventRequest)
        {
            if (eventRequest.id == Event.EmailConfirmation)
            {
                var id = Guid.Parse("4213dfcf-2b3e-46d6-8e09-1a90171091a6");

                await send.SendAsync(mapper.Map<GetMessageModel>(eventRequest.data), id);
            }
            return Ok();
        }
    }
}

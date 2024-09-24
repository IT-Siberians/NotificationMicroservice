using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Contracts.Message;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController(IMessageApplicationService messageService, IMapper mapper) : ControllerBase
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
    }
}

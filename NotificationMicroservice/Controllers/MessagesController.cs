using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Contracts.Message;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MessagesController(IMessageApplicationService messageService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var messages = await messageService.GetAllAsync(cancellationToken);

            return Ok(messages.Select(mapper.Map<MessageResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var message = await messageService.GetByIdAsync(id, cancellationToken);

            return message is null
                ? NotFound($"Message id:{id} not found!")
                : Ok(mapper.Map<MessageResponse>(message));
        }
    }
}

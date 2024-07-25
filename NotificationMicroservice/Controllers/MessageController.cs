using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Domain.Interfaces.Services;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync()
        {
            var messages = await _messageService.GetAllAsync();

            var response = messages.Select(z => new MessageResponse(z.Id, z.MessageType.Name, z.MessageType.Id, z.MessageText, z.Direction, z.CreateDate));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id)
        {
            var message = await _messageService.GetByIdAsync(id);

            if (message == null)
            {
                return BadRequest($"Message id:{id} not found!");
            }

            var response = new MessageResponse(message.Id, message.MessageType.Name, message.MessageType.Id, message.MessageText, message.Direction, message.CreateDate);

            return Ok(response);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Interface;
using NotificationMicroservice.Contracts.Message;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageApplicationService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageApplicationService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync()
        {
            var messages = await _messageService.GetAllAsync();

            return Ok(messages.Select(_mapper.Map<MessageResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id)
        {
            var message = await _messageService.GetByIdAsync(id);

            return message is null 
                ? NotFound($"Message id:{id} not found!") 
                : Ok(_mapper.Map<MessageResponse>(message));
        }
    }
}

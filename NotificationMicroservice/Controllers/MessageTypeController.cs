using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTypeController : ControllerBase
    {
        private readonly IMessageTypeService _messageTypeService;

        public MessageTypeController(IMessageTypeService messageTypeService)
        {
            _messageTypeService = messageTypeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TypeResponse>), 200)]
        public async Task<ActionResult<List<TypeResponse>>> GetAllAsync()
        {
            var types = await _messageTypeService.GetAllAsync();

            var response = types.Select(z => new TypeResponse(z.Id, z.Name, z.IsRemove, z.CreateUserName, z.CreateDate, z.ModifyUserName, z.ModifyDate));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TypeResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TypeResponse>> GetByIdAsync(Guid id)
        {
            var type = await _messageTypeService.GetByIdAsync(id);

            if (type == null)
            {
                return NotFound($"Type id:{id} not found!");
            }

            var response = new TypeResponse(type.Id, type.Name, type.IsRemove, type.CreateUserName, type.CreateDate, type.ModifyUserName, type.ModifyDate);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TypeRequestAdd request)
        {
            var typeNew = new MessageType(Guid.NewGuid(), request.Name, false, request.CreateUserName, DateTime.UtcNow, null, null);

            return Ok(await _messageTypeService.AddAsync(typeNew));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TypeRequestUp request)
        {

            var type = await _messageTypeService.GetByIdAsync(id);

            if (type == null)
            {
                return NotFound($"Type id:{id} not found!");
            }

            type.Update(request.Name, false, request.ModifyUserName, DateTime.UtcNow);

            return Ok(await _messageTypeService.UpdateAsync(type));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TypeDelete request)
        {
            var type = await _messageTypeService.GetByIdAsync(id);

            if (type == null)
            {
                return NotFound($"Type id:{id} not found!");
            }

            type.Delete(request.ModifyUserName, DateTime.UtcNow);

            return Ok(await _messageTypeService.DeleteAsync(type));
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTemplateController : ControllerBase
    {
        private readonly IMessageTemplateService _messageTemplateService;
        private readonly IMessageTypeService _messageTypeService;

        public MessageTemplateController(IMessageTemplateService messageTemplateService, IMessageTypeService messageTypeService)
        {
            _messageTemplateService = messageTemplateService;
            _messageTypeService = messageTypeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateResponse>), 200)]
        public async Task<ActionResult<List<TemplateResponse>>> GetAllAsync()
        {
            var templates = await _messageTemplateService.GetAllAsync();

            var response = templates
                .Select(z => new TemplateResponse(z.Id, z.MessageType.Name, z.MessageType.Id, z.Language, z.Template, z.IsRemove, z.CreateUserName, z.CreateDate, z.ModifyUserName, z.ModifyDate));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<TemplateResponse>>> GetByIdAsync(Guid id)
        {
            var template = await _messageTemplateService.GetByIdAsync(id);

            if (template == null)
            {
                return BadRequest("Template not found!");
            }

            var response = new TemplateResponse(
                template.Id,
                template.MessageType.Name,
                template.MessageType.Id,
                template.Language,
                template.Template,
                template.IsRemove,
                template.CreateUserName,
                template.CreateDate,
                template.ModifyUserName,
                template.ModifyDate);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TemplateRequestAdd request)
        {
            var type = await _messageTypeService.GetByIdAsync(request.MessageTypeId);

            if (type == null)
            {
                return NotFound($"MessageType {request.MessageTypeId} not found!");
            }
            var template = new MessageTemplate(Guid.NewGuid(), type, request.Language, request.Template, true, request.CreateUserName, DateTime.UtcNow, null, null);

            var entityId = await _messageTemplateService.AddAsync(template);

            return Ok(entityId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TemplateRequestUp request)
        {
            var type = await _messageTypeService.GetByIdAsync(request.MessageTypeId);

            if (type == null)
            {
                return NotFound("MessageType not found");
            }

            var template = await _messageTemplateService.GetByIdAsync(id);

            if (template == null)
            {
                return NotFound($"Template {id} not found!");
            }

            template.Update(type, request.Language, request.Template, false, request.ModifyUserName, DateTime.UtcNow);
            
            return Ok(await _messageTemplateService.UpdateAsync(template));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TemplateDelete request)
        {
            var template = await _messageTemplateService.GetByIdAsync(id);

            if (template == null)
            {
                return NotFound($"Template {id} not found!");
            }

            template.Delete(request.ModifyUserName, DateTime.UtcNow);

            return Ok(await _messageTemplateService.DeleteAsync(template));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Interface;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Contracts.Template;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTemplateController : ControllerBase
    {
        private readonly ITemplateApplicationService _messageTemplateService;
        private readonly IMapper _mapper;

        public MessageTemplateController(ITemplateApplicationService messageTemplateService, IMapper mapper)
        {
            _messageTemplateService = messageTemplateService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateResponse>), 200)]
        public async Task<ActionResult<List<TemplateResponse>>> GetAllAsync()
        {
            var templates = await _messageTemplateService.GetAllAsync();
            
            return Ok(templates.Select(_mapper.Map<TemplateResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<List<TemplateResponse>>> GetByIdAsync(Guid id)
        {
            var template = await _messageTemplateService.GetByIdAsync(id);

            return template is null
                ? NotFound($"Template {id} not found!") 
                : Ok(_mapper.Map<TemplateResponse>(template));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TemplateRequestAdd request)
        {
            var templateId = await _messageTemplateService.AddAsync(_mapper.Map<CreateTemplateModel>(request));

            if (templateId == Guid.Empty)
            {
                return BadRequest("Type can not be created");
            }

            return Created("", templateId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TemplateRequestUp request)
        {
            //var typeModel = await _messageTypeService.GetByIdAsync(request.MessageTypeId);

            //if (typeModel == null)
            //{
            //    return NotFound($"MessageType {request.MessageTypeId} not found!");
            //}

            //var type = new MessageType(
            //            typeModel.Id,
            //            typeModel.Name,
            //            typeModel.IsRemove,
            //            typeModel.CreateUserName,
            //            typeModel.CreateDate,
            //            typeModel.ModifyUserName,
            //            typeModel.ModifyDate);

            //var template = await _messageTemplateService.GetByIdAsync(id);

            //if (template == null)
            //{
            //    return NotFound($"Template {id} not found!");
            //}

            //template.Update(type, request.Language, request.Template, false, request.ModifyUserName, DateTime.UtcNow);

            //return Ok(await _messageTemplateService.UpdateAsync(template));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TemplateDelete request)
        {
            //var template = await _messageTemplateService.GetByIdAsync(id);

            //if (template == null)
            //{
            //    return NotFound($"Template {id} not found!");
            //}

            //template.Delete(request.ModifyUserName, DateTime.UtcNow);

            //return Ok(await _messageTemplateService.DeleteAsync(template));
            return Ok();
        }
    }
}

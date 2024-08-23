using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Template;

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
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TemplateAddRequest request)
        {
            var validator = new TemplateAddValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var templateId = await _messageTemplateService.AddAsync(_mapper.Map<CreateTemplateModel>(request));

            if (templateId == Guid.Empty)
            {
                return BadRequest("Type can not be created");
            }

            return Created("", templateId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TemplateEditRequest request)
        {
            var validator = new TemplateEditValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var editTemplate = new EditTemplateModel
            {
                Id = id,
                ModifyUserName = request.ModifyUserName
            };

            return await _messageTemplateService.UpdateAsync(editTemplate) is true ? NoContent() : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TemplateDeleteRequest request)
        {
            var validator = new TemplateDeleteValidator();

            var result = validator.Validate(request);
            
            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var editTemplate = new EditTemplateModel
            {
                Id = id,
                ModifyUserName = request.ModifyUserName
            };

            return await _messageTemplateService.DeleteAsync(editTemplate) is true ? NoContent() : BadRequest(false);
        }
    }
}

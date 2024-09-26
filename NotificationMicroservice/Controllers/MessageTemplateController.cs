using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Contracts.Template;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTemplateController(ITemplateApplicationService messageTemplateService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateResponse>), 200)]
        public async Task<ActionResult<List<TemplateResponse>>> GetAllAsync()
        {
            var templates = await messageTemplateService.GetAllAsync();

            return Ok(templates.Select(mapper.Map<TemplateResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<List<TemplateResponse>>> GetByIdAsync(Guid id)
        {
            var template = await messageTemplateService.GetByIdAsync(id);

            return template is null
                ? NotFound($"Template {id} not found!")
                : Ok(mapper.Map<TemplateResponse>(template));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] AddTemplateRequest request)
        {
            var templateId = await messageTemplateService.AddAsync(mapper.Map<CreateTemplateModel>(request));

            if (templateId is null)
            {
                return BadRequest("Template can not be created");
            }
            return Created("", templateId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] EditTemplateRequest request)
        {
            var template = mapper.Map<UpdateTemplateModel>(request);
            template.Id = id;
            return await messageTemplateService.UpdateAsync(template) is true ? NoContent() : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] DeleteTemplateRequest request)
        {
            var template = mapper.Map<DeleteTemplateModel>(request);
            template.Id = id;
            return await messageTemplateService.DeleteAsync(template) is true ? NoContent() : BadRequest(false);
        }
    }
}

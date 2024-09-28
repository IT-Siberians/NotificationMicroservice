using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Contracts.Template;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MessageTemplatesController(ITemplateApplicationService messageTemplateService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TemplateResponse>), 200)]
        public async Task<ActionResult<List<TemplateResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var templates = await messageTemplateService.GetAllAsync(cancellationToken);

            return Ok(templates.Select(mapper.Map<TemplateResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TemplateResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<List<TemplateResponse>>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var template = await messageTemplateService.GetByIdAsync(id, cancellationToken);

            return template is null
                ? NotFound($"Template {id} not found!")
                : Ok(mapper.Map<TemplateResponse>(template));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] AddTemplateRequest request, CancellationToken cancellationToken)
        {
            var templateId = await messageTemplateService.AddAsync(mapper.Map<CreateTemplateModel>(request), cancellationToken);

            if (templateId is null)
            {
                return BadRequest("Template can not be created");
            }
            return Created("", templateId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] EditTemplateRequest request, CancellationToken cancellationToken)
        {
            var template = mapper.Map<UpdateTemplateModel>(request);
            template.Id = id;
            return await messageTemplateService.UpdateAsync(template, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] DeleteTemplateRequest request, CancellationToken cancellationToken)
        {
            var template = mapper.Map<DeleteTemplateModel>(request);
            template.Id = id;
            return await messageTemplateService.DeleteAsync(template, cancellationToken) is true ? NoContent() : BadRequest(false);
        }
    }
}

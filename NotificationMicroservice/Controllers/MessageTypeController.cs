using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTypeController(ITypeApplicationService messageTypeService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TypeResponse>), 200)]
        public async Task<ActionResult<List<TypeResponse>>> GetAllAsync()
        {
            var types = await messageTypeService.GetAllAsync();

            return Ok(types.Select(mapper.Map<TypeResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TypeResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<TypeResponse>> GetByIdAsync(Guid id)
        {
            var type = await messageTypeService.GetByIdAsync(id);

            return type is null
                ? NotFound($"Type {id} not found!")
                : Ok(mapper.Map<TypeResponse>(type));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] AddTypeRequest request)
        {
            var typeId = await messageTypeService.AddAsync(mapper.Map<CreateTypeModel>(request));

            if (typeId is null)
            {
                return BadRequest("Type can not be created");
            }
            return Created("", typeId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] EditTypeRequest request)
        {
            var type = mapper.Map<UpdateTypeModel>(request);
            type.Id = id;
            return await messageTypeService.UpdateAsync(type) is true ? NoContent() : NotFound($"Type {id} not found or remove!");
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] DeleteTypeRequest request)
        {
            var type = mapper.Map<DeleteTypeModel>(request);
            type.Id = id;
            return await messageTypeService.DeleteAsync(type) is true ? NoContent() : NotFound($"Type {id} NOT delete!");
        }

    }
}

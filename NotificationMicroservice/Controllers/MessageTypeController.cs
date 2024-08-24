using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Type;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageTypeController : ControllerBase
    {
        private readonly ITypeApplicationService _messageTypeService;
        private readonly IMapper _mapper;

        public MessageTypeController(ITypeApplicationService messageTypeService, IMapper mapper)
        {
            _messageTypeService = messageTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TypeResponse>), 200)]
        public async Task<ActionResult<List<TypeResponse>>> GetAllAsync()
        {
            var types = await _messageTypeService.GetAllAsync();

            return Ok(types.Select(_mapper.Map<TypeResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TypeResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<TypeResponse>> GetByIdAsync(Guid id)
        {
            var type = await _messageTypeService.GetByIdAsync(id);

            return type is null
                ? NotFound($"Type {id} not found!")
                : Ok(_mapper.Map<TypeResponse>(type));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TypeAddRequest request)
        {
            var validator = new TypeAddValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var typeId = await _messageTypeService.AddAsync(_mapper.Map<CreateTypeModel>(request));

            if (typeId == Guid.Empty)
            {
                return BadRequest("Type can not be created");
            }

            return Created("", typeId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TypeEditRequest request)
        {
            var validator = new TypeEditValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var type = new EditTypeModel()
            {
                Id = id,
                Name = request.Name,
                ModifiedUserName = request.ModifiedUserName
            };
            

            return await _messageTypeService.UpdateAsync(type) is true ? NoContent() : NotFound($"Type {id} not found or remove!");
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TypeDeleteRequest request)
        {
            var validator = new TypeDeleteValidator();
            
            var result = validator.Validate(request);
            
            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            var type = new EditTypeModel()
            {
                Id = id,
                ModifiedUserName = request.ModifiedUserName
            };

            return await _messageTypeService.DeleteAsync(type) is true ? NoContent() : NotFound($"Type {id} not found!");
        }

    }
}

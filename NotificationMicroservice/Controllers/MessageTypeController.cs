﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Contracts.Type;

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
        public async Task<ActionResult<Guid>> AddAsync([FromBody] TypeRequestAdd request)
        {
            var typeId = await _messageTypeService.AddAsync(_mapper.Map<CreateTypeModel>(request));

            if (typeId == Guid.Empty)
            {
                return BadRequest("Type can not be created");
            }

            return Created("", typeId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] TypeRequestUp request)
        {
            var type = _mapper.Map<EditTypeModel>(request);

            type.Id = id;

           return await _messageTypeService.UpdateAsync(type) is true ? Ok(true) : NotFound($"Type {id} not found or remove!");
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] TypeRequestDelete request)
        {
            var type = _mapper.Map<EditTypeModel>(request);

            type.Id = id;

            return await _messageTypeService.DeleteAsync(type) is true ? Ok(true) : NotFound($"Type {id} not found!");
        }

    }
}

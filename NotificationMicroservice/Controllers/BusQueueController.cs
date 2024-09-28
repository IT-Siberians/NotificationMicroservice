using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.Application.Model.BusQueue;
using NotificationMicroservice.Application.Services.Abstractions;
using NotificationMicroservice.Contracts.BusQueue;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BusQueueController(IBusQueueApplicationService queueService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BusQueueResponse>), 200)]
        public async Task<ActionResult<List<BusQueueResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var queue = await queueService.GetAllAsync(cancellationToken);

            return Ok(queue.Select(mapper.Map<BusQueueResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BusQueueResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<BusQueueResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var queue = await queueService.GetByIdAsync(id, cancellationToken);

            return queue is null
                ? NotFound($"BusQueue id:{id} not found!")
                : Ok(mapper.Map<BusQueueResponse>(queue));
        }

        [HttpGet("{queueName}")]
        [ProducesResponseType(typeof(BusQueueResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<BusQueueResponse>> GetTypeByQueueAsync(string queueName, CancellationToken cancellationToken)
        {
            var queue = await queueService.GetTypeByEventAsync(new QueueName(queueName), cancellationToken);

            return queue is null
                ? NotFound($"Type not found for QueueName:{queueName}")
                : Ok(mapper.Map<BusQueueResponse>(queue));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] AddBusQueueRequest request, CancellationToken cancellationToken)
        {
            var queueId = await queueService.AddAsync(mapper.Map<CreateBusQueueModel>(request), cancellationToken);

            if (queueId is null)
            {
                return BadRequest("BusQueue can not be created");
            }
            return Created("", queueId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> UpdateAsync(Guid id, [FromBody] EditBusQueueRequest request, CancellationToken cancellationToken)
        {
            var queue = mapper.Map<UpdateBusQueueModel>(request);
            queue.Id = id;
            return await queueService.UpdateAsync(queue, cancellationToken) is true ? NoContent() : BadRequest(false);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id, [FromBody] DeleteBusQueueRequest request, CancellationToken cancellationToken)
        {
            var queue = mapper.Map<DeleteBusQueueModel>(request);
            queue.Id = id;
            return await queueService.DeleteAsync(queue, cancellationToken) is true ? NoContent() : BadRequest(false);
        }
    }
}

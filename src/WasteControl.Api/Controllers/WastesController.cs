using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WasteControl.Application.Commands.Wastes.CreateWaste;
using WasteControl.Application.Commands.Wastes.DeleteWaste;
using WasteControl.Application.Commands.Wastes.UpdateWaste;
using WasteControl.Application.Queries.Wastes.GetWasteById;
using WasteControl.Application.Queries.Wastes.GetWastes;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("wastes")]
    public class WastesController : ControllerBaseApi
    {
        public WastesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all wastes",
            Description = "Get all wastes from the database"
        )]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetWastesQuery());

            return Ok(wastes);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(
            Summary = "Get waste by id",
            Description = "Get waste from the database by id"
        )]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetWasteByIdQuery() { Id = id });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create waste",
            Description = "Create waste in the database"
        )]
        public async Task<IActionResult> Create([FromBody] CreateWasteCommand command)
        {
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(Get), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(
            Summary = "Update waste",
            Description = "Update waste in the database"
        )]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWasteCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(
            Summary = "Delete waste",
            Description = "Delete waste from the database"
        )]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteWasteCommand() { Id = id });

            return NoContent();
        }
    }
}
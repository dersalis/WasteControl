using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("waste-export")]
    public class WasteExportsController : ControllerBaseApi
    {
        public WasteExportsController(IMediator mediator) : base(mediator)
        {
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var wastes = await _mediator.Send(new GetWasteExportsQuery());

        //     return Ok(wastes);
        // }

        // [HttpGet("{id:guid}")]
        // public async Task<IActionResult> Get([FromRoute] Guid id)
        // {
        //     var waste = await _mediator.Send(new GetWasteExportByIdQuery() { Id = id });

        //     return waste is not null 
        //         ? Ok(waste) 
        //         : NotFound();
        // }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateWasteExportCommand command)
        // {
        //     Guid? id = await _mediator.Send(command);

        //     return id is not null
        //         ? CreatedAtAction(nameof(Get), new { id }, id)
        //         : BadRequest();
        // }

        // [HttpPut("{id:guid}")]
        // public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWasteExportCommand command)
        // {
        //     if (id != command.Id)
        //         return BadRequest();

        //     await _mediator.Send(command);

        //     return NoContent();
        // }

        // [HttpDelete("{id:guid}")]
        // public async Task<IActionResult> Delete([FromRoute] Guid id)
        // {
        //     await _mediator.Send(new DeleteWasteExportCommand() { Id = id });

        //     return NoContent();
        // }
    }
}
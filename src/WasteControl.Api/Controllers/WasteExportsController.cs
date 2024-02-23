using MediatR;
using Microsoft.AspNetCore.Mvc;
using WasteControl.Application.Commands.WasteExports.CreateWasteExport;
using WasteControl.Application.Commands.WasteExports.DeleteWasteExport;
using WasteControl.Application.Commands.WasteExports.UpdateWasteExport;
using WasteControl.Application.Queries.WasteExports.GetWasteExportById;
using WasteControl.Application.Queries.WasteExports.GetWasteExports;
using WasteControl.Application.Queries.WasteExports.GetWastes;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("waste-export")]
    public class WasteExportsController : ControllerBaseApi
    {
        public WasteExportsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exports = await _mediator.Send(new GetWasteExportsQuery());

            return Ok(exports);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var export = await _mediator.Send(new GetWasteExportByIdQuery() { Id = id });

            return export is not null 
                ? Ok(export) 
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWasteExportCommand command)
        {
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(Get), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWasteExportCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteWasteExportCommand() { Id = id });

            return NoContent();
        }

        [HttpGet("{id:guid}/wastes")]
        public async Task<IActionResult> GetAllWastes([FromRoute] Guid id)
        {
            var wastes = await _mediator.Send(new GetWastesQuery() { Id = id });

            return Ok(wastes);
        }

        [HttpPut("{id:guid}/addwastes")]
        public async Task<IActionResult> AddWastes([FromRoute] Guid id, [FromBody] AddWastesCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}/removewaste/{wasteId:guid}")]
        public async Task<IActionResult> RemoveWaste([FromRoute] Guid id, [FromRoute] Guid wasteId)
        {
            await _mediator.Send(new RemoveWasteCommand() { Id = id, WasteId = wasteId });

            return NoContent();
        }

        [HttpPut("{id:guid}/addreceivingcompany/{receiverId:guid}")]
        public async Task<IActionResult> AddReceivingCompany([FromRoute] Guid id, [FromRoute] Guid receiverId)
        {
            await _mediator.Send(new AddReceiverCommand() { Id = id, ReceiverId = receiverId });

            return NoContent();
        }

        [HttpPut("{id:guid}/addtransportcompany/{receiverId:guid}")]
        public async Task<IActionResult> AddTransportCompany([FromRoute] Guid id, [FromRoute] Guid receiverId)
        {
            await _mediator.Send(new AddTransporterCommand() { Id = id, TransporterId = receiverId });

            return NoContent();
        }
    }
}
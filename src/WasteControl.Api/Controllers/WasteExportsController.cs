using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WasteControl.Application.Commands.WasteExports.AddReceiver;
using WasteControl.Application.Commands.WasteExports.AddTransporter;
using WasteControl.Application.Commands.WasteExports.AddWastes;
using WasteControl.Application.Commands.WasteExports.CreateWasteExport;
using WasteControl.Application.Commands.WasteExports.DeleteWaste;
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
        [SwaggerOperation(
            Summary = "Get all waste exports",
            Description = "Get all waste exports from the database"
        )]
        public async Task<IActionResult> GetAll()
        {
            var exports = await _mediator.Send(new GetWasteExportsQuery());

            return Ok(exports);
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(
            Summary = "Get waste export by id",
            Description = "Get waste export from the database by id"
        )]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var export = await _mediator.Send(new GetWasteExportByIdQuery() { Id = id });

            return export is not null 
                ? Ok(export) 
                : NotFound();
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create waste export",
            Description = "Create waste export in the database"
        )]
        public async Task<IActionResult> Create([FromBody] CreateWasteExportCommand command)
        {
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(Get), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(
            Summary = "Update waste export",
            Description = "Update waste export in the database"
        )]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWasteExportCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(
            Summary = "Delete waste export",
            Description = "Delete waste export from the database"
        )]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteWasteExportCommand() { Id = id });

            return NoContent();
        }

        [HttpGet("{id:guid}/wastes")]
        [SwaggerOperation(
            Summary = "Get all wastes",
            Description = "Get all wastes from the database"
        )]
        public async Task<IActionResult> GetAllWastes([FromRoute] Guid id)
        {
            var wastes = await _mediator.Send(new GetWastesQuery() { Id = id });

            return Ok(wastes);
        }

        [HttpPut("{id:guid}/add-wastes")]
        [SwaggerOperation(
            Summary = "Add wastes",
            Description = "Add wastes to the waste export"
        )]
        public async Task<IActionResult> AddWastes([FromRoute] Guid id, [FromBody] AddWastesCommand command)
        {
            if (id != command.WasteExportId)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}/delete-waste/{wasteId:guid}")]
        [SwaggerOperation(
            Summary = "Delete waste",
            Description = "Delete waste from the waste export"
        )]
        public async Task<IActionResult> DeleteWaste([FromRoute] Guid id, [FromRoute] Guid wasteId)
        {
            await _mediator.Send(new DeleteWasteCommand() { WasteExportId = id, WasteId = wasteId });

            return NoContent();
        }

        [HttpPut("{id:guid}/add-receivingcompany/{receiverId:guid}")]
        [SwaggerOperation(
            Summary = "Add receiving company",
            Description = "Add receiving company to the waste export"
        )]
        public async Task<IActionResult> AddReceivingCompany([FromRoute] Guid id, [FromRoute] Guid receiverId)
        {
            await _mediator.Send(new AddReceiverCommand() { WasteExportId = id, ReceiverId = receiverId });

            return NoContent();
        }

        [HttpPut("{id:guid}/add-transportcompany/{receiverId:guid}")]
        [SwaggerOperation(
            Summary = "Add transport company",
            Description = "Add transport company to the waste export"
        )]
        public async Task<IActionResult> AddTransportCompany([FromRoute] Guid id, [FromRoute] Guid receiverId)
        {
            await _mediator.Send(new AddTransporterCommand() { WasteExportId = id, TransporterId = receiverId });

            return NoContent();
        }
    }
}
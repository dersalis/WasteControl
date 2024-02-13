using MediatR;
using Microsoft.AspNetCore.Mvc;
using WasteControl.Application.Commands.ReceivingCompanies.CreateReceivingCompany;
using WasteControl.Application.Commands.TransportCompanies.DeleteTransportCompany;
using WasteControl.Application.Commands.TransportCompanies.UpdateTransportCompany;
using WasteControl.Application.Queries.TransportCompanies.GetTransportCompanies;
using WasteControl.Application.Queries.TransportCompanies.GetTransportCompanyById;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("transport-company")]
    public class TransportCompaniesController : ControllerBaseApi
    {
        public TransportCompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetTransportCompaniesQuery());

            return Ok(wastes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetTransportCompanyByIdQuery() { Id = id });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReceivingCompanyCommand command)
        {
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(Get), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTransportCompanyCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteTransportCompanyCommand() { Id = id });

            return NoContent();
        }
    }
}
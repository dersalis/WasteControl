using MediatR;
using Microsoft.AspNetCore.Mvc;
using WasteControl.Application.Commands.ReceivingCompanies.CreateReceivingCompany;
using WasteControl.Application.Commands.ReceivingCompanies.DeleteReceivingCompany;
using WasteControl.Application.Commands.ReceivingCompanies.UpdateReceivingCompany;
using WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanies;
using WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanyById;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("receiving-companies")]
    public class ReceivingCompaniesController : ControllerBaseApi
    {
        public ReceivingCompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetReceivingCompaniesQuery());

            return Ok(wastes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetReceivingCompanyByIdQuery() { Id = id });

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReceivingCompanyCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteReceivingCompanyCommand() { Id = id });

            return NoContent();
        }
    }
}
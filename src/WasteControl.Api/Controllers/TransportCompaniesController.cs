using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get all transport companies",
            Description = "Get all transport companies from the database"
        )]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetTransportCompaniesQuery());

            return Ok(wastes);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get transport company by id",
            Description = "Get transport company from the database by id"
        )]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetTransportCompanyByIdQuery() { Id = id });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpPost]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Create transport company",
            Description = "Create transport company in the database"
        )]
        public async Task<IActionResult> Create([FromBody] CreateReceivingCompanyCommand command)
        {
            command.UserId = GetUserId();
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(Get), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Update transport company",
            Description = "Update transport company in the database"
        )]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTransportCompanyCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            command.UserId = GetUserId();
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Delete transport company",
            Description = "Delete transport company from the database"
        )]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteTransportCompanyCommand() { Id = id, UserId = GetUserId()});

            return NoContent();
        }
    }
}
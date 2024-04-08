using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get all receiving companies",
            Description = "Get all receiving companies from the database"
        )]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetReceivingCompaniesQuery());

            return Ok(wastes);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get receiving company by id",
            Description = "Get receiving company from the database by id"
        )]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetReceivingCompanyByIdQuery() { Id = id });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpPost]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Create receiving company",
            Description = "Create receiving company in the database"
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
            Summary = "Update receiving company",
            Description = "Update receiving company in the database"
        )]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReceivingCompanyCommand command)
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
            Summary = "Delete receiving company",
            Description = "Delete receiving company from the database"
        )]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteReceivingCompanyCommand() { Id = id, UserId = GetUserId()});

            return NoContent();
        }
    }
}
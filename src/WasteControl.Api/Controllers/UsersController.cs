using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBaseApi
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var wastes = await _mediator.Send(new GetUsersQuery());

        //     return Ok(wastes);
        // }

        // [HttpGet("{id:guid}")]
        // public async Task<IActionResult> Get([FromRoute] Guid id)
        // {
        //     var waste = await _mediator.Send(new GetUserByIdQuery() { Id = id });

        //     return waste is not null 
        //         ? Ok(waste) 
        //         : NotFound();
        // }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        // {
        //     Guid? id = await _mediator.Send(command);

        //     return id is not null
        //         ? CreatedAtAction(nameof(Get), new { id }, id)
        //         : BadRequest();
        // }

        // [HttpPut("{id:guid}")]
        // public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
        // {
        //     if (id != command.Id)
        //         return BadRequest();

        //     await _mediator.Send(command);

        //     return NoContent();
        // }

        // [HttpDelete("{id:guid}")]
        // public async Task<IActionResult> Delete([FromRoute] Guid id)
        // {
        //     await _mediator.Send(new DeleteUserCommand() { Id = id });

        //     return NoContent();
        // }
    }
}
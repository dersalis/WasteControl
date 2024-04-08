using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WasteControl.Application.Commands.Users.CreateUser;
using WasteControl.Application.Commands.Users.DeleteUser;
using WasteControl.Application.Commands.Users.SignIn;
using WasteControl.Application.Commands.Users.UpdateUser;
using WasteControl.Application.Queries.Users.GetUserByEmail;
using WasteControl.Application.Queries.Users.GetUserById;
using WasteControl.Application.Queries.Users.GetUsers;
using WasteControl.Auth;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBaseApi
    {
        private readonly IAuthenticator _authenticator;
        private readonly ITokenStorage _tokenStorage;

        public UsersController(IMediator mediator, 
            IAuthenticator authenticator,
            ITokenStorage tokenStorage) : base(mediator)
        {
            _authenticator = authenticator;
            _tokenStorage = tokenStorage;
        }

        [HttpGet]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Get all users from the database"
        )]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetUsersQuery());

            return Ok(wastes);
        }

        [HttpGet("getbyid/{id:guid}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get user by id",
            Description = "Get user from the database by id"
        )]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var waste = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpGet("getbyemail/{email}")]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Get user by email",
            Description = "Get user from the database by email"
        )]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            var waste = await _mediator.Send(new GetUserByEmailQuery() { Email = email });

            return waste is not null 
                ? Ok(waste) 
                : NotFound();
        }

        [HttpPost]
        [Authorize(Roles="admin, user")]
        [SwaggerOperation(
            Summary = "Create user",
            Description = "Create user in the database"
        )]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            command.UserId = GetUserId();
            Guid? id = await _mediator.Send(command);

            return id is not null
                ? CreatedAtAction(nameof(GetById), new { id }, id)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles="admin")]
        [SwaggerOperation(
            Summary = "Update user",
            Description = "Update user in the database"
        )]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            command.UserId = GetUserId();
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles="admin")]
        [SwaggerOperation(
            Summary = "Delete user",
            Description = "Delete user from the database"
        )]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = id, UserId = GetUserId()});

            return NoContent();
        }

        [HttpPost("sign-in")]
        [SwaggerOperation(
            Summary = "Sign in",
            Description = "Sign in to the system"
        )]
        public async Task<ActionResult<JwtDto>> SignIn([FromBody] SignInCommand command)
        {
            await _mediator.Send(command);
            var jwt = _tokenStorage.Get();

            return Ok(jwt);
        }

        // [HttpGet("getmetest")]
        // [Authorize]
        // public async Task<ActionResult> GetMeTest()
        // {
        //     var userName = HttpContext.User.Identity?.Name;
        //     if (string.IsNullOrEmpty(userName))
        //     {
        //         return NotFound();
        //     }

        //     var userId = Guid.Parse(userName);
        //     var user = await _mediator.Send(new GetUserByIdQuery() { Id = userId });
        //     if (user is null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(user);
        // }
    }
}
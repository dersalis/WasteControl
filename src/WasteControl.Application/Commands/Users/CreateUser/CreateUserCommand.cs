using MediatR;

namespace WasteControl.Application.Commands.Users.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Login { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
using MediatR;

namespace WasteControl.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
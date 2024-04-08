using MediatR;

namespace WasteControl.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}
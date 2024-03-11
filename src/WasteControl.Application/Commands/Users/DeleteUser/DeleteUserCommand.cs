using MediatR;

namespace WasteControl.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
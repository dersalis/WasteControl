using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
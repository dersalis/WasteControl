using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.Users.GetUsers
{
    public sealed class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
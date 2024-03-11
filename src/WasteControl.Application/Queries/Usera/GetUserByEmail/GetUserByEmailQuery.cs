using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
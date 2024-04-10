using MediatR;
using WasteControl.Core.Enums;

namespace WasteControl.Application.Queries.Users.CheckUserPermision
{
    public class CheckUserPermisionQuery : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public UserRole Role { get; set; }
    }
}
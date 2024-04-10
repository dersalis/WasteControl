using MediatR;
using WasteControl.Core.Enums;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Users.CheckUserPermision
{
    public class CheckUserPermisionQueryHandler : IRequestHandler<CheckUserPermisionQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public CheckUserPermisionQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckUserPermisionQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user is null)
                return false;

            if (user.IsActive == false)
                return false;

            if (user.Role.ToString().ToLower() == UserRole.Admin.ToString().ToLower())
                return true;

            return user.Role.ToString().ToLower() == request.Role.ToString().ToLower();
        }
    }
}
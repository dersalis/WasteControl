using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Users.GetUsers
{
    internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => u.MapToDto());
        }
    }
}
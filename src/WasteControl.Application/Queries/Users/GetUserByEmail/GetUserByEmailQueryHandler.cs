using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Users.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
                return default;

            return user.MapToDto();  
        }
    }
}
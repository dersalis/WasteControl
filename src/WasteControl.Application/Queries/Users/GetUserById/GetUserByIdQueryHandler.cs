using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
                return default;

            return user.MapToDto();            
        }
    }
}
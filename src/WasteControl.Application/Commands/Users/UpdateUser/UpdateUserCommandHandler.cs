using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : CommandHandlerBase, IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _userRepository = userRepository;
        }
        
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

            if (user is null)
                throw new UserNotFoundException();

            User userToUpdate = await _userRepository.GetByIdAsync(request.Id);

            if (userToUpdate is null)
                throw new UserNotFoundException();

            userToUpdate.ChangeName(request.Name);
            userToUpdate.ChangeLogin(request.Login);
            userToUpdate.ChangeEmail(request.Email);
            userToUpdate.ChangePassword(request.Password);
            userToUpdate.ChangeRole(request.Role);

            await _userRepository.UpdateAsync(userToUpdate);
        }
    }
}
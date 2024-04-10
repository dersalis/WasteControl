using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : CommandHandlerBase, IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = await GetNowAsync();
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

            if (user is null)
                throw new UserNotFoundException();

            User userToDelete = await _userRepository.GetByIdAsync(request.Id);

            if (userToDelete is null)
                throw new UserNotFoundException();

            userToDelete.ChangeActivity(false);
            userToDelete.ChangeModifiedDate(currentDate);
            userToDelete.ChangeModifiedBy(user);

            await _userRepository.UpdateAsync(userToDelete);
        }
    }
}
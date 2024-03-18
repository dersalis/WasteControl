using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

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
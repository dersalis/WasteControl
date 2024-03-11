using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            User userToUpdate = await _userRepository.GetAsync(request.Id);

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
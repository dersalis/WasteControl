
using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Core.ValueObjects;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

            if (user is null)
                throw new UserNotFoundException();

            User userEmailExist = await _userRepository.GetByEmailAsync(request.Email);
            if(userEmailExist is not null)
            {
                throw new EmailAlreadyInUseException(request.Email);
            }

            User loginExist = await _userRepository.GetByLoginAsync(request.Login);
            if(loginExist is not null)
            {
                throw new LoginAlreadyInUseException(request.Login);
            }

            var securePassword = _passwordManager.Secure(new Password(request.Password));

            User newUser = new User(new UserName(request.Name), new Login(request.Login), new Email(request.Email), 
                securePassword);

            newUser.ChangeRole(request.Role);
            newUser.ChangeCreateDate(currentDate);
            newUser.ChangeCreatedBy(user);

            await _userRepository.AddAsync(newUser);

            return newUser.Id;
        }
    }
}
using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Users.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand>
    {
        public readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IAuthenticator _authenticator;
        private readonly ITokenStorage _tokenStorage;

        public SignInCommandHandler(IUserRepository userRepository,
            IPasswordManager passwordManager,
            IAuthenticator authenticator,
            ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _authenticator = authenticator;
            _tokenStorage = tokenStorage;
        }

        public async Task Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email);
            if(user is null)
            {
                throw new InvalidCredentialsException();
            }

            if(!_passwordManager.Validate(request.Password, user.Password))
            {
                throw new InvalidCredentialsException();
            }

            var jwt = _authenticator.CreateToken(user.Id, user.Role);
            _tokenStorage.Set(jwt);
        }
    }
}
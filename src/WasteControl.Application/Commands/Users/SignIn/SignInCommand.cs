using MediatR;

namespace WasteControl.Application.Commands.Users.SignIn
{
    public class SignInCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
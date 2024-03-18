using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class LoginAlreadyInUseException : BaseException
    {
        public LoginAlreadyInUseException(string login)
            : base($"Login {login} is already in use.")
        {  }
    }
}
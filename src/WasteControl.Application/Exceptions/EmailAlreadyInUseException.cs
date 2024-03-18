using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class EmailAlreadyInUseException : BaseException
    {
        public EmailAlreadyInUseException(string email)
            : base($"Email {email} is already in use.")
        {
        }
    }
}
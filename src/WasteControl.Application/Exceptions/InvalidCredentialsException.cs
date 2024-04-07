using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class InvalidCredentialsException : BaseException
    {
        public InvalidCredentialsException() : base("Invalid credentials")
        {
            
        }
    }
}
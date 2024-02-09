using WasteControl.Core.Exceptions;

namespace WasteControl.Application.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base("User not found")
        {
        }
    }
}
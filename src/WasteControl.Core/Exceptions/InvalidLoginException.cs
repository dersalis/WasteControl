namespace WasteControl.Core.Exceptions
{
    public class InvalidLoginException : BaseException
    {
        public InvalidLoginException(string login)
            : base($"Invalid login: {login}")
        {
            
        }
    }
} 
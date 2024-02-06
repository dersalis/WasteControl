namespace WasteControl.Core.Exceptions
{
    public class InvalidPhoneException : BaseException
    {
        public InvalidPhoneException(string phone) : base($"Invalid phone number: {phone}")
        {
            
        }
    }
}
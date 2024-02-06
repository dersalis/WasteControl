namespace WasteControl.Core.Exceptions
{
    public class InvalidCompanyCodeException : BaseException
    {
        public InvalidCompanyCodeException(string value) : base($"Invalid company code: {value}")
        {
            
        }
    }
}
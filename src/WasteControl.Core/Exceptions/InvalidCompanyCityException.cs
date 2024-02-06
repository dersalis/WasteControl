namespace WasteControl.Core.Exceptions
{
    public class InvalidCompanyCityException : BaseException
    {
        public InvalidCompanyCityException(string value) : base($"Invalid company city: {value}.")
        {
        }
    }
}
namespace WasteControl.Core.Exceptions
{
    public class InvalidPostalCodeException : BaseException
    {
        public InvalidPostalCodeException(string postalCode) : base($"Invalid postal code: {postalCode}")
        {
        }
    }
}
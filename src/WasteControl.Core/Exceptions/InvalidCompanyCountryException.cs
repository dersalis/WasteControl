namespace WasteControl.Core.Exceptions
{
    public class InvalidCompanyCountryException : BaseException
    {
        public InvalidCompanyCountryException(string value) : base($"Invalid company country: {value}.")
        {
        }
    }
}
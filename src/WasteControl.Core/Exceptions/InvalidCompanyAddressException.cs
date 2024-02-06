namespace WasteControl.Core.Exceptions
{
    public class InvalidCompanyAddressException : BaseException
    {
        public InvalidCompanyAddressException(string address) : base($"Invalid company address: {address}")
        {
            
        }
    }
}
namespace WasteControl.Core.Exceptions
{
    public class InvalidCompanyNameException : BaseException
    {
        public InvalidCompanyNameException(string name) : base($"Invalid company name: {name}")
        {
            
        }
    }
}
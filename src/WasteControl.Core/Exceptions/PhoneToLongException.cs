namespace WasteControl.Core.Exceptions
{
    public class PhoneToLongException : BaseException
    {
        public PhoneToLongException(string value) : base($"Phone number is too long: {value}.")
        {
        }
    }
}
namespace WasteControl.Core.Exceptions
{
    public class InvalidWasteCodeException : BaseException
    {
        public InvalidWasteCodeException(string code) : base($"Invalid waste code: {code}")
        {
            
        }
    }
}
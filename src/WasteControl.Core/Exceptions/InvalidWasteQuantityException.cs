namespace WasteControl.Core.Exceptions
{
    public class InvalidWasteQuantityException : BaseException
    {
        public InvalidWasteQuantityException(decimal value) : base($"Invalid waste quantity: {value}")
        {
            
        }
    }
}
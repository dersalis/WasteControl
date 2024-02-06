namespace WasteControl.Core.Exceptions
{
    public class InvalidWasteUnitException : BaseException
    {
        public InvalidWasteUnitException(string value) : base($"Invalid waste unit: {value}")
        {
            
        }
    }
}
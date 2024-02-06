namespace WasteControl.Core.Exceptions
{
    public class InvalidWasteNameException : BaseException
    {
        public InvalidWasteNameException(string name) : base($"Invalid waste name: {name}")
        {
            
        }
    }
}
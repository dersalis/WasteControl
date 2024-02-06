namespace WasteControl.Core.Exceptions
{
    public class EmptyPostalCodeException : BaseException
    {
        public EmptyPostalCodeException() : base("Postal code cannot be empty")
        {
            
        }
    }
}
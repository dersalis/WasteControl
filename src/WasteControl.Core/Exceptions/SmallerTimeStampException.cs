namespace WasteControl.Core.Exceptions
{
    public class SmallerTimeStampException : BaseException
    {
        public SmallerTimeStampException(DateTime dateTime) : base($"The TimeStamp ({dateTime.ToString()}) cannot be smaller than the current one.")
        { 
        }
    }
}
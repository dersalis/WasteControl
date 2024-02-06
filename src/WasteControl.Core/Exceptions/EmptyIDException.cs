namespace WasteControl.Core.Exceptions
{
    public class EmptyIDException : BaseException
    {
        public EmptyIDException() : base("ID cannot be empty")
        {
        }
    }
}
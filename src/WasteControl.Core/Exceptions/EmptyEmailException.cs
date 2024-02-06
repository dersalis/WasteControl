namespace WasteControl.Core.Exceptions
{
    public class EmptyEmailException : BaseException
    {
        public EmptyEmailException() : base("Email can not be empty.")
        {
            
        }
    }
}
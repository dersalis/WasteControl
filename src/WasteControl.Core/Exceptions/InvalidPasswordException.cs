namespace WasteControl.Core.Exceptions
{
    public sealed class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException() : base("Invalid password.")
        {
        }
    }
}
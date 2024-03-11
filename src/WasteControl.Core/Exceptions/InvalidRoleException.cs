namespace WasteControl.Core.Exceptions
{
    public class InvalidRoleException : BaseException
    {
        public string Role { get; }

        public InvalidRoleException(string role) : base($"Role: '{role}' is invalid.")
        {
            Role = role;
        }
    }
}
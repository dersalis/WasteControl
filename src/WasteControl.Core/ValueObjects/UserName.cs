using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record UserName
    {
        public string Value { get; }

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidUserNameException(value);
            }

            Value = value;
        }
    }
}
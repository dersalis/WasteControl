using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public record class Login
    {
        public string Value { get; }

        public Login(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidLoginException(value);
            }

            Value = value;
        }

        public static implicit operator Login(string value) => new(value);

        public static implicit operator string(Login login) => login.Value;

        public override string ToString() => Value;
    }
}
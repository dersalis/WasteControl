using System.Text.RegularExpressions;
using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record Phone
    {
        private static readonly Regex Regex = new(
            @"^\+48\d{9}$",
            RegexOptions.Compiled);

        public string Value { get; }

        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPhoneException();
            }

            if (value.Length > 12)
            {
                throw new PhoneToLongException(value);
            }

            value = value.ToLowerInvariant();
            if (!Regex.IsMatch(value))
            {
                throw new InvalidPhoneException(value);
            }

            Value = value;
        }

        public static implicit operator string(Phone phone) => phone.Value;
        public static implicit operator Phone(string phone) => new(phone); 

        public override string ToString() => Value;
    }
}
using System.Text.RegularExpressions;
using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record PostalCode
    {
        private static readonly Regex Regex = new(
        @"^([0-9][0-9])(-)([0-9][0-9][0-9])$",
        RegexOptions.Compiled);
        
        public string Value { get; }

        public PostalCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPostalCodeException();
            }

            if (value.Length > 100)
            {
                throw new InvalidPostalCodeException(value);
            }

            value = value.ToLowerInvariant();
            if (!Regex.IsMatch(value))
            {
                throw new InvalidPostalCodeException(value);
            }

            Value = value;

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(PostalCode postalCode) => postalCode.Value;
        public static implicit operator PostalCode(string postalCode) => new(postalCode);
    }
}
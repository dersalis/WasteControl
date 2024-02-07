using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record Country
    {
        public string Value { get; }

        public Country(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidCompanyCountryException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(Country country) => country.Value;
        public static implicit operator Country(string country) => new(country);
    }
}
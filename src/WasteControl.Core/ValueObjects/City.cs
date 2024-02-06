using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record City
    {
        public string Value { get; }

        public City(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidCompanyCityException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(City companyCity) => companyCity.Value;
        public static implicit operator City(string companyCity) => new(companyCity);
    }
}
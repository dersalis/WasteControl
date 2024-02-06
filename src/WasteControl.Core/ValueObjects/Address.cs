using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record Address
    {
        public string Value { get; }

        public Address(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidCompanyAddressException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(Address companyAddress) => companyAddress.Value;
        public static implicit operator Address(string companyAddress) => new(companyAddress);
    }
}
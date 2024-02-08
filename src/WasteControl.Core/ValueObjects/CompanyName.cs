using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record CompanyName
    {
        public string Value { get; }

        public CompanyName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidCompanyNameException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(CompanyName companyName) => companyName.Value;
        public static implicit operator CompanyName(string companyName) => new(companyName);
    }
}
using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record CompanyCode
    {
        public string Value { get; }

        public CompanyCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 10)
            {
                throw new InvalidCompanyCodeException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(CompanyCode companyCode) => companyCode.Value;
        public static implicit operator CompanyCode(string companyCode) => new(companyCode);
    }
}
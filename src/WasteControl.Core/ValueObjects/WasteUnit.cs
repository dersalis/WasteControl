using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record WasteUnit
    {
        public string Value { get; }

        public WasteUnit(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidWasteUnitException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator WasteUnit(string value) => new(value);
        public static implicit operator string(WasteUnit value) => value.Value;
    }
}
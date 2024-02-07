using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record WasteCode
    {
        public string Value { get; }

        public WasteCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 10)
            {
                throw new InvalidWasteCodeException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator WasteCode(string value) => new WasteCode(value);
        public static implicit operator string(WasteCode value) => value.Value;
    }
}
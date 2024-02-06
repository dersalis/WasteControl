using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record WasteName
    {
        public string Value { get; }

        public WasteName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            {
                throw new InvalidWasteNameException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator WasteName(string value) => new WasteName(value);
        public static implicit operator string(WasteName value) => value.Value;
    }
}
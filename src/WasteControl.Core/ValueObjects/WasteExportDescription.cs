using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record WasteExportDescription
    {
        public string Value { get; }

        public WasteExportDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 1000)
            {
                throw new InvalidWasteExportDescriptionExcepton(value);
            }

            Value = value;
        }

        public static implicit operator string(WasteExportDescription description) => description.Value;
        public static implicit operator WasteExportDescription(string description) => new(description);
    }
}
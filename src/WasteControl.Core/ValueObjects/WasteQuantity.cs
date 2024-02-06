using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record WasteQuantity
    {
        public decimal Value { get; }

        public WasteQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidWasteQuantityException(value);
            }

            Value = value;
        }

        public override string ToString() => Value.ToString();
        public static implicit operator WasteQuantity(decimal value) => new WasteQuantity(value);
        public static implicit operator decimal(WasteQuantity value) => value.Value;
    }
}
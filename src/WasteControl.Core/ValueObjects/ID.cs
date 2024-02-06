using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record ID
    {
        public Guid Value { get; }

        public ID(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyIDException();
            }

            Value = value;
        }

        public static implicit operator Guid(ID id) => id.Value;
        public static implicit operator ID(Guid id) => new ID(id);
    }
}
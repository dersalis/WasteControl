using WasteControl.Core.Exceptions;

namespace WasteControl.Core.ValueObjects
{
    public sealed record TimeStamp
    {
        public DateTime Value { get; }

        public TimeStamp(DateTime value)
        {
            if (value.Date < DateTime.Now.Date)
            {
                throw new SmallerTimeStampException(value);
            }

            Value = value;
        }

        public static implicit operator DateTime(TimeStamp timeStamp) 
            => timeStamp.Value;

        public static implicit operator TimeStamp(DateTime timeStamp) 
            => new TimeStamp(timeStamp);

        public static bool operator >(TimeStamp left, TimeStamp right) => left.Value > right.Value;
        public static bool operator <(TimeStamp left, TimeStamp right) => left.Value < right.Value;
        public static bool operator >=(TimeStamp left, TimeStamp right) => left.Value >= right.Value;
        public static bool operator <=(TimeStamp left, TimeStamp right) => left.Value <= right.Value;
    }
}
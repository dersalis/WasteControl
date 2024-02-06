namespace WasteControl.Core.ValueObjects
{
    public sealed record Activity
    {
        public bool Value { get; }

        public Activity(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(Activity activity) => activity.Value;
        public static implicit operator Activity(bool activity) => new Activity(activity);
    }
}
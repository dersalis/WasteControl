namespace WasteControl.Infrastructure.Abstractions
{
    public interface IDateTimeProvider
    {
        public Task<DateTime> GetNowAsync();
    }
}
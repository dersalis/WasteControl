using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Implementations
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public Task<DateTime> GetNowAsync() => Task.FromResult(DateTime.Now);
    }
}
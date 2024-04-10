using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands
{
    public class CommandHandlerBase
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CommandHandlerBase(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<DateTime> GetNowAsync() => await _dateTimeProvider.GetNowAsync();
    }
}
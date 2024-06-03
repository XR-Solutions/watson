using Watson.Application.Interfaces.Services;

namespace Watson.Adapter.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc()
        {
            return DateTime.UtcNow;
        }
    }
}

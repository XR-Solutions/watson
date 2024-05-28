using Watson.Application.Interfaces.Servcies;

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

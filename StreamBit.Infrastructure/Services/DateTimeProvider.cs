using StreamBit.Application.Common.Interfaces.Services;

namespace StreamBit.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}

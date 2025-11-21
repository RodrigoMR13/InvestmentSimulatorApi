using Application.Interfaces;

namespace Infrastructure.Time
{
    public class BrasilTimeProvider : ITimeProvider
    {
        private static readonly TimeZoneInfo _brazilZone =
            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

        public DateTimeOffset BrazilNow =>
            TimeZoneInfo.ConvertTime(UtcNow, _brazilZone);
    }
}

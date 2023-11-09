using Assesment.Application.Contracts.Infrastructure;

namespace Assesment.Infrastructure.DateTimeService;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

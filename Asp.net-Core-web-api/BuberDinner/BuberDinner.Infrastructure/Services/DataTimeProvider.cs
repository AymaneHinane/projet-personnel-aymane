using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;


public class DataTimeProvider : IDataTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
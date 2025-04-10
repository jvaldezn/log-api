using Log.Domain.Entities;

namespace Log.Infrastructure.Interfaces
{
    public interface ILogRepository
    {
        Task<List<Log.Domain.Entities.Log>> GetLogsByDates(DateTime startDate, DateTime endDate);
        Task<List<Log.Domain.Entities.Log>> GetLogByApplicationAndDate(int applicationId, DateTime logged);
        Task<List<Log.Domain.Entities.Log>> GetLogByApplicationAndYearAndMonth(int applicationId, DateTime logged);
        Task<List<Log.Domain.Entities.Log>> GetLogByYearAndMonth(DateTime logged);
    }
}

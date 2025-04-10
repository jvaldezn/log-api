using System.Numerics;
using Log.Domain.Entities;
using Log.Infrastructure.Data.Context;
using Log.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Log.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _context;

        public LogRepository(LogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Log.Domain.Entities.Log>> GetLogsByDates(DateTime startDate, DateTime endDate) =>
            await _context.Log
                .Where(a => startDate.Date >= a.Logged.Date
                            && endDate.Date <= a.Logged.Date)
                .ToListAsync();

        public async Task<List<Log.Domain.Entities.Log>> GetLogByApplicationAndDate(int applicationId, DateTime logged) =>
            await _context.Log.Where(a => a.ApplicationId == applicationId
                                          && a.Logged.Date == logged)
                .ToListAsync();

        public async Task<List<Log.Domain.Entities.Log>> GetLogByApplicationAndYearAndMonth(int applicationId, DateTime logged) =>
            await _context.Log.Where(a => a.ApplicationId == applicationId
                                          && a.Logged.Year == logged.Year
                                          && a.Logged.Month == logged.Month)
                .ToListAsync();

        public async Task<List<Log.Domain.Entities.Log>> GetLogByYearAndMonth(DateTime logged) =>
            await _context.Log.Where(a => a.Logged.Year == logged.Year
                                          && a.Logged.Month == logged.Month)
                .ToListAsync();
    }
}

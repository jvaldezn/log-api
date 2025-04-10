using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Application.DTOs;
using Log.Transversal.Common;

namespace Log.Application.Interfaces
{
    public interface ILogApplication
    {
        Task<Response<object>> RegisterLog(LogDto information);
        Task<Response<IEnumerable<LogDto>>> GetLogsByDates(DateTime startDate, DateTime endDate);
        Task<Response<IEnumerable<LogDto>>> GetLogByApplicationAndDate(int applicationId, DateTime logged);
        Task<Response<IEnumerable<LogDto>>> GetLogByApplicationAndYearAndMonth(int applicationId, DateTime logged);
        Task<Response<IEnumerable<LogDto>>> GetLogByYearAndMonth(DateTime logged);
    }
}

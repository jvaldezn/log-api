using AutoMapper;
using Log.Application.DTOs;
using System.Security.Claims;
using System.Text;
using Log.Application.Interfaces;
using Log.Transversal.Common;
using Log.Transversal.Common.Interface;
using Log.Infrastructure.Interfaces;
using Log.Transversal.Validator;
using Log.Transversal.Common.Helper;

namespace Log.Application.Services
{
    public class LogApplication : ILogApplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogRepository _logRepository;

        public LogApplication(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogRepository logRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logRepository = logRepository;
        }

        public async Task<Response<object>> RegisterLog(LogDto information)
        {
            var response = new Response<object>();

            var validator = await new LogValidator().ValidateAsync(information);

            if (!validator.IsValid)
            {
                response.Message = validator.Errors.GetErrorMessage();

                return response;
            }

            var entity = _mapper.Map<Log>(information);

            using var transaction = _unitOfWork?.BeginTransaction();
            try
            {
                var register = await _logRepository.AddAsync(entity, transaction!);

                if (register == Constant.NoDatabaseChanges)
                {
                    response.Message = Message.GenericErrorMessage;
                    response.IsSuccess = false;
                    return response;
                }

                transaction?.Commit();
            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }

            return response;
        }

        public async Task<Response<IEnumerable<LogDto>>> GetLogsByDates(DateTime startDate, DateTime endDate)
        {
            var response = new Response<IEnumerable<LogDto>>();

            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
            {
                response.Message = Message.DidntSendInformationForConsume;

                return response;
            }

            var logs = await _logRepository.GetLogsByDates(startDate, endDate);

            if (!logs.Any())
            {
                response.Message = Message.DidNotFindAnyResults;

                return response;
            }

            response.Data = _mapper.Map<IEnumerable<LogDto>>(logs);
            response.IsWarning = false;

            return response;
        }

        public async Task<Response<IEnumerable<LogDto>>> GetLogByApplicationAndDate(int applicationId, DateTime logged)
        {
            var response = new Response<IEnumerable<LogDto>>();

            if (applicationId == 0 || logged == DateTime.MinValue)
            {
                response.Message = Message.DidntSendInformationForConsume;

                return response;
            }

            var logs = await _logRepository.GetLogByApplicationAndDate(applicationId, logged);

            if (!logs.Any())
            {
                response.Message = Message.DidNotFindAnyResults;

                return response;
            }

            response.Data = _mapper.Map<IEnumerable<LogDto>>(logs);
            response.IsWarning = false;

            return response;
        }

        public async Task<Response<IEnumerable<LogDto>>> GetLogByApplicationAndYearAndMonth(int applicationId, DateTime logged)
        {
            var response = new Response<IEnumerable<LogDto>>();

            if (applicationId == 0 || logged == DateTime.MinValue)
            {
                response.Message = Message.DidntSendInformationForConsume;

                return response;
            }

            var logs = await _logRepository.GetLogByApplicationAndYearAndMonth(applicationId, logged);

            if (!logs.Any())
            {
                response.Message = Message.DidNotFindAnyResults;

                return response;
            }

            response.Data = _mapper.Map<IEnumerable<LogDto>>(logs);
            response.IsWarning = false;

            return response;
        }

        public async Task<Response<IEnumerable<LogDto>>> GetLogByYearAndMonth(DateTime logged)
        {
            var response = new Response<IEnumerable<LogDto>>();

            var logs = await _logRepository.GetLogByYearAndMonth(logged);

            if (!logs.Any())
            {
                response.Message = Message.DidNotFindAnyResults;

                return response;
            }

            response.Data = _mapper.Map<IEnumerable<LogDto>>(logs);
            response.IsWarning = false;

            return response;
        }
    }
}

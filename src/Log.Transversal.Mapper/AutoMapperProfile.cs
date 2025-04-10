using AutoMapper;
using Log.Application.DTOs;
using Log.Domain.Entities;

namespace Log.Transversal.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Log.Domain.Entities.Log, LogDto>().ReverseMap();
        }
    }
}

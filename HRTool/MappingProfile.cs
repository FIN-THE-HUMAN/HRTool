using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace HRTool
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vacancy, VacancyDto>();
            CreateMap<VacancyDto, Vacancy>(MemberList.None);

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FirstName,
                    options => options.MapFrom(x => x.FirstName == null ? null : ""))
                .ForMember(dest => dest.LastName,
                    options => options.MapFrom(x => x.LastName == null ? null : ""))
                .ForMember(dest => dest.Position,
                    options => options.MapFrom(x => x.Position == null ? null : ""))
                .ForMember(dest => dest.PhoneNumber,
                    options => options.MapFrom(x => x.PhoneNumber == null ? null : ""));

            CreateMap<UserDto, User>();
        }
    }
}
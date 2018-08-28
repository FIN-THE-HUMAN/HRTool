using System.Collections.Generic;
using System.Linq;
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
            CreateMap<VacancyDto, Vacancy>()
                .ForMember(dest => dest.Duties, options => options.Ignore())
                .ForMember(dest => dest.Requirements, options => options.Ignore())
                .ForMember(dest => dest.AdditionalRequirements, options => options.Ignore())
                .ForMember(dest => dest.VacancyStatus, options => options.Ignore())
                .ForMember(dest => dest.VacanciesApplicants, options => options.Ignore());

            CreateMap<DutyDto, Duty>();
        }
    }
}
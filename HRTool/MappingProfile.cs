using System;
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
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id,
                    options => options.Ignore())
                .ForMember(dest => dest.Position,
                    options => options.MapFrom(source => source.Position))
                .ForMember(dest => dest.FirstName,
                    options => options.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName,
                    options => options.MapFrom(source => source.LastName))
                .ForMember(dest => dest.Email,
                    options => options.MapFrom(source => source.Email))
                .ForMember(dest => dest.UserName,
                    options => options.MapFrom(source => source.Email))
                .ForMember(dest => dest.PhoneNumber,
                    options => options.MapFrom(source => source.PhoneNumber))
                .ForAllOtherMembers(options => options.UseDestinationValue());

            CreateMap<Vacancy, VacancyDto>()
                .ForMember(dest => dest.Duties, options => options.Ignore())
                .ForMember(dest => dest.Requirements, options => options.Ignore());
            //.ForMember(dest => dest.Status, options => options.Ignore())

            CreateMap<VacancyDto, Vacancy>()
                .ForMember(dest => dest.Id, options => options.UseValue(new Guid()))
                .ForMember(dest => dest.VacancyDuties, options => options.Ignore())
                .ForMember(dest => dest.VacancyRequirements, options => options.Ignore())
                .ForMember(dest => dest.VacancyApplicants, options => options.Ignore());

            CreateMap<Vacancy, VacanciesDto>();


            CreateMap<DutyDto, Duty>();
            CreateMap<Duty, DutyDto>();
            CreateMap<ApplicantDto, Applicant>()
                .ForMember(dest => dest.Id, options => options.UseValue(new Guid()));
            CreateMap<Applicant, ApplicantDto>();
        }
    }
}
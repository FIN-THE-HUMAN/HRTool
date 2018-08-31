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

            CreateMap<VacancyDto, Vacancy>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.VacancyDuties, options => options.Ignore())
                .ForMember(dest => dest.VacancyRequirements, options => options.Ignore())
                .ForMember(dest => dest.VacancyApplicants, options => options.Ignore())
                .ForMember(dest => dest.CreationDate, options =>
                {
                    options.Ignore();
                    options.UseDestinationValue();
                })
                .ForMember(dest => dest.Status, options =>
                {
                    options.Ignore();
                    options.UseDestinationValue();
                });

            CreateMap<Vacancy, VacanciesDto>();
            CreateMap<DutyDto, Duty>()
                .ForMember(dest => dest.Id, options => options.UseValue(new Guid()));
            CreateMap<Duty, DutyDto>();

            CreateMap<RequirementDto, Requirement>()
                .ForMember(dest => dest.Id, options => options.ResolveUsing(src =>
                {
                    try
                    {
                        var guid = new Guid(src.Id);
                    }
                    catch (Exception e)
                    {
                        src.Id = new Guid().ToString();
                    }

                    return src.Id;
                }));
            ;
            CreateMap<Requirement, RequirementDto>()
                .ForMember(dest => dest.IsAdditional, options => options.Ignore());

            CreateMap<ApplicantDto, Applicant>()
                .ForMember(dest => dest.Id, options => options.UseValue(new Guid()));
            CreateMap<Applicant, ApplicantDto>();
        }
    }
}
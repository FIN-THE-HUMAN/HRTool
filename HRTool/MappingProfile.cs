using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL.Models;

namespace HRTool
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Vacancy, VacancyDto>();
        }
    }
}
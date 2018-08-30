using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.DTO
{
    public class VacancyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public Departures DepartureName { get; set; }
        public decimal SalaryRangeFrom { get; set; }
        public decimal SalaryRangeTo { get; set; }
        public string RequiredExperienceRange { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string WorkHours { get; set; }
        public string Description { get; set; }
        public List<DutyDto> Duties { get; set; } = new List<DutyDto>();
        public List<RequirementDto> Requirements { get; set; } = new List<RequirementDto>();
        public string HolderName { get; set; }
        public VacancyStatus Status { get; set; }
        public BranchOffice BranchOfficeCity { get; set; }
    }
}
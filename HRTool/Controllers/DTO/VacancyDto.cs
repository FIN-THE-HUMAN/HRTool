using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.DTO
{
    public class DutyDto
    {
        public string Id { get; set; }
    }
    
    public class RequirementDto
    {
        public string Id { get; set; }
    }

    public class VacancyDto
    {
        public string Name {get; set;}
        public Departures DepartureName {get;set;}
        public decimal SalaryRangeFrom {get; set;}
        public decimal SalaryRangeTo {get; set;}
        public string RequiredExperienceRange {get;set;}
        public string ContactPerson {get;set;}
        [Phone]
        public string ContactPhone {get;set;}
        [EmailAddress]
        public string ContactMail {get;set;}
        public EmploymentType EmploymentType {get; set;}
        public string WorkHours {get;set;}
        public string Description {get; set;}
        public ICollection<DutyDto> Duties {get;set;}
        public ICollection<RequirementDto> Requirements {get;set;}
        public ICollection<RequirementDto> AdditionalRequirements {get;set;}
        public string VacancyHolderName {get;set;}
        public BranchOffice BranchOfficeCity {get;set;}
    }
}
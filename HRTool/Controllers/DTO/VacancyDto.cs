using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.DTO
{
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
        public ICollection<Duty> Duties {get;set;}
        public ICollection<Requirement> Requirements {get;set;}
        public ICollection<Requirement> AdditionalRequirements {get;set;}
        public VacancyStatus VacancyStatus {get;set;}
        public string VacancyHolderName {get;set;}
        public BranchOffice BranchOfficeCity {get;set;}
        public ICollection<VacancyApllicant> VacancyApllicants {get;set;}
    }
}
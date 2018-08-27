using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enumes;

namespace HRTool.Controllers.Models
{
    public class VacancyModel
    {
         public string Name {get; set;}
        public DeparturesEnum DepartureName {get;set;}
        public decimal SalaryRangeFrom {get; set;}
        public decimal SalaryRangeTo {get; set;}
        public string RequiredExperienceRange {get;set;}
        public string ContactPerson {get;set;}
        [Phone]
        public string ContactPhone {get;set;}
        [EmailAddress]
        public string ContactMail {get;set;}
        public EmploymentTypeEnum EmploymentType {get; set;}
        public string WorkHours {get;set;}
        public string Description {get; set;}
        public ICollection<Duty> Duties {get;set;}
        public ICollection<Requirement> Requirements {get;set;}
        public ICollection<Requirement> AdditionalRequirements {get;set;}
        public VacancyStatusEnum VacancyStatus {get;set;}
        public string VacancyHolderName {get;set;}
        public BranchOfficeEnum BranchOfficeCity {get;set;}
        public  ICollection<VacancyApllicant> VacancyApllicants {get;set;}
    }
}
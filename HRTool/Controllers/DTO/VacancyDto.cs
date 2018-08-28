using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.DTO
{
    public class VacancyDto
    {
        public string Name { get; set; }
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
        public List<string> Duties { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> AdditionalRequirements { get; set; }
        public string VacancyHolderName { get; set; }
        public BranchOffice BranchOfficeCity { get; set; }
    }
}
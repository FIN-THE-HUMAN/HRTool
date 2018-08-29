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
        public DateTime CreationDate { get; set; }
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
        public List<string> Duties { get; set; } = new List<string>();
        public List<string> Requirements { get; set; } = new List<string>();
        public string HolderName { get; set; }
        public VacancyStatus Status { get; set; }
        public BranchOffice BranchOfficeCity { get; set; }
    }
}
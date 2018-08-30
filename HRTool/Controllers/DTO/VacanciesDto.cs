using System;
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.DTO
{
    public class VacanciesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Departures DepartureName { get; set; }
        public decimal SalaryRangeFrom { get; set; }
        public decimal SalaryRangeTo { get; set; }
        public string Description { get; set; }
        public VacancyStatus Status { get; set; }
        public BranchOffice BranchOfficeCity { get; set; }
    }
}
using HRTool.DAL.Models.Enums;

namespace HRTool.Controllers.Models
{
    public class VacanciesDTO
    {
        public string Name {get; set;}
        public Departures DepartureName {get;set;}
        public decimal SalaryRangeFrom {get; set;}
        public decimal SalaryRangeTo {get; set;}
        public string Description {get; set;}
        public VacancyStatus VacancyStatus {get;set;}
        public BranchOffice BranchOfficeCity {get;set;}
    }
}
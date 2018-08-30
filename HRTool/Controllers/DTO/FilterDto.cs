using HRTool.DAL.Models.Enums;
namespace HRTool.Controllers.DTO
{
    public class FilterDto
    {
        public VacancyStatus? Status {get;set;}
        public Departures? Departures {get;set;}
        public BranchOffice? BranchOffice {get;set;}
    }
}
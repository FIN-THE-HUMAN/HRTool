using System;

namespace HRTool.DAL.Models.IntermediateModels
{
    public class VacancyDuty
    {
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
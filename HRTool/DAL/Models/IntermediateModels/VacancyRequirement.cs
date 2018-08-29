using System;

namespace HRTool.DAL.Models.IntermediateModels
{
    public class VacancyRequirement
    {
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid RequirementId { get; set; }
        public Requirement Requirement { get; set; }
    }
}
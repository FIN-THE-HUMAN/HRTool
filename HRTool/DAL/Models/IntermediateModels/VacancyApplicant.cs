using System;

namespace HRTool.DAL.Models.IntermediateModels
{
    public class VacancyApplicant
    {
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
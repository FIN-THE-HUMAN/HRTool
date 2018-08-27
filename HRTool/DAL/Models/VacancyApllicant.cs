using System;

namespace HRTool.DAL.Models
{
    public class VacancyApllicant
    {
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
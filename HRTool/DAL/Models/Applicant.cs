using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.DAL.Models
{
    public class Applicant
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        [Range(18, 65)]
        public int Age {get;set;}
        public ResumeSource Source {get;set;}
        public bool Interviewed {get; set;}
        public InterviewResult Result {get; set;}
        public string ResultDescription {get; set;}
        public decimal Salary {get;set;}
        public DateTime ApplicationDate {get;set;}
        public bool Sex {get;set;}
        //должность, на которую претендует
        public string WantedPosition {get; set;}
        [EmailAddress]
        public string ContactMail {get; set;}
        [Phone]
        public string ContactPhone {get; set;}
        public string About {get; set;}
        public string Experience {get; set;}
        public BranchOffice Branch {get; set;}
        public ICollection<VacancyApplicant> VacancyApllicants {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTool.DAL.Models
{
    public class Applicant
    {
        public Guid ApplicantId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        [Range(18, 65)]
        public int Age {get;set;}
        public decimal Salary {get;set;}
        public DateTime ApplicationDate {get;set;}
        public bool Sex {get;set;}
        public string CareerObjectiveName {get; set;}
        [EmailAddress]
        public string ContactMail {get; set;}
        [Phone]
        public string ContactPhone {get; set;}
        public string About {get; set;}
        public string Experience {get;set;}
        public bool WasInterviewed {get;set;}
        public virtual ICollection<Vacancy> Vacancy {get;set;}
    }
}
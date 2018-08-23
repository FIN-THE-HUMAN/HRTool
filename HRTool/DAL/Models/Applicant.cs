using System;
using System.ComponentModel.DataAnnotations;

namespace HRTool.DAL.Models
{
    public class Applicant
    {
        public Guid Id {get;set;}
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
    }
}
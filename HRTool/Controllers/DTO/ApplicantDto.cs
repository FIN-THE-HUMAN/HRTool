using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.Controllers.DTO
{
    public class ApplicantDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Interviewed { get; set; }
        public InterviewResult Result { get; set; }
        public string ResultDescription { get; set; }
        public decimal Salary { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool Sex { get; set; }
        public string WantedPosition { get; set; }
        public string ContactMail { get; set; }
        public string ContactPhone { get; set; }
        public string About { get; set; }
        public string Experience { get; set; }
        public BranchOffice Branch { get; set; }
    }
}
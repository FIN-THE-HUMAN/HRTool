using System;
using HRTool.DAL.Models.Enums;

namespace HRTool.DAL.Models
{
    public class Resume
    {
        public Guid Id {get;set;}
        public ResumeSource ResumeSource {get;set;}
        public byte[] Content {get;set;} 
    }
}
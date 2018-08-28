using System;

namespace HRTool.DAL.Models
{
    public class Requirement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
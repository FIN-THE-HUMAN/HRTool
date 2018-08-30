using System;
using System.Collections.Generic;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.DAL.Models
{
    public class Requirement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<VacancyRequirement> Vacancies { get; set; }
    }
}
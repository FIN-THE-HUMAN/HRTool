using System;
using System.Collections;
using System.Collections.Generic;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.DAL.Models
{
    public class Duty
    {
        //Коммент для проверки мерджа
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<VacancyDuty> Vacancies { get; set; }
    }
}
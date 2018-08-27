using System;

namespace HRTool.DAL.Models
{
    public class Duty
    {
        //Коммент для проверки мерджа
        public Guid DutyId { get; set; }
        public string DutyName { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HRTool.Models
{
    //Модель пользователя приложения
    public class Vacancy
    {
        public Guid Id {get;set;}
        public string Name {get; set;}
        public decimal Salary {get; set;}
        public string ContactPerson {get;set;}
        public string Phone {get;set;}
        public string EmploymentType {get; set;}
        public string Description {get; set;}
    }
}

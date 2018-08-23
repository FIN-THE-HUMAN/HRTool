using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using HRTool.DAL.Models;
using System.Collections.Generic;

namespace HRTool.DAL.Models
{
    //Модель пользователя приложения
    public class Vacancy
    {
        public Guid VacancyId {get;set;}
        public string Name {get; set;}
        //Наименование структурного подразделеия
        public DeparturesEnum DepartureName {get;set;}
        //"Заработок: От 35000р...
        public decimal SalaryRangeFrom {get; set;}
        //...до 200000р"
        public decimal SalaryRangeTo {get; set;}
        //Требуемый опыт работы
        public string RequiredExperienceRange {get;set;}
        //Имя и фамилия контактного лица
        public string ContactPerson {get;set;}
        [Phone]
        public string ContactPhone {get;set;}
        [EmailAddress]
        public string ContactMail {get;set;}
        //Полная, неполная занятость
        public EmploymentTypeEnum EmploymentType {get; set;}
        //Часы работы в день
        public string WorkHours {get;set;}
        public string Description {get; set;}
        //Чем будет заниматься соискатель(обязанности)
        public List<Duty> Duties {get;set;}
        //Что должен уметь соискатель (требования)
        public List<Requirement> Requirements {get;set;}
        public List<Requirement> AdditionalRequirements {get;set;}
        public VacancyStatusEnum VacancyStatus {get;set;}
        public string VacancyHolderName {get;set;}
        public BranchOfficeEnum BranchOfficeCity {get;set;}
        public virtual ICollection<Applicant> Applicants {get;set;}
    }
}

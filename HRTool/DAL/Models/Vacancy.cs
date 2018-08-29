using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HRTool.Controllers.DTO;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.DAL.Models
{
    //Модель пользователя приложения
    public class Vacancy
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //Наименование структурного подразделеия
        public DateTime CreationDate { get; set; }

        public Departures DepartureName { get; set; }

        //"Заработок: От 35000р...
        public decimal SalaryRangeFrom { get; set; }

        //...до 200000р"
        public decimal SalaryRangeTo { get; set; }

        //Требуемый опыт работы
        public string RequiredExperienceRange { get; set; }

        //Имя и фамилия контактного лица
        public string ContactPerson { get; set; }
        [Phone] public string ContactPhone { get; set; }

        [EmailAddress] public string ContactMail { get; set; }

        //Полная, неполная занятость
        public EmploymentType EmploymentType { get; set; }

        //Часы работы в день
        public string WorkHours { get; set; }

        public string Description { get; set; }

        //Чем будет заниматься соискатель(обязанности)
        public ICollection<VacancyDuty> VacancyDuties { get; set; } = new List<VacancyDuty>();

        //Что должен уметь соискатель (требования)
        public ICollection<VacancyRequirement> VacancyRequirements { get; set; } = new List<VacancyRequirement>();
        public VacancyStatus Status { get; set; }
        public string HolderName { get; set; }
        public BranchOffice BranchOfficeCity { get; set; }
        public ICollection<VacancyApplicant> VacancyApplicants { get; set; } = new List<VacancyApplicant>();
    }
}
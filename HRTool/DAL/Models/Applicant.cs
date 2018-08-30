using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;

namespace HRTool.DAL.Models
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Range(18, 65)] public int Age { get; set; }

        ///Состояние собеседования (было/нет) 
        public bool Interviewed { get; set; }

        ///Результат собеседования
        public InterviewResult Result { get; set; }

        ///Описание к результату собеседования
        public string ResultDescription { get; set; }

        ///Желаемая зарплата
        public decimal Salary { get; set; }

        ///Дата подачи резюме
        public DateTime ApplicationDate { get; set; }

        public bool Sex { get; set; }

        ///Должность, на которую претендует
        public string WantedPosition { get; set; }

        ///Контактный Email
        [EmailAddress]
        public string ContactMail { get; set; }

        ///Контактный телефон
        [Phone]
        public string ContactPhone { get; set; }

        ///Инфомация о соискателе
        public string About { get; set; }

        ///Пердыдущий опыт работы
        public string Experience { get; set; }

        ///В какой офис 
        public BranchOffice Branch { get; set; }

        public ICollection<VacancyApplicant> VacancyApllicants { get; set; }
        public ICollection<Resume> Resumes { get; set; }
    }
}
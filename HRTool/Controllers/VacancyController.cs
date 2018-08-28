using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRTool.Controllers.Models;
using HRTool.DAL;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class VacancyController : Controller
    {
        private readonly DatabaseContext _context;

        public VacancyController(DatabaseContext context)
        {
            _context = context;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancy([FromBody] VacancyModel vacancyModel)
        {
            using (var db = _context)
            {
                var vacancy = new Vacancy {
                    Name = vacancyModel.Name,
                    DepartureName = vacancyModel.DepartureName,
                    SalaryRangeFrom = vacancyModel.SalaryRangeFrom,
                    SalaryRangeTo = vacancyModel.SalaryRangeTo,
                    RequiredExperienceRange = vacancyModel.RequiredExperienceRange,
                    ContactPerson = vacancyModel.ContactPerson,
                    ContactPhone = vacancyModel.ContactPhone,
                    ContactMail = vacancyModel.ContactMail,
                    EmploymentType = vacancyModel.EmploymentType,
                    WorkHours = vacancyModel.WorkHours,
                    Description = vacancyModel.Description,
                    Duties = vacancyModel.Duties,
                    Requirements = vacancyModel.Requirements,
                    AdditionalRequirements = vacancyModel.AdditionalRequirements,
                    VacancyStatus = vacancyModel.VacancyStatus,
                    VacancyHolderName = vacancyModel.VacancyHolderName,
                    VacancyApllicants = vacancyModel.VacancyApllicants,
                    BranchOfficeCity = vacancyModel.BranchOfficeCity
                };
                await db.Vacancies.AddAsync(vacancy);
                db.SaveChanges();

                return Ok("Вакансия успешно добавлена");
            }
        }

        //Получение листа вакансий

        //TODO
        // Айди в пути, в Query будет OffsetCountSearch
        // В лист вакансий отдавать неполную модель, в конкретную вакансию отдавать полную модель
        // Вернуть количество записей в БД и data (сами данные)

        [Authorize(AuthenticationSchemes = "Bearer")] 
        [HttpGet]
        public async Task<Object> Vacancies()
        {
            using (var db = _context)
            {
                var vacancies = db.Vacancies.ToList();
                var amount = db.Vacancies.Count();
                return new {
                    amount,
                    vacancies
                };
            }
        }

        //В route будет айди вакансии, для которой будет изменение
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> UpdateVacancy([FromBody] VacancyModel vacancyModel, [FromRoute] Guid id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == id);
                //Заполнить модель вакансии
                //vacancy = vacancyModel;
                db.SaveChanges();

                return Ok("Вакансия успешно добавлена");
            }
        }

         //В route будет айди вакансии, для которой будет удаление
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteVacancy([FromRoute] Guid id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == id);
                db.Remove(vacancy);
                db.SaveChanges();
                return Ok($"Вакансия {id} удалена");
            }
        }

        //Изменение статуса вакансии
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] VacancyModel vacancyModel)
        {
            return Ok();
        }
    }
}
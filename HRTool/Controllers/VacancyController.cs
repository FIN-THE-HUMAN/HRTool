using System;
using System.Linq;
using System.Threading.Tasks;
using HRTool.Controllers.DTO;
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
        public async Task<IActionResult> CreateVacancy([FromBody] VacancyDto vacancyDto)
        {
            using (var db = _context)
            {
                var vacancy = new Vacancy{
                    Name = vacancyDto.Name,
                    DepartureName = vacancyDto.DepartureName,
                    SalaryRangeFrom = vacancyDto.SalaryRangeFrom,
                    SalaryRangeTo = vacancyDto.SalaryRangeTo,
                    RequiredExperienceRange = vacancyDto.RequiredExperienceRange,
                    ContactPerson = vacancyDto.ContactPerson,
                    ContactPhone = vacancyDto.ContactPhone,
                    ContactMail = vacancyDto.ContactMail,
                    EmploymentType = vacancyDto.EmploymentType,
                    WorkHours = vacancyDto.WorkHours,
                    Description = vacancyDto.Description,
                    Duties = vacancyDto.Duties,
                    Requirements = vacancyDto.Requirements,
                    AdditionalRequirements = vacancyDto.AdditionalRequirements,
                    VacancyStatus = vacancyDto.VacancyStatus,
                    VacancyHolderName = vacancyDto.VacancyHolderName,
                    VacancyApllicants = vacancyDto.VacancyApllicants,
                    BranchOfficeCity = vacancyDto.BranchOfficeCity
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
        public async Task<IActionResult> UpdateVacancy([FromBody] VacancyDto vacancyDto, [FromRoute] Guid id)
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
        public async Task<IActionResult> ChangeStatus([FromBody] VacancyDto vacancyDto)
        {
            return Ok();
        }
    }
}
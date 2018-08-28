using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("vacancies/")]
    public class VacancyController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public VacancyController(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancy([FromBody] VacancyDto vacancyDto)
        {
            using (var db = _context)
            {
                var vacancy = new Vacancy
                {
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
                    VacancyHolderName = vacancyDto.VacancyHolderName,
                    BranchOfficeCity = vacancyDto.BranchOfficeCity
                };


                var duties = db.Duties.Where(r => vacancyDto.Duties.Contains(r.DutyId.ToString())).ToList();
                var requirements = db.Requirements
                    .Where(r => vacancyDto.Requirements.Contains(r.RequirementId.ToString())).ToList();
                var additionalRequirements = db.Requirements
                    .Where(r => vacancyDto.AdditionalRequirements.Contains(r.RequirementId.ToString())).ToList();

                vacancy.Duties = duties;
                vacancy.Requirements = requirements;
                vacancy.AdditionalRequirements = additionalRequirements;
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
                var data = db.Vacancies.ToList();
                var total = db.Vacancies.Count();
                return new
                {
                    total,
                    data
                };
            }
        }


        //В route будет айди вакансии, для которой будет изменение
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacancy([FromBody] VacancyDto vacancyDto, [FromRoute] string id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == new Guid(id));
                //Заполнить модель вакансии
                //vacancy = vacancyModel;
                db.SaveChanges();

                return Ok("Вакансия успешно добавлена");
            }
        }

        //В route будет айди вакансии, для которой будет удаление
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy([FromRoute] string id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == new Guid(id));
                db.Remove(vacancy);
                db.SaveChanges();
                return Ok($"Вакансия {id} удалена");
            }
        }

        //Изменение статуса вакансии
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus([FromBody] VacancyStatus vacancyStatus, [FromRoute] string id)
        {
            return Ok();
        }
    }
}
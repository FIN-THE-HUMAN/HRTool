using System.Threading.Tasks;
using HRTool.DAL;
using HRTool.Controllers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HRTool.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace it1.Documents.GitHub.HRTool.HRTool.Controllers
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
                var vacancy = new Vacancy(
                    //Заполнить поля модели
                );
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
                return vacancies;
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
            return Ok();
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
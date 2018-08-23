using System.Threading.Tasks;
using HRTool.DAL;
using HRTool.Controllers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HRTool.DAL.Models;
using System.Collections.Generic;
using System.Linq;

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
        [Authorize(AuthenticationSchemes = "Bearer")] 
        [HttpGet]
        public async Task<Object> Vacancies()
        {
            var _vacancies = new List<Vacancy>();

            using (var db = _context)
            {
                var vacancies = db.Vacancies.ToList();
                return vacancies;
            }
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> UpdateVacancy([FromBody] VacancyModel vacancyModel)
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> DeleteVacancy([FromBody] VacancyModel vacancyModel)
        {
            return Ok();
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
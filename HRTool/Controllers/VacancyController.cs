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

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancy([FromBody] VacancyDto vacancyDto)
        {
            using (var db = _context)
            {
                var vacancy = _mapper.Map<VacancyDto, Vacancy>(vacancyDto);
                await db.Vacancies.AddAsync(vacancy);
                db.SaveChanges();

                return Ok("Вакансия успешно добавлена");
            }
        }

        //TODO
        // В лист вакансий отдавать неполную модель, в конкретную вакансию отдавать полную модель

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<Object> Vacancies()
        {
            using (var db = _context)
            {
                var vacancies = db.Vacancies.ToList();
                List<VacanciesDTO> data = _mapper.Map<Vacancy, List<VacanciesDTO>>(vacancies);
                var total = db.Vacancies.Count();
                return new
                {
                    total,
                    data
                };
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<Object> Vacancies([FromRoute] string id`)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == new Guid(id));
                VacancyDTO data = _mapper.Map<Vacancy, VacancyDTO>(vacancy);
                return data;
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacancy([FromBody] VacancyDto vacancyDto, [FromRoute] string id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == new Guid(id));
                vacancy = _mapper.Map<VacancyDto, Vacancy>(vacancyDto);
                db.SaveChanges();

                return Ok("Вакансия успешно добавлена");
            }
        }

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

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus([FromBody] VacancyStatus vacancyStatus, [FromRoute] string id)
        {
            using (var db = _context)
            {
                var vacancy = db.Vacancies.FirstOrDefault(x => x.VacancyId == new Guid(id));
                vacancy.VacancyStatus = vacancyStatus;
                db.SaveChanges();
                return Ok();
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
using HRTool.DAL.Models.IntermediateModels;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("vacancies/")]
    public class VacancyController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public VacancyController(DatabaseContext databaseContext, IMapper mapper)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<Object> CreateVacancy([FromBody] VacancyDto vacancyDto)
        {
            var vacancy = _mapper.Map<VacancyDto, Vacancy>(vacancyDto);
            if (vacancy != null)
            {
                var duties = _databaseContext.Duties
                    .Where(r => vacancyDto.Duties.Contains(r.Id.ToString())).ToList();
                
                /*
                var requirements = _databaseContext.Requirements
                    .Where(r => vacancyDto.Requirements.Contains(r.Id.ToString())).ToList();
                var additionalRequirements = _databaseContext.Requirements
                    .Where(r => vacancyDto.AdditionalRequirements.Contains(r.Id.ToString())).ToList();
*/


                foreach (var duty in duties)
                {
                    var vacancyDuities = new VacancyDuty();
                    vacancyDuities.Duty = duty;
                    vacancy.VacancyDuties.Add(vacancyDuities);
                }
                //vacancy.VacancyDuties.Select(x => x.Duty).ToList().AddRange(duties);
                vacancy.CreationDate = DateTime.Now;
                /*vacancy.Requirements = requirements;
                vacancy.AdditionalRequirements = additionalRequirements;
*/

                await _databaseContext.Vacancies.AddAsync(vacancy);
                _databaseContext.SaveChanges();
                return new {id = vacancy.Id, date = vacancy.CreationDate};
            }

            return BadRequest("Введены неверные данные");
        }
/*
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public object Vacancy([FromRoute] string id)
        {
            var vacancy = _databaseContext.Vacancies.FirstOrDefault(x => x.Id.ToString() == id);
            if (vacancy != default(Vacancy))
            {
                var vacancyDto = _mapper.Map<Vacancy, VacancyDto>(vacancy);
                var dutiesIds = _databaseContext.Duties
                    .Where(x => x.Vacancy.Id.ToString() == id).ToList();
                var dutiesDto = new List<DutyDto>();
                foreach (var duty in duties)
                {
                    dutiesDto.Add(_mapper.Map<Duty, DutyDto>(duty));
                }

                if (vacancyDto != null)
                {
                    return vacancyDto;
                }

                return StatusCode(500, "Внутрення ошибка сервера");
            }

            return BadRequest("Вакансия не найдена");
        }

        [HttpGet]
        public Object Vacancies([FromQuery] int? count,
            [FromQuery] int offset, [FromQuery] string search)
        {
            var vacanciesAmount = _databaseContext.Vacancies.Count();

            search = search ?? "";
            count = count ?? vacanciesAmount;

            var filteredVacancies = _databaseContext.Vacancies
                .Where(x => x.Name.ToLower().Contains(search.ToLower()));

            var vacancies = filteredVacancies
                .OrderByDescending(x => x.CreationDate)
                .Skip(offset)
                .Take((int) count);

            var vacanciesDto = new List<VacanciesDto>();
            foreach (var vacancy in vacancies)
            {
                vacanciesDto.Add(_mapper.Map<Vacancy, VacanciesDto>(vacancy));
            }

            var total = filteredVacancies.Count();
            return new {data = vacanciesDto, total};
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<Object> UpdateVacancy([FromBody] VacancyDto vacancyDto, [FromRoute] string id)
        {
            var vacancy = _databaseContext.Vacancies.FirstOrDefault(x => x.Id == new Guid(id));
            _databaseContext.SaveChanges();
            return Ok("Вакансия успешно добавлена");
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<Object> DeleteVacancy([FromRoute] string id)
        {
            var vacancy = _databaseContext.Vacancies.FirstOrDefault(x => x.Id == new Guid(id));
            _databaseContext.Remove(vacancy);
            _databaseContext.SaveChanges();
            return Ok($"Вакансия {id} удалена");
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}/status")]
        public async Task<Object> ChangeStatus([FromBody] VacancyStatus vacancyStatus, [FromRoute] string id)
        {
            return Ok();
        }*/
    }
}
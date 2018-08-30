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
using Microsoft.EntityFrameworkCore;

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
                var vacancyDtoDutiesIds = vacancyDto.Duties.Select(x => x.Id);
                var duties = _databaseContext.Duties
                    .Where(d => vacancyDtoDutiesIds
                        .Contains(d.Id.ToString()))
                    .ToList();

                var vacancyDtoRequirementsIds = vacancyDto.Requirements.Select(x => x.Id);
                var requirements = _databaseContext.Requirements
                    .Where(r => vacancyDtoRequirementsIds
                        .Contains(r.Id.ToString()))
                    .ToList();

                foreach (var duty in duties)
                {
                    var vacancyDuties = new VacancyDuty();
                    vacancyDuties.Duty = duty;
                    vacancy.VacancyDuties.Add(vacancyDuties);
                }

                foreach (var requirement in requirements)
                {
                    var vacancyRequirements = new VacancyRequirement();
                    vacancyRequirements.Requirement = requirement;
                    vacancy.VacancyRequirements.Add(vacancyRequirements);
                }

                vacancy.CreationDate = DateTime.Now;
                await _databaseContext.Vacancies.AddAsync(vacancy);
                _databaseContext.SaveChanges();
                return new {id = vacancy.Id, creationDate = vacancy.CreationDate};
            }

            return BadRequest("Введены неверные данные");
        }


        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<object> Vacancy([FromRoute] string id)
        {
            var vacancy = await _databaseContext.Vacancies
                .Include(v => v.VacancyRequirements)
                .ThenInclude(r => r.Requirement)
                .Include(v => v.VacancyDuties)
                .ThenInclude(d => d.Duty)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (vacancy != default(Vacancy))
            {
                var vacancyDto = _mapper.Map<Vacancy, VacancyDto>(vacancy);
                if (vacancyDto != null)
                {
                    foreach (var vacancyDuty in vacancy.VacancyDuties)
                    {
                        var dutyDto = _mapper.Map<Duty, DutyDto>(vacancyDuty.Duty);
                        vacancyDto.Duties.Add(dutyDto);
                    }

                    foreach (var vacancyRequirement in vacancy.VacancyRequirements)
                    {
                        var requirementDto = _mapper.Map<Requirement, RequirementDto>(vacancyRequirement.Requirement);
                        vacancyDto.Requirements.Add(requirementDto);
                    }

                    return vacancyDto;
                }

                return StatusCode(500, "Внутрення ошибка сервера");
            }

            return BadRequest("Вакансия не найдена");
        }


        [HttpGet]
        public Object Vacancies([FromQuery] int? count,
            [FromQuery] int offset, [FromQuery] string search, [FromQuery] FilterDto filter)
        {
            var vacanciesAmount = _databaseContext.Vacancies.Count();

            search = search ?? "";
            count = count ?? vacanciesAmount;

            var filteredVacancies = _databaseContext.Vacancies
                .Where(x => (filter.Status == null ? x.Status : filter.Status) == x.Status)
                .Where(x => (filter.BranchOffice == null ? x.BranchOfficeCity : filter.BranchOffice) == x.BranchOfficeCity)
                .Where(x => (filter.Departures == null ? x.DepartureName : filter.Departures) == x.DepartureName)
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
            var vacancy = await _databaseContext.Vacancies.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (vacancy == null) return BadRequest("Введен неверный id вакансии");
            vacancy = _mapper.Map<VacancyDto, Vacancy>(vacancyDto);
            _databaseContext.Update(vacancy);
            _databaseContext.SaveChanges();
            return Ok("Вакансия успешно добавлена");
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy([FromRoute] string id)
        {
            var vacancy = _databaseContext.Vacancies.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            _databaseContext.Remove(vacancy);
            await _databaseContext.SaveChangesAsync();
            return Ok($"Вакансия {id} удалена");
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}/status")]
        public async Task<Object> ChangeStatus([FromBody] VacancyStatus vacancyStatus, [FromRoute] string id)
        {
            var vacancy = await _databaseContext.Vacancies.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (vacancy == null) return BadRequest("Введен не верный id вакансии");
            vacancy.Status = vacancyStatus;
            _databaseContext.Update<Vacancy>(vacancy);
            _databaseContext.SaveChanges();
            return Ok("Статус вакансии успешно изменён");
        }
    }
}
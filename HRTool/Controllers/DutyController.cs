using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("duties/")]
    public class DutyController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public DutyController(DatabaseContext databaseContext, IMapper mapper)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public Object GetDuties()
        {
            var dutiesList = new List<DutyDto>();
            foreach (var duty in _databaseContext.Duties)
            {
                dutiesList.Add(_mapper.Map<Duty, DutyDto>(duty));
            }

            return dutiesList;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<Object> AddDuty([FromBody] DutyDto dutyDto)
        {
            dutyDto.Id = new Guid().ToString();
            var duty = _mapper.Map<DutyDto, Duty>(dutyDto);
            await _databaseContext.Duties.AddAsync(duty);
            await _databaseContext.SaveChangesAsync();
            return Ok("Обязанность успешно добавлена");
        }
    }
}
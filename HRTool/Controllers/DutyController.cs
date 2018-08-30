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
    [Authorize(AuthenticationSchemes = "Bearer")]
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

        [HttpGet]
        public Object GetDuties([FromQuery] string search)
        {
            search = search ?? "";
            var duties = _databaseContext.Duties
                .Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            var dutiesList = new List<DutyDto>();
            foreach (var duty in duties)
            {
                dutiesList.Add(_mapper.Map<Duty, DutyDto>(duty));
            }
            return dutiesList;
        }

        [HttpPost]
        public async Task<Object> AddDuty([FromBody] DutyDto dutyDto)
        {
            var duty = _mapper.Map<DutyDto, Duty>(dutyDto);
            await _databaseContext.Duties.AddAsync(duty);
            await _databaseContext.SaveChangesAsync();
            return Ok("Обязанность успешно добавлена");
        }
    }
}
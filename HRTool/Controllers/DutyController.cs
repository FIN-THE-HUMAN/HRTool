using System;
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
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DutyController(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<Object> AddDuty([FromBody] DutyDto dutyDto)
        {
            using (var db = _context)
            {
                var duty = _mapper.Map<DutyDto, Duty>(dutyDto);
                await db.Duties.AddAsync(duty);
                await db.SaveChangesAsync();
                return Ok("Обязанность успешно добавлена");
            }
        }
    }
}
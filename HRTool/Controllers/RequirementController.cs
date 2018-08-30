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
    [Route("requirements/")]
    public class RequirementController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public RequirementController(DatabaseContext databaseContext, IMapper mapper)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public Object GetRequirements([FromQuery] string search)
        {
            search = search ?? "";
            var requirements = _databaseContext.Requirements
                .Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            var requirementsList = new List<RequirementDto>();
            foreach (var requirement in requirements)
            {
                requirementsList.Add(_mapper.Map<Requirement, RequirementDto>(requirement));
            }

            return requirementsList;
        }

        [HttpPost]
        public async Task<Object> AddRequirement([FromBody] RequirementDto requirementDto)
        {
            var requirement = _mapper.Map<RequirementDto, Requirement>(requirementDto);
            await _databaseContext.Requirements.AddAsync(requirement);
            await _databaseContext.SaveChangesAsync();
            return Ok("Теребование успешно добавлено");
        }
    }
}
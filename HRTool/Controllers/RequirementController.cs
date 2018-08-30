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

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public Object GetRequirements()
        {
            var requirementsList = new List<RequirementDto>();
            foreach (var req in _databaseContext.Requirements)
            {
                requirementsList.Add(_mapper.Map<Requirement, RequirementDto>(req));
            }

            return requirementsList;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<Object> AddRequirement([FromBody] RequirementDto requirementDto)
        {
            requirementDto.Id = new Guid().ToString();
            var requirement = _mapper.Map<RequirementDto, Requirement>(requirementDto);
            await _databaseContext.Requirements.AddAsync(requirement);
            await _databaseContext.SaveChangesAsync();
            return Ok("Теребование успешно добавлено");
        }
    }
}
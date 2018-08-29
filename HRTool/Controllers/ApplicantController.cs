using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRTool.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]s/")]
    public class ApplicantController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ApplicantController(DatabaseContext databaseContext, IMapper mapper)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicant([FromBody] ApplicantDto applicantDto)
        {
            var applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
            await _databaseContext.Applicants.AddAsync(applicant);
            await _databaseContext.SaveChangesAsync();
            return Ok("Соискатель успешно добавлен");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant([FromBody] ApplicantDto applicantDto, [FromRoute] string id)
        {
            var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
            applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
            await _databaseContext.SaveChangesAsync();

            return Ok("Информация о соискателе успешно обновлена");
        }

        [HttpGet]
        public async Task<Object> GetApplicants()
        {
            var applicants = await _databaseContext.Applicants.ToListAsync();
            var total = await _databaseContext.Applicants.CountAsync();
            return new
            {
                total,
                applicants
                
            };
        }

        [HttpGet("{id}")]
        public async Task<Object> GetApplicant([FromRoute] string id)
        {
            var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
            return applicant;
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UploadResume(IFormFile uploadedFile, [FromRoute] string Id)
        {
  
                var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(Id));

                // TODO: добавить в модель соискателя ссылку на сущность резюме
                throw new NotImplementedException("У соискателя еще пока нет ссылки на резюме");

                //return Ok("Файл резюме успешно загружен");
            
        }

        [HttpGet]
        public async Task<Object> DownloadResume()
        {
            throw new NotImplementedException();
        }*/


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant([FromRoute] string id)
        {
            var applicant = _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
            _databaseContext.Remove(applicant);
            await _databaseContext.SaveChangesAsync();
            return Ok($"Соискатель {id} удален");
        }
    }
}
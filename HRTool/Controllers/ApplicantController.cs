using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AutoMapper;
using HRTool.Controllers.DTO;
using HRTool.DAL;
using HRTool.DAL.Models;
using HRTool.DAL.Models.Enums;
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
        public async Task<Object> CreateApplicant([FromBody] ApplicantDto applicantDto)
        {
            var applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
            if (applicant != null)
            {
                await _databaseContext.Applicants.AddAsync(applicant);
                await _databaseContext.SaveChangesAsync();
                return applicant.Id;
            }

            return BadRequest("Введены неверные данные");
        }

        [HttpPut("{id}")]
        public async Task<Object> UpdateApplicant([FromBody] ApplicantDto applicantDto, [FromRoute] string id)
        {
            var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if(applicant == null) return BadRequest("Введен ");
            applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
            await _databaseContext.SaveChangesAsync();
            return Ok("Информация о соискателе успешно обновлена");
        }

        [HttpGet]
        public async Task<Object> GetApplicants()
        {
            var applicants = await _databaseContext.Applicants.ToListAsync();
            var total = await _databaseContext.Applicants.CountAsync();
            var applicantsDto = new List<ApplicantDto>();
            foreach (var applicant in applicants)
            {
                applicantsDto.Add(_mapper.Map<Applicant, ApplicantDto>(applicant));
            }

            return new
            {
                total,
                applicants = applicantsDto
            };
        }

        [HttpGet("{id}")]
        public async Task<Object> GetApplicant([FromRoute] string id)
        {
            var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (applicant != null)
            {
                var applicantDto = _mapper.Map<Applicant, ApplicantDto>(applicant);

                return applicantDto;
            }

            return BadRequest("Введен неверный id");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UploadResume(IFormFile uploadedFile, [FromRoute] string id, ResumeSource resumeSource)
        {
            var applicant = await _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            
            var newResume = new Resume();
            newResume.ResumeSource = resumeSource;
            
            using (var ms = new MemoryStream())
            {
                var rs = uploadedFile.OpenReadStream();
                await rs.CopyToAsync(ms);
                await ms.ReadAsync(newResume.Content, 0, (int)uploadedFile.Length);
                await _databaseContext.Resumes.AddAsync(newResume);
                await _databaseContext.SaveChangesAsync();
            }
            return Ok("Файл резюме успешно загружен");
        }

        [HttpGet]
        public async Task<Object> DownloadResume()
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant([FromRoute] string id)
        {
            var applicant = _databaseContext.Applicants.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            _databaseContext.Remove(applicant);
            await _databaseContext.SaveChangesAsync();
            return Ok($"Соискатель {id} удален");
        }
    }
}
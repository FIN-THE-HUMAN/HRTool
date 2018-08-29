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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]/")]
    public class ApplicantController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ApplicantController(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateApplicant([FromBody] ApplicantDto applicantDto)
        {
            using (var db = _context)
            {
                var applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
                await db.Applicants.AddAsync(applicant);
                await db.SaveChangesAsync();

                return Ok("Соискатель успешно добавлен");
            }
        }
   
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant([FromBody] ApplicantDto applicantDto, [FromRoute] string id)
        {
            using (var db = _context)
            {
                var applicant = await db.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
                applicant = _mapper.Map<ApplicantDto, Applicant>(applicantDto);
                await db.SaveChangesAsync();

                return Ok("Информация о соискателе успешно обновлена");
            }
        }

        [HttpGet]
        public async Task<Object> GetApplicants()
        {
            using (var db = _context)
            {
                var applicantsList = await db.Applicants.ToListAsync();
                var total = await db.Applicants.CountAsync();
                return new
                {
                    total,
                    applicantsList
                };
            }
        }

        [HttpGet]
        public async Task<Object> GetApplicant([FromRoute] string id)
        {
            using (var db = _context)
            {
                var applicant = await db.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
                return applicant;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UploadResume(IFormFile uploadedFile, [FromRoute]string Id)
        {
            using(var db = _context)
            {
                var applicant = await db.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(Id));

                // TODO: добавить в модель соискателя ссылку на сущность резюме
                throw new NotImplementedException("У соискателя еще пока нет ссылки на резюме");

                //return Ok("Файл резюме успешно загружен");
            }
        }

        [HttpGet]
        public async Task<Object> DownloadResume()
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant([FromRoute] string id)
        {
            using (var db = _context)
            {
                var applicant = db.Applicants.FirstOrDefaultAsync(x => x.Id == new Guid(id));
                db.Remove(applicant);
                await db.SaveChangesAsync();
                return Ok($"Соискатель {id} удален");
            }
        }


    }
}
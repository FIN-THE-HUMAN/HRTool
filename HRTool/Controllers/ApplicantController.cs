using System;
using System.Threading.Tasks;
using AngleSharp;
using HRTool.DAL;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("[controller]/")]
    public class ApplicantController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public ApplicantController(UserManager<User> userManager, DatabaseContext databaseContext,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _databaseContext = _databaseContext;
            _configuration = configuration;
        }
    
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<Object> AddApplicant([FromBody] Applicant applicant)
        {
            using (var context = _databaseContext)
            {
            }

            return null;
        }

        [HttpGet]
        public async Task<Object> ChangeResume()
        {
            return null;
        }

        [HttpGet]
        public async Task<Object> DeleteResume()
        {
            return null;
        }
    }
}
using System;
using System.Threading.Tasks;
using AngleSharp;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("[controller]/")]
    public class ResumeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public ResumeController(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<Object> CreateResume()
        {
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
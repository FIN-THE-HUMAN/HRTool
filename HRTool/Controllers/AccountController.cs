using System;
using System.Threading.Tasks;
using HRTool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly SignInManager<SystemUser> _signInManager;

        public AccountController(UserManager<SystemUser> userManager, SignInManager<SystemUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login/")]
        public async Task<ObjectResult> Login([FromBody] string email, [FromBody] string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        password, true, false);

                    if (result.Succeeded)
                    {
                        return Ok("Вход выполнен");
                    }
                }
                return BadRequest("Неверный email и (или) пароль");
            }
            return BadRequest("Заполните все поля");
        }
    }
}
using System;
using System.Threading.Tasks;
using HRTool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register/")]
        public async Task<ObjectResult> Register([FromBody] string email, [FromBody] string password)
        {
            if (!(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)))
            {
                var existedUser = await _userManager.FindByEmailAsync(email);
                if (existedUser != null)
                {
                    return BadRequest("Аккаунт с данной электронной почтой уже зарегистрирован");
                }
                else
                {
                    var user = new User { UserName = email, Email = email };
                    var result = await _userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        return Ok("Регистрация выполнена");
                    }
                    else
                    {
                        return BadRequest("Внутренняя ошибка сервера");
                    }
                } 
            }
             
            return BadRequest("Заполните все поля");
        }

        [HttpPost]
        [Route("login/")]
        public async Task<IActionResult> Login([FromBody] string email, [FromBody] string password)
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

                    return BadRequest("Неверный email и (или) пароль");
                }

                return BadRequest("Неверный email и (или) пароль");
            }

            return BadRequest("Заполните се поля");
        }
    }
}
using System;
using System.Threading.Tasks;
using HRTool.Controllers.Models;
using HRTool.DAL.Models;
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
        [Route("Register/")]
        public async Task<ObjectResult> Register([FromBody] AccountModel accountModel)
        {
            if (!string.IsNullOrEmpty(accountModel.Email) && !string.IsNullOrEmpty(accountModel.Password))
            {
                var normalizedEmail = accountModel.Email.Trim();
                var existedUser = await _userManager.FindByEmailAsync(normalizedEmail);
                if (existedUser != null)
                {
                    return BadRequest("Аккаунт с данной электронной почтой уже зарегистрирован");
                }
                else
                {
                    var user = new User {UserName = normalizedEmail, Email = normalizedEmail};
                    var result = await _userManager.CreateAsync(user, accountModel.Password);

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
        [Route("Login/")]
        public async Task<ObjectResult> Login([FromBody] AccountModel accountModel)
        {
            if (!string.IsNullOrEmpty(accountModel.Email) && !string.IsNullOrEmpty(accountModel.Password))
            {
                var normalizedEmail = accountModel.Email.Trim();
                var user = await _userManager.FindByEmailAsync(normalizedEmail);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        accountModel.Password, true, false);

                    if (result.Succeeded)
                    {
                        return Ok("Вход выполнен");
                    }
                }

                return BadRequest("Неверный email и (или) пароль");
            }

            return BadRequest("Заполните все поля");
        }

        [Route("Logout/")]
        public async Task<ObjectResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Выход выполнен");
        }
    }
}
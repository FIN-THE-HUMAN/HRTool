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

<<<<<<< HEAD
        [Route("Register/")]
        public async Task<IActionResult> Register([FromQuery]User model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await _userManager.FindByEmailAsync(model.Email);
                if (existedUser != null)
                {
                    ModelState.AddModelError("", "Аккаунт с данной электронной почтой уже зарегистрирован");
                }
                else
                {
                    //TODO Написать определение пользователя
                    var user = new User {  };
                    var result = await _userManager.CreateAsync(user, model.PasswordHash);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return new OkResult();
                    }
                }
                
            }   

            return new OkResult();
=======
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
>>>>>>> a66e391465c18b10a10b30720051b0c3af605889
        }
    }
}
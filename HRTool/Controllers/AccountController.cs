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
        }
    }
}
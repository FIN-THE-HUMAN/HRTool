using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HRTool.Controllers.Models;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using HRTool.Models;

namespace HRTool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register/")]
        public async Task<Object> Register([FromBody] AccountModel accountModel)
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
                        return await GenerateJwtToken(accountModel.Email, user);
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
        public async Task<Object> Login([FromBody] AccountModel accountModel)
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
                        return await GenerateJwtToken(accountModel.Email, user);
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

        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
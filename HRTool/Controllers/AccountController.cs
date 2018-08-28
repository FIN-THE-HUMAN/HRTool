using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HRTool.Controllers.DTO;
using HRTool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HRTool.Controllers
{
    [Route("[controller]/")]
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
        
        
        
        [HttpPost]
        [Route("register/")]
        public async Task<Object> Register([FromBody] RegistrationDto registrationDto)
        {
            if (!string.IsNullOrEmpty(registrationDto.Email) &&
                !string.IsNullOrEmpty(registrationDto.Password) &&
                !string.IsNullOrEmpty(registrationDto.Email) &&
                !string.IsNullOrEmpty(registrationDto.Password))
            {
                var normalizedEmail = registrationDto.Email.Trim();
                var existedUser = await _userManager.FindByEmailAsync(normalizedEmail);
                if (existedUser != null)
                {
                    return BadRequest("Аккаунт с данной электронной почтой уже зарегистрирован");
                }
                else
                {
                    var user = new User
                    {
                        UserName = normalizedEmail, Email = normalizedEmail, FirstName = registrationDto.FirstName,
                        LastName = registrationDto.LastName
                    };
                    var result = await _userManager.CreateAsync(user, registrationDto.Password);

                    if (result.Succeeded)
                    {
                        return Ok("Аккаунт успешно зарегистрирован");
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
        public async Task<Object> Login([FromBody] AuthorizationDto authorizationDto)
        {
            if (!string.IsNullOrEmpty(authorizationDto.Email) && !string.IsNullOrEmpty(authorizationDto.Password))
            {
                var normalizedEmail = authorizationDto.Email.Trim();
                var user = await _userManager.FindByEmailAsync(normalizedEmail);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,
                        authorizationDto.Password, true, false);

                    if (result.Succeeded)
                    {
                        var token = await GenerateJwtToken(authorizationDto.Email, user);
                        var userDto = new UserDto();
                        //userModel.Fill(user);
                        return new
                        {
                            token,
                            user = userDto
                        };
                    }
                }

                return BadRequest("Неверный email и (или) пароль");
            }

            return BadRequest("Заполните все поля");
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("{id}/")]
        public async Task<Object> GetUser([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var userDto = new UserDto();
               // userModel.Fill(user);
                return userDto;
            }

            return BadRequest("Пользователь не найден");
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("{id}/")]
        public async Task<ObjectResult> ChangeUser([FromBody] UserDto userDto, [FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Position = userDto.Position;
                user.Email = userDto.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                await _userManager.UpdateAsync(user);
                return Ok("Данные изменены");
            }

            return BadRequest("Пользователь не найден");
        }
    }
}
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Models
{
    //Модель пользователя приложения
    public class User : IdentityUser
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string RoleName {get; set;}
    }
}
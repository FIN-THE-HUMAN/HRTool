using System;
using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Models
=======

namespace HRTool.DAL.Models
>>>>>>> 977c2f96951e4592158f3f25e04da68e64392463
{
    //Модель пользователя приложения
    public class User : IdentityUser
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string RoleName {get; set;}
    }
}
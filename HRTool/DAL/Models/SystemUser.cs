using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HRTool.Models
{
    //Модель пользователя приложения
    public class SystemUser : IdentityUser
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        //TODO: имплементировать ролевые классы
        //public Role RoleName {get; set;}
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HRTool.Models
{
    public class User : IdentityUser
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}
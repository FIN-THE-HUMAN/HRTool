using System;
using HRTool.DAL.Models;

namespace HRTool.Controllers.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Fill(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            RoleName = user.Position;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
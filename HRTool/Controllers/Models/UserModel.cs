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

        public UserModel(string id, string firstName, string lastName, string roleName, string email,
            string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RoleName = roleName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public UserModel(User user)
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
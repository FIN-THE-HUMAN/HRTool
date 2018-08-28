using HRTool.DAL.Models;

namespace HRTool.Controllers.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Fill(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Position = user.Position;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
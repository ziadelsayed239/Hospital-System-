using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class EditStaffViewModel
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public string SocialNumber { get; set; }
        public decimal Salary { get; set; }
    }
}

using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class SignUpViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public string SocialNumber { get; set; }
        public decimal Salary { get; set; }
        public string Role { get; set; }

    }
}

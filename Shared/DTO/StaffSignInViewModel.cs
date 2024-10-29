using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class StaffSignInViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

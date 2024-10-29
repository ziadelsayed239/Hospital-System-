using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Shared.Enums;

namespace DataAccess.Entities
{
    public class Staff : IdentityUser<uint>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? SocialNumber { get; set; }
        public Gender? gender { get; set; } = Gender.Male;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Salary { get; set; } = decimal.Zero;

        public List<Appointment> Appointments { get; set; }
    }
}

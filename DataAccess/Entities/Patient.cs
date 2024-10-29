using Shared.Enums;
using Shared.Base;

namespace DataAccess.Entities
{
    public class Patient : Entity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? SocialNumber { get; set; }
        public Gender? gender { get; set; } = Gender.Male;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactRelationship { get; set; }
        public string? EmergencyContactPhone { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}

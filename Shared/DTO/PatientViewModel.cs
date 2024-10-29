using Shared.Enums;

namespace Shared.DTO
{
    public class PatientViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? SocialNumber { get; set; }
        public Gender? gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmergencyContactName { get; set; } = string.Empty;
        public string? EmergencyContactRelationship { get; set; } = string.Empty;
        public string? EmergencyContactPhone { get; set; } = string.Empty;
    }
}

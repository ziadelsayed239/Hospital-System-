using Shared.Base;
using Shared.Enums;

namespace DataAccess.Entities
{
    public class DoctorInfo : Entity
    {
        public Speciality Speciality { get; set; }
        public int ShiftId { get; set; } = 0;
        public string MedicalLicenseNumber { get; set; } = string.Empty;
    }
}

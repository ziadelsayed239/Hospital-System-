using Shared.Base;
using Shared.Enums;

namespace DataAccess.Entities
{
    public class Appointment : Entity
    {
        public uint PatientId { get; set; }
        public Patient Patient { get; set; }
        public uint DoctorId { get; set; }
        public Staff Doctor { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        public AppointmentType Type { get; set; }
    }
}

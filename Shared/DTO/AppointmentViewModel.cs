using Shared.Enums;namespace Shared.DTO
{
    public class AppointmentViewModel
    {
        public uint PatientId { get; set; }
        public uint DoctorId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public AppointmentType Type { get; set; }
    }
}

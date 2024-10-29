using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class EditAppointmentModelView
    {
        public uint Id { get; set; }
        public uint PatientId { get; set; }
        public uint DoctorId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public AppointmentType Type { get; set; }
    }
}

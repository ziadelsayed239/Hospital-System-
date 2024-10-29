using Application.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        IAppointmentRepository appointments_repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            this.appointments_repository = repository;
        }

        public bool AddAppointment(AppointmentViewModel a)
        {
            appointments_repository.Create(new Appointment
            {
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Date = a.Date,
                Status = a.Status,
                Type = a.Type
            });
            return true;
        }

        public List<Appointment> GetAll()
        {
            return appointments_repository.GetAll().ToList();
        }

        public Appointment GetById(uint id)
        {
            return appointments_repository.GetAll().FirstOrDefault(a => a.Id == id);
        }

        public List<Appointment> GetDoctortAppointments(uint DoctorId)
        {
            return appointments_repository.GetAll().
                Where(a => a.DoctorId == DoctorId).ToList();
        }

        public List<Appointment> GetPatientAppointments(uint PatientId)
        {
            return appointments_repository.GetAll()
                                          .Include(a => a.Doctor)
                                          .Where(a => a.PatientId == PatientId)
                                          .ToList();
        }

        public bool RemoveAppointment(Appointment a)
        {
            appointments_repository.Delete(a);
            return true;
        }

        public bool UpdateAppointment(EditAppointmentModelView a)
        {
            appointments_repository.Update(new Appointment
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                Date = a.Date,
                Status = a.Status,
                Type = a.Type
            });
            return true;
        }
    }
}

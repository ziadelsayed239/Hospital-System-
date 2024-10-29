using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Data
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext context) : base(context) {}

        public Patient GetByName(string firstName, string lastName)
        {
            var patient = GetAll().First(p => p.firstName == firstName && p.firstName == lastName);
            return patient;
        }

    }
}

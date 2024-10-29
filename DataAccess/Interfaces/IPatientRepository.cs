using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public Patient GetById(int id);
        public Patient GetByName(string firstName, string lastName);
    }
}

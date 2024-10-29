using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IStaffRepository : IRepository<Staff>
    {
        public Staff GetById(int id);
        public Staff GetByName(string firstName, string lastName);
    }
}

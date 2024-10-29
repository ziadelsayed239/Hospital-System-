using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Data
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationContext context) : base(context) { }

        public Staff GetByName(string firstName, string lastName)
        {
            var user = context.Users.Where(x => x.firstName == firstName && x.lastName == lastName) as Staff;
            return user;
        }
        public Staff GetById(int id)
        {
            var entity = context.Users.Where(x => x.Id == id) as Staff;
            return entity;
        }
    }
}

using DataAccess.Entities;
using DataAccess.Types;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces
{
    public interface IStaffService
    {
        List<Staff> GetAll();
        Staff GetById(int id);
        Task<StaffWithRole?> GetUserWithRole(uint id);
        Task<List<StaffWithRole>> GetAllWithRole();
        Task<List<Staff>> GetAllDoctors();
        Task<string> GetUserRole(Staff staff);
        List<IdentityRole<uint>> GetAllRoles();
    }
}

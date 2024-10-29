using Application.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Types;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class StaffService : IStaffService
    {
        IStaffRepository _repository;
        UserManager<Staff> _userManager; 
        RoleManager<IdentityRole<uint>> _roleManager;

        public StaffService(IStaffRepository repository, UserManager<Staff> userManager, RoleManager<IdentityRole<uint>> roleManager)
        {
            this._repository = repository;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public List<Staff> GetAll()
        {
            return _repository.GetAll().ToList();
        }
        public async Task<List<StaffWithRole>> GetAllWithRole()
        {
            var result = new List<StaffWithRole> ();
            var users = GetAll();
            if(users.Count() == 0)
            {
                return result;
            }
            foreach( var user in users)
            {
                string role = await GetUserRole(user);
                result.Add(new StaffWithRole { data = user, role = role });
            }
            return result;
        }
        public async Task<StaffWithRole?> GetUserWithRole(uint id)
        {
            var user = _repository.GetAll().FirstOrDefault(s => s.Id == id);

            if(user == null)
            {
                return null;
            }
            string role = await GetUserRole(user);
            return new StaffWithRole
            {
                data = user,
                role = role
            };
        }
        public async Task<List<Staff>> GetAllDoctors()
        {
            var result = await _userManager.GetUsersInRoleAsync("Doctor");
            return result.ToList();
        }
        public async Task<string> GetUserRole(Staff staff)
        {
            var roles = await _userManager.GetRolesAsync(staff);

            if (roles.Count() == 0)
            {
                return null;
            }

            return roles[0];
        }
        public List<IdentityRole<uint>> GetAllRoles()
        {
            var result = _roleManager.Roles.ToList();

            return result;
        }

        public Staff GetById(int id)
        {
            var user = _repository.GetById(id);
            return user;
        }
    }
}

using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<List<ErrorViewModel>> SignUp(SignUpViewModel signUpViewModel);
        Task<(List<ErrorViewModel>, Staff?)> SignIn(StaffSignInViewModel signInViewModel);
        Task SignOut();
        List<IdentityRole<uint>> GetAllRoles();
        Task<string> GetUserRole(Staff staff);

        Task<Staff> GetById(uint id);
        Task<bool> Update(EditStaffViewModel model);

        Task<bool> Delete(uint id);

    }
}

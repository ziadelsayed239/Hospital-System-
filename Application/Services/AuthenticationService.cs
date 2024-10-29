using Application.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;
using System.Security.Claims;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly UserManager<Staff> _userManager;
        private readonly SignInManager<Staff> _signInManager;
        protected readonly RoleManager<IdentityRole<uint>> _roleManager;

        public AuthenticationService(UserManager<Staff> userManager, 
            SignInManager<Staff> signInManager, 
            RoleManager<IdentityRole<uint>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<List<ErrorViewModel>> SignUp(SignUpViewModel signUpViewModel)
        {
            var errors = new List<ErrorViewModel>();

            var user = await _userManager.FindByEmailAsync(signUpViewModel.Email);

            if (user == null)
            {
                user = new Staff
                {
                    firstName = signUpViewModel.FirstName,
                    lastName = signUpViewModel.LastName,
                    UserName = signUpViewModel.Username,
                    Email = signUpViewModel.Email,
                    PhoneNumber = signUpViewModel.PhoneNumber,
                    Address = signUpViewModel.Address,
                    gender = signUpViewModel.Gender,
                    SocialNumber = signUpViewModel.SocialNumber,
                    Salary = signUpViewModel.Salary,
                };

                var result = await _userManager.CreateAsync(user, signUpViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, signUpViewModel.Role);
                    return null;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(new ErrorViewModel(string.Empty, error.Description));
                    }
                }
            }
            else
            {
                errors.Add(new ErrorViewModel(nameof(signUpViewModel.FirstName), "this First Name is already used in another Account"));
                errors.Add(new ErrorViewModel(nameof(signUpViewModel.LastName), "this Last Name is already used in another Account"));
            }

            return errors;
        }
        public async Task<(List<ErrorViewModel>, Staff?)> SignIn(StaffSignInViewModel signInViewModel)
        {
            var errors = new List<ErrorViewModel>();

            var user = await _userManager.FindByEmailAsync(signInViewModel.Email);

            if (user == null)
            {
                errors.Add(new ErrorViewModel("Email", "Invalid Email Address"));
                return (errors, null);
            }

            var flag = await _userManager.CheckPasswordAsync(user, signInViewModel.Password);
            if (!flag)
            {
                errors.Add(new ErrorViewModel("Password", "Invalid Password"));
                return (errors, null);
            }
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
            var result = await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, signInViewModel.RememberMe, false);
            
            if (result.IsNotAllowed)
            {
                errors.Add(new ErrorViewModel(string.Empty, "Your account is not confirmed yet"));
            }

            if (result.IsLockedOut)
            {
                errors.Add(new ErrorViewModel(string.Empty, "Your account is locked!!"));
            }

            return (errors, user);
        }
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<string> GetUserRole(Staff staff)
        {
            var roles = await _userManager.GetRolesAsync(staff);

            if(roles.Count() == 0)
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

        public async Task<Staff> GetById(uint id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user;
        }
        public async Task<bool> Update(EditStaffViewModel model)
        {
            var user = await GetById(model.Id);

            if (user == null)
            {
                return false;
            }

            user.firstName = model.FirstName;
            user.lastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Username;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.gender = model.Gender;
            user.SocialNumber = model.SocialNumber;
            user.Salary = model.Salary;

            await _userManager.UpdateAsync(user);
            return true;
        }

        public async Task<bool> Delete(uint id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return false;
            }

            await _userManager.DeleteAsync(user);
            return true;
        }
    }
}

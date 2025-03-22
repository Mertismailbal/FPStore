using FPStore.Core.Models.Identity;
using FPStore.Repository.Abstracts;
using FPStore.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FPStore.Repository.Concretes
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Kullanıcı işlemleri
        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password, bool isStoreAdmin = false)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var role = isStoreAdmin ? IdentitySeedData.Roles.StoreAdmin : IdentitySeedData.Roles.Member;
                await _userManager.AddToRoleAsync(user, role);
            }
            return result;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        // Kullanıcı-Rol işlemleri
        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            if (role == IdentitySeedData.Roles.SuperAdmin)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Cannot assign SuperAdmin role" });
            }
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role)
        {
            if (role == IdentitySeedData.Roles.SuperAdmin)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Cannot remove SuperAdmin role" });
            }
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

        // Seed işlemleri
        public async Task SeedRolesAsync()
        {
            // Rolleri oluştur
            var roles = new[] { IdentitySeedData.Roles.Member, IdentitySeedData.Roles.StoreAdmin, IdentitySeedData.Roles.SuperAdmin };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // SuperAdmin kullanıcısını oluştur
            var superAdminUser = await _userManager.FindByEmailAsync(IdentitySeedData.DefaultSuperAdmin.Email);

            if (superAdminUser == null)
            {
                superAdminUser = new ApplicationUser
                {
                    UserName = IdentitySeedData.DefaultSuperAdmin.Email,
                    Email = IdentitySeedData.DefaultSuperAdmin.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(superAdminUser, IdentitySeedData.DefaultSuperAdmin.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(superAdminUser, IdentitySeedData.Roles.SuperAdmin);
                }
            }
        }
    }
} 
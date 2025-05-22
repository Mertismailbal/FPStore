using FPStore.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace FPStore.Service.Abstracts
{
    public interface IIdentityService
    {
        // Kullanıcı işlemleri
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password, bool isStoreAdmin = false);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);

        // Kullanıcı-Rol işlemleri
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<bool> IsInRoleAsync(ApplicationUser user, string role);

        // Seed işlemleri
        Task SeedRolesAsync();
    }
} 
using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface IIdentityService : IGenericService<Identity>
    {
        Task<Identity> GetIdentityByEmailAsync(string email);
        Task<Identity> GetIdentityWithRolesAsync(string userId);
        Task<Identity> UpdateUserProfileAsync(string userId, string firstName, string lastName, string phoneNumber);
        Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<bool> AddToRoleAsync(string userId, string role);
        Task<bool> RemoveFromRoleAsync(string userId, string role);
    }
} 
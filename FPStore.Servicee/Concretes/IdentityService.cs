using FPStore.Repository.Abstracts;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class IdentityService : GenericService<Identity>, IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository) : base(identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Identity> GetIdentityByEmailAsync(string email)
        {
            return await _identityRepository.GetIdentityByEmailAsync(email);
        }

        public async Task<Identity> GetIdentityWithRolesAsync(string userId)
        {
            return await _identityRepository.GetIdentityWithRolesAsync(userId);
        }

        public async Task<Identity> UpdateUserProfileAsync(string userId, string firstName, string lastName, string phoneNumber)
        {
            return await _identityRepository.UpdateUserProfileAsync(userId, firstName, lastName, phoneNumber);
        }

        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            return await _identityRepository.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public async Task<bool> AddToRoleAsync(string userId, string role)
        {
            return await _identityRepository.AddToRoleAsync(userId, role);
        }

        public async Task<bool> RemoveFromRoleAsync(string userId, string role)
        {
            return await _identityRepository.RemoveFromRoleAsync(userId, role);
        }
    }

}

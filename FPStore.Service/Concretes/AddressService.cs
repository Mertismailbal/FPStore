using FPStore.Core.Entities;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class AddressService : GenericService<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId)
        {
            return await _addressRepository.GetAddressesByUserIdAsync(userId);
        }

        public async Task<Address> SetDefaultAddressAsync(int addressId, string userId)
        {
            return await _addressRepository.SetDefaultAddressAsync(addressId, userId);
        }
    }
} 
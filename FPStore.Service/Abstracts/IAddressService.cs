using FPStore.Core.Models;

namespace FPStore.Service.Abstracts
{
    public interface IAddressService : IGenericService<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId);
        Task<Address> SetDefaultAddressAsync(int addressId, string userId);
    }
} 
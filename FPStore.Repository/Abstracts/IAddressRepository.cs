using FPStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId);
        Task<Address> SetDefaultAddressAsync(int addressId, string userId);
    }
}

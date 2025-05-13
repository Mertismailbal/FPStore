using FPStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Servicee.Abstracts
{
    public interface IAddressService : IGenericService<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId);
        Task<Address> SetDefaultAddressAsync(int addressId, string userId);
    }
}

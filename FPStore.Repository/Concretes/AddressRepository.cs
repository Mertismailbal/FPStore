using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }

        public async Task<Address> SetDefaultAddressAsync(int addressId, string userId)
        {
            // TODO: Implement
            return await Task.FromResult<Address>(null);
        }

        public async Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId)
        {
            // TODO: Implement
            return await Task.FromResult<IEnumerable<Address>>(null);
        }
    }
}

using FPStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface ICartITemRepository: IGenericRepository<CartItem>
    {
        public Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId);
    }
}

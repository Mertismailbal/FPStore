using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class OrderItemRepository : GenericRepository<OrderItem>,IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }        
    }
}

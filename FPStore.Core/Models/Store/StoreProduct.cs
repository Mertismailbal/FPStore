using FPStore.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Core.Models.Store
{
    public class StoreProduct : BaseEntity
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

        public StoreProduct()
        {
            IsActive = true;
        }
    }
}

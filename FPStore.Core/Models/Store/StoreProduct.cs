using FPStore.Core.Abstracts;
using FPStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public Status IsActive { get; set; } = Status.Active;
        public string ImageUrl { get; set; }

        public StoreProduct()
        {
            IsActive = Status.Active;
        }
    }
}

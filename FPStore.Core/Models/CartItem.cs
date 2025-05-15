using FPStore.Core.Abstracts;
using FPStore.Core.Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Core.Models
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int StoreProductId { get; set; }
        public StoreProduct StoreProduct { get; set; }

        [Range(1, 10)] // Minimum 1, maksimum 10 adet
        public int Quantity { get; set; }

        [NotMapped]
        public decimal SubTotal
        {
            get
            {
                return StoreProduct?.Price * Quantity ?? 0;
            }
        }
    }
}

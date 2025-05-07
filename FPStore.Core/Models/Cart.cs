using FPStore.Core.Abstracts;
using FPStore.Core.Enums;
using FPStore.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Core.Models
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }
        public Status Status => Status.Active;
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        [NotMapped] // Veritabanında saklanmayacak, hesaplanacak
        public double TotalAmount
        {
            get
            {
                if (CartItems != null && CartItems.Any())
                    return CartItems.Sum(item => item.StoreProduct.Price * item.Quantity);
                return 0;
            }
        }

        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
    }
}

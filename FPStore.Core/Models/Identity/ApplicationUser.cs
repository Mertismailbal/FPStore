using FPStore.Core.Abstracts;
using FPStore.Core.Models.Store;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FPStore.Core.Models.Identity
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual Store.Store Store { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public ApplicationUser()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;

            UserRoles = new HashSet<ApplicationUserRole>();
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }
    }
}

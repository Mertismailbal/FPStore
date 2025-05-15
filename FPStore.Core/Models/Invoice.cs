using FPStore.Core.Abstracts;
using FPStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Core.Models
{
    public class Invoice : BaseEntity
    {
        // Fatura ID ve Sipariş ilişkisi
        [Required]
        [MaxLength(20)]
        public string InvoiceId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime InvoiceDate { get; set; }

        // Şirket/Mağaza bilgileri
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyAddress { get; set; }

        [Required]
        [MaxLength(20)]
        public string CompanyPhone { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string CompanyEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyTaxOffice { get; set; }

        [Required]
        [MaxLength(20)]
        public string CompanyTaxNumber { get; set; }

        // Müşteri bilgileri
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerAddress { get; set; }

        [MaxLength(20)]
        public string CustomerTaxInfo { get; set; }  // TC No veya Vergi No

        // Fatura kalemleri
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

        // Hesaplamalar
        [NotMapped]
        public double SubTotal => Order.TotalAmount == null ? 0 : Order.TotalAmount;

        public double TaxRate { get; set; }

        [NotMapped]
        public double TaxAmount => SubTotal * (TaxRate / 100);

        [NotMapped]
        public double TotalAmount => SubTotal + TaxAmount;

        public InvoiceStatus Status { get; set; }

        public Invoice()
        {
            InvoiceDate = DateTime.Now;
            TaxRate = 18; // Varsayılan KDV oranı
            InvoiceItems = new List<InvoiceItem>();
        }
    }
}

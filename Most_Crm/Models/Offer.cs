using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Most_Crm.Models
{
    public class Offer
    {
        public string? OfferRejectionReason { get; set; } // NULL olabilir hale getirildi


        [Key]
        public int OfferID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public Customer? Customer { get; set; } // Eğer ilişki yoksa NULL olabilir

        [Required]
        public string OfferStatus { get; set; } = "Pending"; // Varsayılan değer

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // UTC kullanarak tarih set edildi

        public int Year { get; set; }

        public int Month { get; set; }

        public string? OfferNumber { get; set; }

        public string? Status2 { get; set; }

        public string? Description { get; set; }

        public string? Group { get; set; }

        public string? ServiceDetail { get; set; }

        public string? CompanyName { get; set; }

        public string? ContactPerson { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Source { get; set; }

        public DateTime? OfferDate { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? DueDate { get; set; }

        public bool FollowUp { get; set; } = false;

        public int? ContactPersonID { get; set; } // Foreign Key (opsiyonel olabilir)

        [ForeignKey("ContactPersonID")]
        public ContactPerson? ContactPersonEntity { get; set; } // Navigation Property


    }
}

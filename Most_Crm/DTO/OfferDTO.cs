using System.ComponentModel.DataAnnotations;

namespace Most_Crm.DTOs
{
    public class OfferDTO
    {
        public DateTime? CreatedAt { get; set; }
        public string? OfferRejectionReason { get; set; } // Reddedilme sebebi 

        [Required]
        public int CustomerID { get; set; } // Müşteri ID'si zorunlu olmalı

        [Required]

        public int OfferID { get; set; }
        public string OfferStatus { get; set; } // Teklif Durumu

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

        public bool FollowUp { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        //public string BackupContactPersonName { get; set; }
        //public string BackupContactPersonPhone { get; set; }
        //public string BackupContactPersonEmail { get; set; } // opsiyonel


    }
}

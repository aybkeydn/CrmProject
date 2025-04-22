using Most_Crm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Most_Crm.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string NameSurname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Sector { get; set; }
        public string Status { get; set; }

        public DateTime? EmailSentAt { get; set; } // E-posta gönderim zamanı
        public DateTime? PhoneCallAt { get; set; } // Telefon araması zamanı



        public string CustomerType { get; set; } // "Bireysel" veya "Şirket"
        public string CompanyName { get; set; } // "Most Idea" veya "Most Digital"

        public bool EmailSent { get; set; } = false;
        public bool PhoneCallMade { get; set; } = false;

        public string CariKod { get; set; }

        
        public string Country { get; set; }

        
        public string City { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Müşteriye bağlı teklifler (İlişki)
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();

        public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();

    }
}

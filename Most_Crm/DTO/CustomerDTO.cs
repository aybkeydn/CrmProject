using Most_Crm.DTOs;
using Most_Crm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Most_Crm.DTOs
{
    public class CustomerDTO // dto; modelin dışa aktarılması içindir.
    {
        public int CustomerID { get; set; } // Güncelleme için ID 
        public DateTime? EmailSentAt { get; set; } // E-posta Gönderim Zamanı
        public DateTime? PhoneCallAt { get; set; } // Telefon Arama Zamanı

        public List<OfferDTO> Offers { get; set; } = new List<OfferDTO>();

        [Required]
        public string NameSurname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Sector { get; set; }
        public string Status { get; set; }

        public string Country { get; set; }
        public string City { get; set; }



        [Required]
        public string CustomerType { get; set; } // Şirket mi Bireysel mi?

        public string CompanyName { get; set; } // Hangi şirketten? (Most Idea / Most Digital)

        public bool EmailSent { get; set; } = false;
        public bool PhoneCallMade { get; set; } = false;

        public List<ContactPerson> ContactPersons { get; set; } = new();


    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Most_Crm.Models
{
    public class ContactPerson
    {
        [Key]
        public int ContactPersonID { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }


        // Müşteri ile ilişki
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();

    }
}


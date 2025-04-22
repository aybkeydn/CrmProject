using System.ComponentModel.DataAnnotations;

namespace Most_Crm.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool IsConfirmed { get; set; } = false; // Onaylandı mı?

        public string? RejectionReason { get; set; } // sebebi tut

    }
}

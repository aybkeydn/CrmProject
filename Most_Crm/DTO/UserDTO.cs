using System.ComponentModel.DataAnnotations;

namespace Most_Crm.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string? FullName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsConfirmed { get; set; } = false; // kullanıcı onayı
    }
}


using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.ContactDTOs
{
    public abstract class ContactDtoForManipulation
    {
        [Required(ErrorMessage = "MapUrl zorunlu bir alandır.")]
     
        public string? MapUrl { get; set; }
        [Required(ErrorMessage = "Address zorunlu bir alandır.")]
        [MaxLength(500, ErrorMessage = "Address alanı en fazla 500 karakter olabilir.")]
        [MinLength(20, ErrorMessage = "Address alanı en az 20 karakter olabilir.")]
        [Display(Name = "Adres")]
        public string Address { get; set; } = null!;
        [RegularExpression(@"^[A-Za-z0-9ğüşöçıİĞÜŞÖÇ\s,.-]+$", ErrorMessage = "Telefon alanı geçersiz karakterler içeriyor.")]
        [Required(ErrorMessage = "Telefon zorunlu bir alandır.")]
        [MaxLength(20, ErrorMessage = "Telefon alanı en fazla 20 karakter olabilir.")]
        [MinLength(7, ErrorMessage = "Telefon alanı en az 7 karakter olabilir.")]
        [Display(Name = "Telefon")]
  
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Email zorunlu bir alandır.")]
        [EmailAddress(ErrorMessage = "Geçersiz email formatı.")]
        [MaxLength(100, ErrorMessage = "Email alanı en fazla 100 karakter olabilir.")]
        [MinLength(10, ErrorMessage = "Email alanı en az 10 karakter olabilir.")]
        [Display(Name = "Email")]

        public string Email { get; set; } = null!;
    }
}

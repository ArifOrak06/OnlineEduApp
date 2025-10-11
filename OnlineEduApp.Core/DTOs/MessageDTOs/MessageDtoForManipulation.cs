using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.MessageDTOs
{
    public abstract class MessageDtoForManipulation
    {
        [Required(ErrorMessage = "İsim zorunlu bir alandır.")]
        [MaxLength(100, ErrorMessage = "İsim alanı en fazla 100 karakter olabilir.")]
        [MinLength(3, ErrorMessage = "İsim alanı en az 3 karakter olabilir.")]
        [Display(Name = "İsim")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email zorunlu bir alandır.")]
        [MaxLength(100, ErrorMessage = "İsim alanı en fazla 100 karakter olabilir.")]
        [MinLength(3, ErrorMessage = "İsim alanı en az 3 karakter olabilir.")]
        [EmailAddress(ErrorMessage = "Geçersiz email formatı.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Gönderen zorunlu bir alandır.")]
        [MaxLength(100, ErrorMessage = "Gönderen alanı en fazla 100 karakter olabilir.")]
        [MinLength(3, ErrorMessage = "Gönderen alanı en az 3 karakter olabilir.")]
        [Display(Name = "Gönderen")]
        public string Subject { get; set; } = null!;
        [Required(ErrorMessage = "Gönderen zorunlu bir alandır.")]
        [MaxLength(500, ErrorMessage = "Gönderen alanı en fazla 500 karakter olabilir.")]
        [MinLength(10, ErrorMessage = "Gönderen alanı en az 10 karakter olabilir.")]
        [Display(Name = "Mesaj İçeriği")]
        public string Content { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.SubscriberDTOs
{
    public abstract class SubscriberDtoForManipulation
    {
        [Required(ErrorMessage = "Email zorunlu bir alandır.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        [MaxLength(100, ErrorMessage = "Email en fazla 100 karakter olabilir.")]
        [MinLength(8, ErrorMessage = "Email en az 8 karakter olabilir.")]
        public string Email { get; set; } = null!;
    }
}

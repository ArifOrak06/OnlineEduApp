using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.SocialMediaDTOs
{
    public abstract class SocialMediaDtoForManipulation
    {
        [Required(ErrorMessage ="Sosyal Medya Ikonu zorunlu bir alandır.")]
        [Display(Name ="Sosyal Medya Ikonu")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Sosyal Medya Ikonu zorunlu bir alandır.")]
        [Display(Name = "Sosyal Medya Platformu")]
        [MaxLength(100, ErrorMessage = "Sosyal Medya Platformu en fazla 100 karakter olabilir.")]
        [MinLength(2, ErrorMessage = "Sosyal Medya Platformu en az 2 karakter olabilir.")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Sosyal Medya url adresi zorunlu bir alandır.")]
        [Display(Name = "Sosyal Medya Adresi")]
        public string Url { get; set; } = null!;
    }
}

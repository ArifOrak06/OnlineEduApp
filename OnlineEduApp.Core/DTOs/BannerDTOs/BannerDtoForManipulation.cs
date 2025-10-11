using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.BannerDTOs
{
    public abstract class BannerDtoForManipulation
    {
        [Required(ErrorMessage ="Başlık alanı boş geçilemez!")]
        [MaxLength(150,ErrorMessage ="Başlık alanı en fazla 150 karakter olabilir!")]
        [MinLength(5,ErrorMessage ="Başlık alanı en az 5 karakter olabilir!")]
        [Display(Name ="Başlık")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage ="Resim seçme alanı boş geçilemez!")]
        [Display(Name ="Resim Seçme")]
        public string? ImageUrl { get; set; }
    }
}

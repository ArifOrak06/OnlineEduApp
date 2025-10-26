using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.TestimonialDTOs
{
    public abstract class TestimonialDtoForManipulation
    {
        [Required(ErrorMessage ="Referans Adı boş geçilemez!")]
        [MaxLength(100,ErrorMessage ="Referans Adı en fazla 100 karakter olabilir!")]
        [MinLength(2,ErrorMessage ="Referans Adı en az 2 karakter olabilir!")]
        [Display(Name ="Referans Adı")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Başlık  boş geçilemez!")]
        [MaxLength(150, ErrorMessage = "Başlık  en fazla 150 karakter olabilir!")]
        [MinLength(5, ErrorMessage = "Başlık  en az 5 karakter olabilir!")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Resim Url boş geçilemez!")]
        [Display(Name = "Resim Seçme")]
        public string ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = "Yorum alanı boş geçilemez!")]
        [MaxLength(500, ErrorMessage = "Yorum en fazla 500 karakter olabilir!")]
        [MinLength(10, ErrorMessage = "Yorum en az 10 karakter olabilir!")]
        [Display(Name = "Yorum")]
        public string Comment { get; set; } = null!;
        [Required(ErrorMessage = "Yıldız alanı boş geçilemez!")]
        [Display(Name = "Yıldız")]
        public int Star { get; set; }
    }
}

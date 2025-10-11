using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.BlogDTOs
{
    public abstract class BlogDtoForManipulation
    {
        [Required(ErrorMessage = "Başlık zorunlu bir alandır.")]
        [MinLength(3, ErrorMessage = "Başlık minimum 2 karakterden oluşmalıdır.")]
        [MaxLength(100, ErrorMessage = "Başlık maksimum 50 karakterden oluşmalıdır.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Required(ErrorMessage = "İçerik zorunlu bir alandır.")]
        [MinLength(10, ErrorMessage = "Başlık minimum 2 karakterden oluşmalıdır.")]
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Required(ErrorMessage = "İçerik zorunlu bir alandır.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Makale için kategori bilgisi zorunlu bir alandır.")]
        public int CategoryId { get; set; }


        //[Required(ErrorMessage = "Fiyat zorunlu bir alandır.")]
        //[Range(10, 1000, ErrorMessage = "Fiyat 10 ila 1000 arasında olmalıdır.")]
        //public decimal Price { get; init; }

    }
}

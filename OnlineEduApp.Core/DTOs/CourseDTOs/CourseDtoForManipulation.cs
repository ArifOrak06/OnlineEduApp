using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.CourseDTOs
{
    public abstract class CourseDtoForManipulation 
    {
        [Required(ErrorMessage = "Fiyat zorunlu bir alandır.")]
        [MinLength(3,ErrorMessage = "Kurs adı en az 3 karakter uzunluğunda olmalıdır.")]
        [MaxLength(150, ErrorMessage = "Kurs adı en fazla 150 karakter uzunluğunda olabilir.")]
        [Display(Name = "Kurs Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kurs Kapak Fotoğraf seçimi zorunlu bir alandır.")]
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Kategori Kurs için zorunlu bir alandır.")]
        
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Fiyat zorunlu bir alandır.")]
        [Range(10, 10000, ErrorMessage = "Fiyat 10 ila 10000 arasında olmalıdır.")]
        [Display(Name = "Kurs Fiyatı")]
        public decimal Price { get; init; }
    }
}

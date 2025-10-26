using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.CategoryDTOs
{
    public abstract class CategoryDtoForManipulation
    {
        [Required(ErrorMessage ="Kategori Adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Kategori Adı en fazla 100 karakter olabilir.")]
        [MinLength(3, ErrorMessage = "Kategori Adı en az 3 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kategori İkonu zorunludur.")]
        [Display(Name = "Kategori İkonu")]
        public string? Icon { get; set; }
        [Required(ErrorMessage = "Kategori Açıklaması zorunludur.")]
        [MaxLength(500, ErrorMessage = "Kategori Açıklaması en fazla 500 karakter olabilir.")]
        [MinLength(10, ErrorMessage = "Kategori Açıklaması en az 10 karakter olabilir.")]
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }
    }
}

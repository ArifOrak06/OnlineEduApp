using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.TestimonialDTOs
{
    public sealed class TestimonialDtoForUpdate :TestimonialDtoForManipulation
    {
        [Required(ErrorMessage ="Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}

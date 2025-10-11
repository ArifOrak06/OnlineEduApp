using OnlineEduApp.Core.DTOs.CategoryDTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.CourseDTOs
{
    public sealed class CourseDtoForUpdate : CourseDtoForManipulation
    {
        [Required(ErrorMessage = "Kurs Id zorunlu bir alandır.")]
        public int Id { get; set; }
        public CategoryDto Category { get; set; }
        public bool IsActive { get; set; }

    }
}

using OnlineEduApp.Core.DTOs.CategoryDTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.BlogDTOs
{
    public sealed class BlogDtoForUpdate : BlogDtoForManipulation
    {
        [Required(ErrorMessage = "Id zorunlu bir alandır.")]
        public int Id { get; set; }
        public CategoryDto Category { get; set; }
        public bool IsActive { get; set; }
    }
}

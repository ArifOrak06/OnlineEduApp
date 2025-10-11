using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.CategoryDTOs
{
    public sealed class CategoryDtoForUpdate : CategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Id zorunlu alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }

    }
}

using OnlineEduApp.Core.DTOs.CategoryDTOs;

namespace OnlineEduApp.Core.DTOs.CourseDTOs
{
    public sealed class CourseDtoForUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

    }
}

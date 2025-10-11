using OnlineEduApp.Core.DTOs.BlogDTOs;
using OnlineEduApp.Core.DTOs.CourseDTOs;

namespace OnlineEduApp.Core.DTOs.CategoryDTOs
{
    public sealed class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CourseDto> Courses { get; set; } 
        public ICollection<BlogDto> Blogs { get; set; } 

    }
}

using OnlineEduApp.Core.DTOs.CategoryDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Core.DTOs.BlogDTOs
{
    public sealed class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}

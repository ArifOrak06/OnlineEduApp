using OnlineEduApp.Core.DTOs.CategoryDTOs;

namespace OnlineEduApp.Core.DTOs.BlogDTOs
{
    public sealed class BlogDtoForCreate
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }

    }
}

using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Blog : BaseEntity, IEntity
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

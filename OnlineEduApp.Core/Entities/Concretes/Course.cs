using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Course : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

    }
}

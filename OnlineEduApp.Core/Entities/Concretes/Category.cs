using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Category : BaseEntity, IEntity
    {
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}

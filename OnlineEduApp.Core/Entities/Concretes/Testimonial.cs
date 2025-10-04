using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Testimonial : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int Star { get; set; }
    }
}

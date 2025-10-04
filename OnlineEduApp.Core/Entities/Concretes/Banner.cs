using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Banner : BaseEntity, IEntity
    {
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }


}





using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class SocialMedia : BaseEntity, IEntity
    {
        public string Icon { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;

    }
}

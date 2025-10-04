using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Message : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;

    }
}

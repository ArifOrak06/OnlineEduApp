using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{
    public sealed class Subscriber : BaseEntity, IEntity
    {
        public string Email { get; set; } = null!;
    }
}

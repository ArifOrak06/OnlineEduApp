using OnlineEduApp.Core.Entities.Abstracts;

namespace OnlineEduApp.Core.Entities.Concretes
{

    public sealed class About : BaseEntity, IEntity
    {
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? ImageUrlTwo { get; set; }
        public string? ItemOne { get; set; }
        public string? ItemTwo { get; set; }
        public string? ItemThree { get; set; }
        public string? ItemFour { get; set; }
    }
}

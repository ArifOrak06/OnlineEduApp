namespace OnlineEduApp.Core.Entities.Abstracts
{
    public abstract class BaseEntity : IEntity
    {
        public int  Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}

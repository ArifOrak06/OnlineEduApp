namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class SocialMediaNotFoundException : NotFoundException
    {
        public SocialMediaNotFoundException(int id) : base($"Social Media ID :  {id} sistemde kayıtlı değildir.!") { }
    }
}

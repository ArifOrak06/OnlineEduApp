namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class MessageNotFoundException : NotFoundException
    {
        public MessageNotFoundException(int id) : base($"Social Media ID :{id} sistemde kayıtlı değildir.!") { }
    }
}

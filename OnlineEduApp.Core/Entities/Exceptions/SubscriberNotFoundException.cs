namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class SubscriberNotFoundException : NotFoundException
    {
        public SubscriberNotFoundException(int id): base($"Subscriber Id : {id} sistemde kayıtlı değildir.!")
        {
            
        }
    }
}
